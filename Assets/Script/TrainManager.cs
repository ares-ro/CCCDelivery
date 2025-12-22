using UnityEngine;

public class TrainManager : MonoBehaviour
{
    public GameObject[] wheels;

    void Start()
    {

    }

    void Update()
    {
        foreach (GameObject wheel in wheels)
        {
            wheel.transform.Rotate(0f, 0f, -360f * 2 * Time.deltaTime);
        }
    }
}