using UnityEngine;

public class Skill3UI : SkillUIBase
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

            bulletBuffer.GetComponent<Skill3Bullet>().Damage = 10;
            bulletBuffer.GetComponent<Skill3Bullet>().Fire(1500f);
        }
        else if (skillLevel == 2)
        {
            GameObject bulletBuffer = Instantiate(projectile, fromPosition, Quaternion.Euler(0, 0, angle));

            bulletBuffer.GetComponent<Skill3Bullet>().Damage = 20;
            bulletBuffer.GetComponent<Skill3Bullet>().Fire(2000f);
        }
        else if (skillLevel == 3)
        {
            GameObject bulletBuffer = Instantiate(projectile, fromPosition, Quaternion.Euler(0, 0, angle));

            bulletBuffer.GetComponent<Skill3Bullet>().Damage = 30;
            bulletBuffer.GetComponent<Skill3Bullet>().Fire(2000f);
        }
    }
}
