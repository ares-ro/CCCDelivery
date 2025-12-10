using UnityEngine;

public class EnemyBullet : MonoBehaviour
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
        if (collision.tag == "Train")
        {
            PlayerStat.Instance.TRAINHP -= Damage;
            Destroy(gameObject);
            //bulletHitAnimation.Play();
        }
    }
}
