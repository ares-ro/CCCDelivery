using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    int hpMax = 300;
    int gainCredit = 10;
    
    public GameObject HPUI;
    public Transform targetTransform;
    public GameObject enemyBulletGO;

    public int hp;

    Vector2 minRange = new Vector2(-1700, -960);
    Vector2 maxRange = new Vector2(1700, -700);

    Sequence seq;


    void Start()
    {
        hp = hpMax;
        StartCoroutine(Shot());

        MoveRandom();

    }

    void MoveRandom()
    {
        Vector2 targetPos = new Vector2(Random.Range(minRange.x, maxRange.x), Random.Range(minRange.y, maxRange.y));
        transform.DOMove(targetPos, Random.Range(3f, 10f)).SetEase(Ease.InOutSine).OnComplete(MoveRandom);
    }

    public int HP
    {
        get 
        {
            return hp;
        }
        set
        {
            hp = value;

            HPUI.GetComponent<Image>().fillAmount = (float)hp / hpMax;

            if (hp <= 0)
            {
                PlayerStat.Instance.CREDIT += gainCredit;
                transform.DOKill();
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Shot()
    {
        while (true)
        {
            Vector2 fromPosition = gameObject.transform.position;
            Vector2 targetPosition = targetTransform.position;
            Vector2 direction = (targetPosition - fromPosition).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            GameObject bulletBuffer = Instantiate(enemyBulletGO, fromPosition, Quaternion.Euler(0, 0, angle));

            bulletBuffer.GetComponent<EnemyBullet>().Damage = 1;

            Rigidbody2D rb = bulletBuffer.GetComponent<Rigidbody2D>();
            rb.linearVelocity = (rb.transform.up * 2000f);

            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }
}
