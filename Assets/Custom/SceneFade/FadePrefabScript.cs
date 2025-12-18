using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadePrefabScript : MonoBehaviour
{
    string targetScene;

    public void FadeIn()
    {
        gameObject.GetComponent<Animation>().Play("FadeIn");
    }

    public void FadeOut(string sceneName)
    {
        targetScene = sceneName;

        gameObject.GetComponent<Animation>().Play("FadeOut");
    }

    public void FadeInComplete()
    {
        Destroy(gameObject);
    }

    public void FadeOutComplete()
    {
        SceneManager.LoadScene(targetScene);
    }
}
