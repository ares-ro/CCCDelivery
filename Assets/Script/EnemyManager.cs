using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform trainTransform;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;

    List<Vector2> startPosList = new List<Vector2> 
    {
        new Vector2(-2500, -800),
        new Vector2(2500, -800)
    };

    float repeatTime = 3f;
    float elapsedTime;

    Coroutine generate1;
    Coroutine generate2;
    Coroutine generate3;
    Coroutine generate4;
    Coroutine generate5;
    Coroutine generate6;

    void Start()
    {

    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > 0)
        {
            if (generate1 == null)
            {
                generate1 = StartCoroutine(Generate1());
            }
        }
        if (elapsedTime > 5)
        {
            if (generate2 == null)
            {
                generate2 = StartCoroutine(Generate2());
            }
        }
        if (elapsedTime > 10)
        {
            if (generate3 == null)
            {
                generate3 = StartCoroutine(Generate3());
            }
        }
        if (elapsedTime > 15)
        {
            if (generate4 == null)
            {
                generate4 = StartCoroutine(Generate4());
            }
        }
        if (elapsedTime > 20)
        {
            if (generate5 == null)
            {
                generate5 = StartCoroutine(Generate5());
            }
        }
        if (elapsedTime > 25)
        {
            if (generate6 == null)
            {
                generate6 = StartCoroutine(Generate6());
            }
        }
    }

    IEnumerator Generate1()
    {
        while (true)
        {
            GameObject enemy1Buffer = Instantiate(enemy1);
            enemy1Buffer.transform.position = startPosList[Random.Range(0, 2)];
            enemy1Buffer.GetComponent<EnemyBase>().targetTransform = trainTransform;

            yield return new WaitForSeconds(repeatTime);
        }
    }
    IEnumerator Generate2()
    {
        while (true)
        {
            GameObject enemy1Buffer = Instantiate(enemy2);
            enemy1Buffer.transform.position = startPosList[Random.Range(0, 2)];
            enemy1Buffer.GetComponent<EnemyBase>().targetTransform = trainTransform;

            yield return new WaitForSeconds(repeatTime);
        }
    }
    IEnumerator Generate3()
    {
        while (true)
        {
            GameObject enemy1Buffer = Instantiate(enemy3);
            enemy1Buffer.transform.position = startPosList[Random.Range(0, 2)];
            enemy1Buffer.GetComponent<EnemyBase>().targetTransform = trainTransform;

            yield return new WaitForSeconds(repeatTime);
        }
    }
    IEnumerator Generate4()
    {
        while (true)
        {
            GameObject enemy1Buffer = Instantiate(enemy4);
            enemy1Buffer.transform.position = startPosList[Random.Range(0, 2)];
            enemy1Buffer.GetComponent<EnemyBase>().targetTransform = trainTransform;

            yield return new WaitForSeconds(repeatTime);
        }
    }
    IEnumerator Generate5()
    {
        while (true)
        {
            GameObject enemy1Buffer = Instantiate(enemy5);
            enemy1Buffer.transform.position = startPosList[Random.Range(0, 2)];
            enemy1Buffer.GetComponent<EnemyBase>().targetTransform = trainTransform;

            yield return new WaitForSeconds(repeatTime);
        }
    }
    IEnumerator Generate6()
    {
        while (true)
        {
            GameObject enemy1Buffer = Instantiate(enemy6);
            enemy1Buffer.transform.position = startPosList[Random.Range(0, 2)];
            enemy1Buffer.GetComponent<EnemyBase>().targetTransform = trainTransform;

            yield return new WaitForSeconds(repeatTime);
        }
    }
}
