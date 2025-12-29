using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    int trainHPMax = 1000000;
    float elapsedTimeMax = 600f;

    public static PlayerStat Instance;

    public Text creditText;
    public GameObject trainHPUI;
    public GameObject trainHPText;
    public GameObject elapsedTimeUI;

    int credit = 0;
    int trainHP;
    float currentElapsedTime = 0;

    public Transform mainCanvas;

    void Awake()
    {
        Instance = this;

        creditText.text = credit.ToString() + " Credit";
        trainHP = trainHPMax;
        currentElapsedTime = elapsedTimeMax;
    }

    void Update()
    {
        if (isLoadingEndScene == true)
        {
            return;
        }
        if (currentElapsedTime > 0)
        {
            currentElapsedTime -= Time.deltaTime;

            if (currentElapsedTime < 0)
            {
                currentElapsedTime = 0;
                ScoreData.trainHP = (float)trainHP / trainHPMax;
                isLoadingEndScene = true;
                SceneFadeManagement.FadeOut(mainCanvas, "EndScene");
            }
        }
        elapsedTimeUI.GetComponent<Image>().fillAmount = currentElapsedTime / elapsedTimeMax;
    }

    public int Credit
    {
        get { return credit; }
    }

    public int TrainHP
    {
        get { return trainHP; }
    }

    public void GainCredit(int credit)
    {
        this.credit += credit;
        creditText.text = this.credit.ToString() + " Credit";
    }

    bool isLoadingEndScene = false;

    public void TakeDamage(int damage)
    {
        if (isLoadingEndScene == true)
        {
            return;
        }
        if (trainHP - damage > 0)
        {
            trainHP -= damage;
        }
        else
        {
            trainHP = 0;
            ScoreData.trainHP = (float)trainHP / trainHPMax;
            isLoadingEndScene = true;
            SceneFadeManagement.FadeOut(mainCanvas, "EndScene");
        }
        trainHPUI.GetComponent<Image>().fillAmount = (float)trainHP / trainHPMax;
        trainHPText.GetComponent<Text>().text = ((float)trainHP / trainHPMax * 100).ToString("F2") + "%";
    }
}