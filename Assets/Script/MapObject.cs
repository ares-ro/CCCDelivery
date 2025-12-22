using UnityEngine;

public class MapObject : MonoBehaviour
{
    public float moveSpeed;
    float destroyTime = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        gameObject.transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (destroyTime > 0)
        {
            destroyTime -= Time.deltaTime;

            if (destroyTime <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
