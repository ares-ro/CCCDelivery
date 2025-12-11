using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform trainTransform;

    public GameObject enemy1;
    List<Vector2> startPosList = new List<Vector2> 
    {
        new Vector2(-2500, -800),
        new Vector2(2500, -800)
    };

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
            enemy1Buffer.transform.position = startPosList[Random.Range(0, 2)];
            enemy1Buffer.GetComponent<Enemy>().targetTransform = trainTransform;

            yield return new WaitForSeconds(Random.Range(3f, 7f));
        }
    }
}
