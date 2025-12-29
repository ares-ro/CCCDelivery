using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUIBase : MonoBehaviour
{
    public KeyCode skillKey;
    public int skillLevel;
    public List<LevelStatData> levelStatData = new List<LevelStatData>();
    public Vector2 startPosition;
    public GameObject projectile;
    [Space]

    public Image cooltimeImage;
    public Text levelText;
    public Text requireCreditText;
    public Button upgradeButton;

    float remainTime = 0f;

    void Start()
    {
        SkillDataUpdate();
    }

    void Update()
    {
        remainTime = Mathf.Max(0, remainTime -= Time.deltaTime);

        cooltimeImage.fillAmount = remainTime / levelStatData[skillLevel].cooltime;

        //if (skillLevel < levelStatData.Count)
        //{
        //    cooltimeImage.fillAmount = remainTime / levelStatData[skillLevel].cooltime;
        //}
        //else
        //{
        //    cooltimeImage.fillAmount = remainTime / levelStatData[skillLevel - 1].cooltime;
        //}

        if (Input.GetKey(skillKey) && remainTime == 0 && skillLevel != 0)
        {
            remainTime = levelStatData[skillLevel].cooltime;
            //if (skillLevel < levelStatData.Count)
            //{
            //    remainTime = levelStatData[skillLevel].cooltime;
            //}
            //else
            //{
            //    remainTime = levelStatData[skillLevel - 1].cooltime;
            //}
            SkillRun();
        }
    }

    public virtual void SkillRun()
    {

    }

    public void SkillUpgradeButton()
    {
        if (PlayerStat.Instance.Credit >= levelStatData[skillLevel].requireLevelUpCredit)
        {
            PlayerStat.Instance.GainCredit(-levelStatData[skillLevel].requireLevelUpCredit);
            skillLevel += 1;
            SkillDataUpdate();
        }
    }

    void SkillDataUpdate()
    {
        if (skillLevel < levelStatData.Count - 1)
        {
            levelText.text = "Level " + skillLevel.ToString();
            requireCreditText.text = levelStatData[skillLevel].requireLevelUpCredit + "C";
        }
        else
        {
            upgradeButton.enabled = false;
            levelText.text = "Level " + skillLevel.ToString();
            requireCreditText.text = "-";
        }
    }
}

[System.Serializable]
public class LevelStatData
{
    public int requireLevelUpCredit;
    public float cooltime;

    public LevelStatData(int requireLevelUpCredit, float cooltime)
    {
        this.requireLevelUpCredit = requireLevelUpCredit;
        this.cooltime = cooltime;
    }
}