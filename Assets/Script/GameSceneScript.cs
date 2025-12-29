using UnityEngine;

public class GameSceneScript : MonoBehaviour
{
    public Transform mainCanvas;

    void Start()
    {
        SceneFadeManagement.FadeIn(mainCanvas);
    }

    void Update()
    {

    }
}
