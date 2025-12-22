using UnityEngine;

public class Skill4UI : SkillUIBase
{
    public override void SkillRun()
    {
        Vector2 fromPosition = startPosition;

        if (skillLevel == 1)
        {
            GameObject bulletBuffer = Instantiate(projectile, fromPosition, new Quaternion());

            bulletBuffer.GetComponent<Skill4Bullet>().Damage = 20;
        }
        else if (skillLevel == 2)
        {
            GameObject bulletBuffer = Instantiate(projectile, fromPosition, new Quaternion());

            bulletBuffer.GetComponent<Skill4Bullet>().Damage = 30;
        }
        else if (skillLevel == 3)
        {
            GameObject bulletBuffer = Instantiate(projectile, fromPosition, new Quaternion());

            bulletBuffer.GetComponent<Skill4Bullet>().Damage = 40;
        }
    }
}
