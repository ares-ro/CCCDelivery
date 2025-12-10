using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Animation bulletHitAnimation;

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
            collision.gameObject.GetComponent<Enemy>().HP -= Damage;
            Destroy(gameObject);
            //bulletHitAnimation.Play();
        }
    }
}
