using UnityEngine;
using UnityEngine.UI;

public class TitleSceneScript : MonoBehaviour
{
    public GameObject mainCanvas;

    public Button gameStartButton;

    void Awake()
    {
        SceneFadeManagement.FadeIn(mainCanvas.transform);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GameStartButtonClicked()
    {
        //gameStartButton.GetComponent<AudioSource>().time = 0.15f;
        gameStartButton.GetComponent<AudioSource>().Play();
        SceneFadeManagement.FadeOut(mainCanvas.transform, "GameScene");

    }
}
