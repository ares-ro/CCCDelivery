using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    float trainHPMax = 100;
    float elapsedTimeMax = 100;

    public static PlayerStat Instance;

    public Text creditText;
    public GameObject trainHPUI;
    public GameObject trainHPText;
    public GameObject elapsedTimeUI;

    int credit = 0;
    float trainHP;
    float currentElapsedTime;

    public Transform mainCanvas;

    void Awake()
    {
        Instance = this;
        Instance.creditText.text = Instance.credit.ToString() + " Credit";

        trainHP = trainHPMax;
        currentElapsedTime = elapsedTimeMax;
    }

    void Update()
    {
        if (currentElapsedTime > 0)
        {
            currentElapsedTime -= Time.deltaTime;

            if(currentElapsedTime < 0)
            {
                currentElapsedTime = 0;
                ScoreData.trainHP = trainHP;
                SceneFadeManagement.FadeOut(mainCanvas, "EndScene");
            }
        }
        elapsedTimeUI.GetComponent<Image>().fillAmount = currentElapsedTime / elapsedTimeMax;
    }

    public int Credit
    {
        get { return credit; }
    }

    public float TrainHP
    {
        get { return trainHP; }
    }

    public void GainCredit(int credit)
    {
        this.credit += credit;
        creditText.text = credit.ToString() + " Credit";
    }

    public void TakeDamage(float damage)
    {
        if (trainHP - damage > 0)
        {
            trainHP -= damage;
        }
        else
        {
            trainHP = 0;
            ScoreData.trainHP = trainHP;
            SceneFadeManagement.FadeOut(mainCanvas, "EndScene");
        }
        trainHPUI.GetComponent<Image>().fillAmount = trainHP / trainHPMax;
        trainHPText.GetComponent<Text>().text = (trainHP / trainHPMax * 100).ToString("F1") + "%";
    }
}