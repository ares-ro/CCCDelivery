using System.Collections;
using System.ComponentModel;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    public int maxHp;
    public int gainCredit;
    [Space]
    public GameObject projectile;
    public int damage;
    public float projectileSpeed;
    public float fireRepeat;
    [Space]
    public Vector2 minRange;
    public Vector2 maxRange;
    [Space]
    public GameObject hpUiElapsed;
    public ParticleSystem destroyEffect;
    public Transform targetTransform;

    int hp;
    bool isDestroying = false;

    void Start()
    {
        hp = maxHp;
        StartCoroutine(Shot());

        MoveRandom();
    }

    public void TakeDamage(int damage)
    {
        if (isDestroying == false)
        {
            if (hp - damage <= 0)
            {
                hp = 0;
                hpUiElapsed.GetComponent<Image>().fillAmount = (float)hp / maxHp;

                isDestroying = true;
                PlayerStat.Instance.CREDIT += gainCredit;
                StartCoroutine(DestroySequence());
            }
            else
            {
                hp -= damage;
                hpUiElapsed.GetComponent<Image>().fillAmount = (float)hp / maxHp;
            }
        }
    }

    IEnumerator DestroySequence()
    {
        destroyEffect.Play();
        yield return new WaitUntil(() => destroyEffect.IsAlive() == false);
        transform.DOKill();
        Destroy(gameObject);
    }

    public virtual void MoveRandom()
    {
        Vector2 targetPos = new Vector2(Random.Range(minRange.x, maxRange.x), Random.Range(minRange.y, maxRange.y));
        transform.DOMove(targetPos, Random.Range(3f, 10f)).SetEase(Ease.InOutSine).OnComplete(MoveRandom);
    }

    public virtual IEnumerator Shot()
    {
        while (true)
        {
            Vector2 fromPosition = gameObject.transform.position;
            Vector2 targetPosition = targetTransform.position;
            Vector2 direction = (targetPosition - fromPosition).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            GameObject bulletBuffer = Instantiate(projectile, fromPosition, Quaternion.Euler(0, 0, angle));
            bulletBuffer.GetComponent<EnemyProjectile>().Damage = damage;

            Rigidbody2D rb = bulletBuffer.GetComponent<Rigidbody2D>();
            rb.linearVelocity = rb.transform.up * projectileSpeed;

            yield return new WaitForSeconds(fireRepeat);
        }
    }
}
