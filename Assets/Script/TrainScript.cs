using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class TrainScript : MonoBehaviour
{
    public Transform parent;

    public List<GameObject> trainWheels = new List<GameObject>();

    public Sprite[] mapObjectTrees;
    public Sprite[] mapObjectGrass;
    public Sprite[] mapObjectSigns;
    public Sprite[] mapObjectClouds;
    public Sprite[] mapObjectRocks;

    List<GameObject> treesPool = new List<GameObject>();
    List<GameObject> grassesPool = new List<GameObject>();
    List<GameObject> signsPool = new List<GameObject>();
    List<GameObject> cloudsPool = new List<GameObject>();
    List<GameObject> rocksPool = new List<GameObject>();

    public GameObject mapObjectGOPrefab;

    [Range(0f, 50f)]
    public float speed = 13.89f; // m/s

    //휠 픽셀 246을 실제 기관차 휠 둘레 지름인 1.45m로 치환시켜 비율 산정
    //wheel pixel 246 / real wheel circle length 1.45m = 169.66
    float scaleFactor = 169.66f;
    float poolCount = 20;

    (float elapsed, float target) treeDistance = (0, 0);
    (float min, float max) treeDistanceRange = (10f, 30f);
    (float min, float max) treeVerticalRange = (-1050f, -650f);

    (float elapsed, float target) grassDistance = (0, 0);
    (float min, float max) grassDistanceRange = (10f, 30f);
    (float min, float max) grassVerticalRange = (-1050f, -650f);

    (float elapsed, float target) signDistance = (0, 0);
    (float min, float max) signDistanceRange = (10f, 30f);
    (float min, float max) signVerticalRange = (-1050f, -650f);

    (float elapsed, float target) cloudDistance = (0, 0);
    (float min, float max) cloudDistanceRange = (10f, 30f);
    (float min, float max) cloudVerticalRange = (200f, 900f);

    (float elapsed, float target) rockDistance = (0, 0);
    (float min, float max) rockDistanceRange = (10f, 30f);
    (float min, float max) rockVerticalRange = (-1050f, -650f);

    void Start()
    {
        //trees
        for (int i = 0; i < poolCount; i++)
        {
            for (int j = 0; j < mapObjectTrees.Length; j++)
            {
                GameObject buffer = Instantiate(mapObjectGOPrefab, parent);
                buffer.GetComponent<SpriteRenderer>().sprite = mapObjectTrees[j];
                buffer.transform.localPosition = new Vector3(-3840, 0, 0);
                treesPool.Add(buffer);
                buffer.SetActive(false);
            }
        }

        //grasses
        for (int i = 0; i < poolCount; i++)
        {
            for (int j = 0; j < mapObjectGrass.Length; j++)
            {
                GameObject buffer = Instantiate(mapObjectGOPrefab, parent);
                buffer.GetComponent<SpriteRenderer>().sprite = mapObjectGrass[j];
                buffer.transform.localPosition = new Vector3(-3840, 0, 0);
                grassesPool.Add(buffer);
                buffer.SetActive(false);
            }
        }

        //signs
        for (int i = 0; i < poolCount; i++)
        {
            for (int j = 0; j < mapObjectSigns.Length; j++)
            {
                GameObject buffer = Instantiate(mapObjectGOPrefab, parent);
                buffer.GetComponent<SpriteRenderer>().sprite = mapObjectSigns[j];
                buffer.transform.localPosition = new Vector3(-3840, 0, 0);
                signsPool.Add(buffer);
                buffer.SetActive(false);
            }
        }

        //clouds
        for (int i = 0; i < poolCount; i++)
        {
            for (int j = 0; j < mapObjectClouds.Length; j++)
            {
                GameObject buffer = Instantiate(mapObjectGOPrefab, parent);
                buffer.GetComponent<SpriteRenderer>().sprite = mapObjectClouds[j];
                buffer.transform.localPosition = new Vector3(-3840, 0, 0);
                cloudsPool.Add(buffer);
                buffer.SetActive(false);
            }
        }

        //rocks
        for (int i = 0; i < poolCount; i++)
        {
            for (int j = 0; j < mapObjectRocks.Length; j++)
            {
                GameObject buffer = Instantiate(mapObjectGOPrefab, parent);
                buffer.GetComponent<SpriteRenderer>().sprite = mapObjectRocks[j];
                buffer.transform.localPosition = new Vector3(-3840, 0, 0);
                rocksPool.Add(buffer);
                buffer.SetActive(false);
            }
        }

        treeDistance.target = Random.Range(20f, 50f);
        grassDistance.target = Random.Range(20f, 50f);
        signDistance.target = Random.Range(20f, 50f);
        cloudDistance.target = Random.Range(20f, 50f);
        rockDistance.target = Random.Range(20f, 50f);
    }

    void Update()
    {
        //trees
        for (int i = 0; i < treesPool.Count; i++)
        {
            if (treesPool[i].activeSelf == true)
            {
                treesPool[i].transform.position += (Vector3)(scaleFactor * speed * Time.deltaTime * Vector2.left);
            }
            if (treesPool[i].transform.position.x <= -3840)
            {
                treesPool[i].SetActive(false);
            }
        }

        if (treeDistance.elapsed > treeDistance.target)
        {
            List<GameObject> list = new List<GameObject>();

            foreach (GameObject a in treesPool)
            {
                if (a.activeSelf == false)
                {
                    list.Add(a);
                }
            }

            if (list.Count > 0)
            {
                GameObject buffer = list[Random.Range(0, list.Count)];
                buffer.transform.position = new Vector3(3840, Random.Range(treeVerticalRange.min, treeVerticalRange.max), 0);
                buffer.SetActive(true);

                treeDistance.target = Random.Range(treeDistanceRange.min, treeDistanceRange.max);
                treeDistance.elapsed = 0;
            }
        }
        treeDistance.elapsed += speed * Time.deltaTime;

        //grass
        for (int i = 0; i < grassesPool.Count; i++)
        {
            if (grassesPool[i].activeSelf == true)
            {
                grassesPool[i].transform.position += (Vector3)(Vector2.left * speed * scaleFactor * Time.deltaTime);
            }
            if (grassesPool[i].transform.position.x <= -3840)
            {
                grassesPool[i].SetActive(false);
            }
        }

        if (grassDistance.elapsed > grassDistance.target)
        {
            List<GameObject> list = new List<GameObject>();

            foreach (GameObject a in grassesPool)
            {
                if (a.activeSelf == false)
                {
                    list.Add(a);
                }
            }

            if (list.Count > 0)
            {
                GameObject buffer = list[Random.Range(0, list.Count)];
                buffer.transform.position = new Vector3(3840, Random.Range(grassVerticalRange.min, grassVerticalRange.max), 0);
                buffer.SetActive(true);

                grassDistance.target = Random.Range(grassDistanceRange.min, grassDistanceRange.max);
                grassDistance.elapsed = 0;
            }
        }
        grassDistance.elapsed += speed * Time.deltaTime;

        //sign
        for (int i = 0; i < signsPool.Count; i++)
        {
            if (signsPool[i].activeSelf == true)
            {
                signsPool[i].transform.position += (Vector3)(Vector2.left * speed * scaleFactor * Time.deltaTime);
            }
            if (signsPool[i].transform.position.x <= -3840)
            {
                signsPool[i].SetActive(false);
            }
        }

        if (signDistance.elapsed > signDistance.target)
        {
            List<GameObject> list = new List<GameObject>();

            foreach (GameObject a in signsPool)
            {
                if (a.activeSelf == false)
                {
                    list.Add(a);
                }
            }

            if (list.Count > 0)
            {
                GameObject buffer = list[Random.Range(0, list.Count)];
                buffer.transform.position = new Vector3(3840, Random.Range(signVerticalRange.min, signVerticalRange.max), 0);
                buffer.SetActive(true);

                signDistance.target = Random.Range(signDistanceRange.min, signDistanceRange.max);
                signDistance.elapsed = 0;
            }
        }
        signDistance.elapsed += speed * Time.deltaTime;

        //clouds
        for (int i = 0; i < cloudsPool.Count; i++)
        {
            if (cloudsPool[i].activeSelf == true)
            {
                cloudsPool[i].transform.position += (Vector3)(Vector2.left * speed * scaleFactor * Time.deltaTime);
            }
            if (cloudsPool[i].transform.position.x <= -3840)
            {
                cloudsPool[i].SetActive(false);
            }
        }

        if (cloudDistance.elapsed > cloudDistance.target)
        {
            List<GameObject> list = new List<GameObject>();

            foreach (GameObject a in cloudsPool)
            {
                if (a.activeSelf == false)
                {
                    list.Add(a);
                }
            }

            if (list.Count > 0)
            {
                GameObject buffer = list[Random.Range(0, list.Count)];

                buffer.transform.position = new Vector3(3840, Random.Range(cloudVerticalRange.min, cloudVerticalRange.max), 0);
                buffer.SetActive(true);

                cloudDistance.target = Random.Range(cloudDistanceRange.min, cloudDistanceRange.max);
                cloudDistance.elapsed = 0;
            }
        }
        cloudDistance.elapsed += speed * Time.deltaTime;

        //rocks
        for (int i = 0; i < rocksPool.Count; i++)
        {
            if (rocksPool[i].activeSelf == true)
            {
                rocksPool[i].transform.position += (Vector3)(Vector2.left * speed * scaleFactor * Time.deltaTime);
            }
            if (rocksPool[i].transform.position.x <= -3840)
            {
                rocksPool[i].SetActive(false);
            }
        }

        if (rockDistance.elapsed > rockDistance.target)
        {
            List<GameObject> list = new List<GameObject>();

            foreach (GameObject a in rocksPool)
            {
                if (a.activeSelf == false)
                {
                    list.Add(a);
                }
            }

            if (list.Count > 0)
            {
                GameObject buffer = list[Random.Range(0, list.Count)];

                buffer.transform.position = new Vector3(3840, Random.Range(rockVerticalRange.min, rockVerticalRange.max), 0);
                buffer.SetActive(true);

                rockDistance.target = Random.Range(rockDistanceRange.min, rockDistanceRange.max);
                rockDistance.elapsed = 0;
            }
        }
        rockDistance.elapsed += speed * Time.deltaTime;

        foreach (GameObject a in trainWheels)
        {
            //wheel length 1.45m
            //1.45m : 246pixel = 0.98 : 166pixel
            float rotationThisFrame = speed / (1.45f * Mathf.PI) * 360f * Time.deltaTime * -1;
            a.transform.Rotate(0f, 0f, rotationThisFrame);
        }
    }

    void FixedUpdate()
    {

    }
}
