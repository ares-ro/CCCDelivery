using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Skill4BulletRangeDetect : MonoBehaviour
{
    public GameObject parent;
    GameObject target;
    bool delayComplete = false;

    void Start()
    {
        parent.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 1000f, ForceMode2D.Impulse);
        StartCoroutine(LaunchDelay());
    }

    void FixedUpdate()
    {
        if (target != null & delayComplete == true)
        {
            Vector2 fromPosition = parent.gameObject.transform.position;
            Vector2 targetPosition = target.transform.position;
            Vector2 direction = (targetPosition - fromPosition).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            Rigidbody2D rigidbody = parent.gameObject.GetComponent<Rigidbody2D>();

            rigidbody.MoveRotation(Mathf.LerpAngle(rigidbody.rotation, angle, 0.15f));
            rigidbody.linearVelocity = transform.up * 1000f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (target == null)
            {
                target = collision.gameObject;
            }
            else
            {
                Vector2 fromPosition = parent.gameObject.transform.position;
                Vector2 newTargetPosition = collision.transform.position;

                if (Vector2.Distance(fromPosition, newTargetPosition) < Vector2.Distance(fromPosition, target.transform.position))
                {
                    target = collision.gameObject;
                }
            }
        }
    }

    IEnumerator LaunchDelay()
    {
        yield return new WaitForSeconds(0.5f);
        delayComplete = true;
    }
}
