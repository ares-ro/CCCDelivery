using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform trainTransform;
    public List<GameObject> enemys = new List<GameObject>();
    List<float> stayTimeEnemy = new List<float>() { 0, 60, 180, 300, 360, 480 };

    List<Vector2> startPosList = new List<Vector2>();

    float elapsedTime = 0;

    void Start()
    {
        Vector3 setPosition = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, Random.Range(0f, 0.25f), 0f));
        setPosition.z = 0f;
        Vector3 setPosition2 = Camera.main.ViewportToWorldPoint(new Vector3(-1.1f, Random.Range(0f, 0.25f), 0f));
        setPosition2.z = 0f;
        startPosList.Add(setPosition);
        startPosList.Add(setPosition2);

        StartCoroutine(InstantiateEnemy(enemys[0], stayTimeEnemy[0], 10f, 5f, 300f));
        StartCoroutine(InstantiateEnemy(enemys[1], stayTimeEnemy[1], 10f, 5f, 300f));
        StartCoroutine(InstantiateEnemy(enemys[2], stayTimeEnemy[2], 10f, 5f, 300f));
        StartCoroutine(InstantiateEnemy(enemys[3], stayTimeEnemy[3], 20f, 15f, 300f));
        StartCoroutine(InstantiateEnemy(enemys[4], stayTimeEnemy[4], 20f, 15f, 300f));
        StartCoroutine(InstantiateEnemy(enemys[5], stayTimeEnemy[5], 20f, 15f, 300f));
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        Debug.Log(elapsedTime.ToString());
    }

    IEnumerator InstantiateEnemy(GameObject enemy, float delayTime, float maxRepeatTime, float minRepeatTime, float timeLimitUntil)
    {
        yield return new WaitUntil(() => elapsedTime > delayTime);

        while (true)
        {
            GameObject enemyBuffer = Instantiate(enemy);
            enemyBuffer.transform.position = startPosList[Random.Range(0, 2)];
            enemyBuffer.GetComponent<EnemyBase>().targetTransform = trainTransform;

            float repeatTime = Mathf.Lerp(maxRepeatTime, minRepeatTime, Mathf.Clamp01((elapsedTime - delayTime) / timeLimitUntil));
            yield return new WaitForSeconds(repeatTime);
        }
    }
}
