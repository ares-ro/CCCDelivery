using UnityEngine;

public class Bullet : MonoBehaviour
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
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().HP -= Damage;
            Destroy(gameObject);
            //bulletHitAnimation.Play();
        }
    }
}
