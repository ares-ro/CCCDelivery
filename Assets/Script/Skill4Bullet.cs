using DG.Tweening;
using UnityEngine;

public class Skill4Bullet : MonoBehaviour
{
    public int Damage;

    float destroyTime = 5f;

    void Start()
    {
        gameObject.transform.DOMoveY(gameObject.transform.position.y + 500f, 0.5f).SetEase(Ease.OutCubic);
    }

    void Update()
    {
        if (destroyTime > 0)
        {
            destroyTime -= Time.deltaTime;

            if (destroyTime <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyBase>().TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}