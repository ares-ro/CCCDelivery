using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjectManager : MonoBehaviour
{
    public Sprite[] groundMapObjectSprites;
    public Sprite[] skyMapObjectSprites;
    public GameObject mapObjectPrefab;
    Queue<GameObject> groundMapObjectPool = new Queue<GameObject>();
    Queue<GameObject> skyMapObjectPool = new Queue<GameObject>();
    int poolSize = 20;

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject mapObjectBuffer = Instantiate(mapObjectPrefab);
            mapObjectBuffer.SetActive(false);
            groundMapObjectPool.Enqueue(mapObjectBuffer);
        }
        for (int i = 0; i < poolSize; i++)
        {
            GameObject mapObjectBuffer = Instantiate(mapObjectPrefab);
            mapObjectBuffer.SetActive(false);
            skyMapObjectPool.Enqueue(mapObjectBuffer);
        }
        StartCoroutine(Generate());
    }

    void Update()
    {
        
    }

    IEnumerator Generate()
    {
        while (true)
        {
            //ground mapobject
            GameObject mapObjectBuffer = groundMapObjectPool.Dequeue();
            groundMapObjectPool.Enqueue(mapObjectBuffer);
            
            Vector3 setPosition = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, Random.Range(0f, 0.25f), 0f));
            setPosition.z = 0f;
            mapObjectBuffer.transform.position = setPosition;
            
            mapObjectBuffer.GetComponent<SpriteRenderer>().sprite = groundMapObjectSprites[Random.Range(0, groundMapObjectSprites.Length)];
            mapObjectBuffer.SetActive(true);

            //sky mapobject
            GameObject mapObjectBuffer2 = skyMapObjectPool.Dequeue();
            skyMapObjectPool.Enqueue(mapObjectBuffer2);

            Vector3 setPosition2 = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, Random.Range(0.4f, 0.9f), 0f));
            setPosition2.z = 0f;
            mapObjectBuffer2.transform.position = setPosition2;

            mapObjectBuffer2.GetComponent<SpriteRenderer>().sprite = skyMapObjectSprites[Random.Range(0, skyMapObjectSprites.Length)];
            mapObjectBuffer2.SetActive(true);

            yield return new WaitForSeconds(Random.Range(0.3f, 1f));
        }
    }
}
