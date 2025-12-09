using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class UserStat : MonoBehaviour
{
    int trainHPMax = 100;

    public static UserStat Instance;

    public Text creditText;
    public GameObject trainHPUI;
    public GameObject trainHPText;

    int credit = 1000;
    int trainHP;

    void Awake()
    {
        Instance = this;
        Instance.creditText.text = Instance.credit.ToString() + " Credit";

        trainHP = trainHPMax;
    }

    public int CREDIT
    {
        get
        {
            return credit;
        }
        set
        {
            credit = value;
            creditText.text = credit.ToString() + " Credit";
        }
    }

    public int TRAINHP
    {
        get
        {
            return trainHP;
        }
        set
        {
            trainHP = value;
            trainHPUI.GetComponent<Image>().fillAmount = (float)trainHP / trainHPMax;
            trainHPText.GetComponent<Text>().text = ((float)trainHP / trainHPMax * 100).ToString("F1") + "%";
            Debug.Log(trainHP);
        }
    }
}
