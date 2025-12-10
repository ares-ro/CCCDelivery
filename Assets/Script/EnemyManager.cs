using System.Collections;
using DG.Tweening;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform trainTransform;

    public GameObject enemy1;
    Vector2 minRange = new Vector2(-2500, -960);
    Vector2 maxRange = new Vector2(-2500, -700);

    void Start()
    {
        StartCoroutine(Generate());    
    }

    void Update()
    {
        
    }

    IEnumerator Generate()
    {
        while (true)
        {
            GameObject enemy1Buffer = Instantiate(enemy1);
            enemy1Buffer.transform.position = new Vector2(Random.Range(minRange.x, maxRange.x), Random.Range(minRange.y, maxRange.y));
            enemy1Buffer.GetComponent<Enemy>().targetTransform = trainTransform;

            yield return new WaitForSeconds(Random.Range(1f, 5f));
        }
    }
}
