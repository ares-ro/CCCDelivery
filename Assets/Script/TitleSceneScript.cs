using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TitleSceneScript : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject setting;
    public GameObject info;
    public Button gameStartButton;
    public Button settingButton;
    public Button infoButton;
    public Button quitButton;

    public GameObject background;

    void Awake()
    {
        SceneFadeManagement.FadeIn(mainCanvas.transform);
    }

    void Start()
    {
        background.transform.DOShakePosition(1f, strength: 10f, vibrato: 5, randomness: 180f, fadeOut: false).SetLoops(-1);

    }

    void Update()
    {

    }

    public void GameStartButtonClicked()
    {
        gameStartButton.GetComponent<AudioSource>().Play();
        SceneFadeManagement.FadeOut(mainCanvas.transform, "GameScene");
    }

    public void SettingButtonClicked()
    {
        settingButton.GetComponent<AudioSource>().Play();
        setting.SetActive(true);
    }

    public void InfoButtonClicked()
    {
        settingButton.GetComponent<AudioSource>().Play();
        info.SetActive(true);
    }

    public void QuitButtonClicked()
    {
        quitButton.GetComponent<AudioSource>().Play();
        Application.Quit();
    }
}