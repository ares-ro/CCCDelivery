using UnityEngine;

public class EnemyProjectile : MonoBehaviour
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
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Train")
        {
            PlayerStat.Instance.TakeDamage(Damage);
            gameObject.SetActive(false);

        }
    }
}
