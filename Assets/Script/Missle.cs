using UnityEngine;

public class Missle : MonoBehaviour
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

        {
            if (collision.tag == "Enemy")
            {
                collision.gameObject.GetComponent<Enemy1>().TakeDamage(Damage);
                Destroy(gameObject);
            }
        }
    }
}