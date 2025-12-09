using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Animation bulletHitAnimation;

    public int Damage;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Train")
        {
            UserStat.Instance.TRAINHP -= Damage;
            Destroy(gameObject);
            //bulletHitAnimation.Play();
        }
    }
}
