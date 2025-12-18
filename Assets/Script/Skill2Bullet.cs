using UnityEngine;

public class Skill2Bullet : MonoBehaviour
{
    public int Damage;

    float destroyTime = 5f;

    void Start()
    {
        
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

    public void Fire(float power)
    {
        gameObject.GetComponent<Rigidbody2D>().linearVelocity = gameObject.GetComponent<Rigidbody2D>().transform.up * power;
    }
}
