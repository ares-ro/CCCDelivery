using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Setting;

public class SplashSceneScript : MonoBehaviour
{
    public GameObject mainCanvas;

    void Awake()
    {
        StartCoroutine(SceneFadeSequence());
    }

    void Update()
    {
        
    }

    IEnumerator SceneFadeSequence()
    {
        SceneFadeManagement.FadeIn(mainCanvas.transform);
        yield return new WaitForSeconds(5f);
        SceneFadeManagement.FadeOut(mainCanvas.transform, "TitleScene");
    }
}
