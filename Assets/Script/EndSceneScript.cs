using UnityEngine;
using UnityEngine.UI;

public class EndSceneScript : MonoBehaviour
{
    public Transform mainCanvas;

    public Text scoreText;
    public Button returnButton;

    public GameObject score0;
    public GameObject score1;
    public GameObject score2;

    void Awake()
    {
        SceneFadeManagement.FadeIn(mainCanvas.transform);
        scoreText.text = "남은 체력: " + (ScoreData.trainHP * 100).ToString("F2") + "%";

        if (ScoreData.trainHP == 0)
        {
            score0.SetActive(true);
        }
        else if (0 < ScoreData.trainHP && ScoreData.trainHP <= 0.5f)
        {
            score1.SetActive(true);
        }
        else
        {
            score2.SetActive(true);
        }
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
