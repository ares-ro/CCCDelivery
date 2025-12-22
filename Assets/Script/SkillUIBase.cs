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

    [System.Serializable]
    public class LevelStatData
    {
        public int credit;
        public float cooltime;
        
        public LevelStatData(int credit, float cooltime)
        {
            this.credit = credit;
            this.cooltime = cooltime;
        }
    }

    void Start()
    {
        SkillDataUpdate();
    }

    void Update()
    {
        if (remainTime > 0)
        {
            remainTime -= Time.deltaTime;

            if (remainTime < 0)
            {
                remainTime = 0;
            }
        }

        if (skillLevel < levelStatData.Count)
        {
            cooltimeImage.fillAmount = remainTime / levelStatData[skillLevel].cooltime;
        }
        else
        {
            cooltimeImage.fillAmount = remainTime / levelStatData[skillLevel - 1].cooltime;
        }

        if (Input.GetKey(skillKey) & remainTime == 0 & skillLevel != 0)
        {
            if (skillLevel < levelStatData.Count)
            {
                remainTime = levelStatData[skillLevel].cooltime;
            }
            else
            {
                remainTime = levelStatData[skillLevel - 1].cooltime;
            }
            SkillRun();
        }
    }

    public virtual void SkillRun()
    {

    }

    public void SkillUpgradeButton()
    {
        if (PlayerStat.Instance.Credit >= levelStatData[skillLevel].credit)
        {
            PlayerStat.Instance.GainCredit(-levelStatData[skillLevel].credit);
            skillLevel += 1;
            SkillDataUpdate();
        }
    }

    void SkillDataUpdate()
    {
        if (skillLevel < levelStatData.Count)
        {
            levelText.text = "Level " + skillLevel.ToString();
            requireCreditText.text = levelStatData[skillLevel].credit + "C";
        }
        else
        {
            upgradeButton.enabled = false;
            levelText.text = "Level " + skillLevel.ToString();
            requireCreditText.text = "-";
        }
    }
}