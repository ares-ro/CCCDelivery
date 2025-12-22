using UnityEngine;
using UnityEngine.UI;

public class EndSceneScript : MonoBehaviour
{
    public GameObject mainCanvas;

    public Text scoreText;
    public Button returnButton;

    void Awake()
    {
        SceneFadeManagement.FadeIn(mainCanvas.transform);
        scoreText.text = "남은 열차 체력: " + ScoreData.trainHP.ToString("F2") + "%";
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void ReturnButtonClicked()
    {
        //gameStartButton.GetComponent<AudioSource>().time = 0.15f;
        returnButton.GetComponent<AudioSource>().Play();
        SceneFadeManagement.FadeOut(mainCanvas.transform, "TitleScene");

    }
}
