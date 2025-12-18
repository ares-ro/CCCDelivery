using UnityEngine;

public class Skill3Object : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Vector2 fromPosition = gameObject.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - fromPosition).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void SkillRun()
    {

    }
}
