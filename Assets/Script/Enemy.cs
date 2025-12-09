using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    int hpMax = 300;
    int gainCredit = 10;
    
    public GameObject HPUI;
    public GameObject target;
    public GameObject enemyBulletGO;

    public int hp;
    
    void Start()
    {
        hp = hpMax;
        StartCoroutine(Shot());
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
                UserStat.Instance.CREDIT += gainCredit;
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Shot()
    {
        while (true)
        {
            Vector2 fromPosition = gameObject.transform.position;
            Vector2 targetPosition = target.transform.position;
            Vector2 direction = (targetPosition - fromPosition).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            GameObject bulletBuffer = Instantiate(enemyBulletGO, fromPosition, Quaternion.Euler(0, 0, angle));

            bulletBuffer.GetComponent<EnemyBullet>().Damage = 1;

            Rigidbody2D rb = bulletBuffer.GetComponent<Rigidbody2D>();
            rb.linearVelocity = (rb.transform.up * 2000f);

            yield return new WaitForSeconds(2f);
        }
    }
}
