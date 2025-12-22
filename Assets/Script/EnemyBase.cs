using System.Collections;
using System.Collections.Generic;
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

    protected int hp;
    bool isDestroying = false;

    Queue<GameObject> projectilePool = new Queue<GameObject>();
    int poolSize = 20;

    public virtual void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject projectileBuffer = Instantiate(projectile);
            projectileBuffer.SetActive(false);
            projectilePool.Enqueue(projectileBuffer);
        }

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
                PlayerStat.Instance.GainCredit(gainCredit);
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
        transform.DOMove(targetPos, Random.Range(5f, 10f)).SetEase(Ease.InOutSine).OnComplete(MoveRandom);
    }

    public virtual IEnumerator Shot()
    {
        while (true)
        {
            Vector2 fromPosition = gameObject.transform.position;
            Vector2 targetPosition = targetTransform.position;
            Vector2 direction = (targetPosition - fromPosition).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            GameObject projectileBuffer = projectilePool.Dequeue();
            projectilePool.Enqueue(projectileBuffer);

            projectileBuffer.transform.position = fromPosition;
            projectileBuffer.transform.rotation = Quaternion.Euler(0, 0, angle);
            projectileBuffer.GetComponent<EnemyProjectile>().Damage = damage;

            projectileBuffer.SetActive(true);

            Rigidbody2D rb = projectileBuffer.GetComponent<Rigidbody2D>();
            rb.linearVelocity = rb.transform.up * projectileSpeed;

            yield return new WaitForSeconds(fireRepeat);
        }
    }
}
