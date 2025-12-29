using UnityEngine;

public class Skill2UI : SkillUIBase
{
    public override void SkillRun()
    {
        Vector2 fromPosition = startPosition;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - fromPosition).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        if (skillLevel == 1)
        {
            GameObject bulletBuffer = Instantiate(projectile, fromPosition, Quaternion.Euler(0, 0, angle));

            bulletBuffer.GetComponent<Skill2Bullet>().Damage = 60;
            bulletBuffer.GetComponent<Skill2Bullet>().Fire(1000f);
        }
        else if (skillLevel == 2)
        {
            float[] angles = { -5, 0, 5 };

            for (int i = 0; i < angles.Length; i++)
            {
                GameObject bulletBuffer = Instantiate(projectile, fromPosition, Quaternion.Euler(0, 0, angle + angles[i]));

                bulletBuffer.GetComponent<Skill2Bullet>().Damage = 100;
                bulletBuffer.GetComponent<Skill2Bullet>().Fire(2000f);
            }
        }
        else if (skillLevel == 3)
        {
            float[] angles = { -10, -5, 0, 5, 10 };

            for (int i = 0; i < angles.Length; i++)
            {
                GameObject bulletBuffer = Instantiate(projectile, fromPosition, Quaternion.Euler(0, 0, angle + angles[i]));

                bulletBuffer.GetComponent<Skill2Bullet>().Damage = 150;
                bulletBuffer.GetComponent<Skill2Bullet>().Fire(2000f);
            }
        }
    }
}