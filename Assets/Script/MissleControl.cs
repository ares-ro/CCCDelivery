using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MissleControl : MonoBehaviour
{
    public GameObject parent;
    GameObject target;

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
            rigidbody.linearVelocity = (transform.up * 1000f);
            Debug.Log(angle);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" & target == null)
        {
            target = collision.gameObject;
        }
    }

    bool delayComplete = false;

    IEnumerator LaunchDelay()
    {
        yield return new WaitForSeconds(0.5f);
        delayComplete = true;
    }
}
