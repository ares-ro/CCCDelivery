using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    List<int> requireCreditList = new List<int>() { 0, 200, 500 };
    Vector2 startPosition = new Vector2(337f, -162f);
    float cooltime = 0.5f;

    public Image cooltimeImage;
    public GameObject bullet;
    public Text levelText;
    public Text requireCreditText;
    public Button skillButton;

    float remainTime = 0f;
    int skillLevel = 1;
    int requireCreditIndex = 0;

    void Start()
    {
        SkillDataUpdate();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) && remainTime == 0)
        {
            SkillRun();
            remainTime = cooltime;
        }

        if (remainTime > 0)
        {
            remainTime -= Time.deltaTime;

            if (remainTime < 0)
            {
                remainTime = 0;
            }
        }
        cooltimeImage.fillAmount = remainTime / cooltime;
    }

    void SkillRun()
    {
        Vector2 fromPosition = startPosition;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - fromPosition).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        if (skillLevel == 1)
        {
            GameObject bulletBuffer = Instantiate(bullet, fromPosition, Quaternion.Euler(0, 0, angle));

            bulletBuffer.GetComponent<Bullet>().Damage = 100;

            Rigidbody2D rb = bulletBuffer.GetComponent<Rigidbody2D>();
            rb.linearVelocity = (rb.transform.up * 2000f);
        }
        else if (skillLevel == 2)
        {
            GameObject bulletBuffer = Instantiate(bullet, fromPosition, Quaternion.Euler(0, 0, angle));

            bulletBuffer.GetComponent<Bullet>().Damage = 100;

            Rigidbody2D rb = bulletBuffer.GetComponent<Rigidbody2D>();
            rb.linearVelocity = (rb.transform.up * 2000f);
        }
        else if (skillLevel == 3)
        {
            float[] angles = { -10, 0, 10 };

            for (int i = 0; i < angles.Length; i++)
            {
                GameObject bulletBuffer = Instantiate(bullet, fromPosition, Quaternion.Euler(0, 0, angle + angles[i]));

                bulletBuffer.GetComponent<Bullet>().Damage = 100;

                Rigidbody2D rb = bulletBuffer.GetComponent<Rigidbody2D>();
                rb.linearVelocity = (rb.transform.up * 2000f);
            }
        }
    }

    public void Skill1UpgradeButton()
    {
        if (UserStat.Instance.CREDIT >= requireCreditList[requireCreditIndex])
        {
            UserStat.Instance.CREDIT -= requireCreditList[requireCreditIndex];
            skillLevel += 1;
            SkillDataUpdate();
        }
    }

    void SkillDataUpdate()
    {
        if (skillLevel == 0)
        {
            requireCreditIndex = 0;
            levelText.text = "Level " + skillLevel.ToString();
            requireCreditText.text = requireCreditList[requireCreditIndex] + "C";
        }
        else if (skillLevel == 1)
        {
            requireCreditIndex = 1;
            levelText.text = "Level " + skillLevel.ToString();
            requireCreditText.text = requireCreditList[requireCreditIndex] + "C";
        }
        else if (skillLevel == 2)
        {
            requireCreditIndex = 2;
            levelText.text = "Level " + skillLevel.ToString();
            requireCreditText.text = requireCreditList[requireCreditIndex] + "C";
        }
        else if (skillLevel == 3)
        {
            skillButton.enabled = false;
            levelText.text = "Level " + skillLevel.ToString();
            requireCreditText.text = "-";
        }
    }
}