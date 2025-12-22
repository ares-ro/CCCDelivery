using DG.Tweening;
using UnityEngine;

public class EnemyMissle1Sub : EnemyBase
{
    public GameObject parent;
    EnemyBase enemyBase;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Train")
        {
            PlayerStat.Instance.TakeDamage(damage);
            enemyBase.TakeDamage(int.MaxValue);
        }

        if (collision.tag == "Skill")
        {
            enemyBase.TakeDamage(enemyBase.damage);
        }
    }

    void FixedUpdate()
    {
        Vector2 fromPosition = gameObject.transform.position;
        Vector2 targetPosition = enemyBase.targetTransform.position;
        Vector2 direction = (targetPosition - fromPosition).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        gameObject.transform.rotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(gameObject.transform.rotation.eulerAngles.z, angle, 0.15f));
    }
    public override void Start()
    {
        enemyBase = parent.GetComponent<EnemyBase>();
        parent.transform.DOMove(enemyBase.targetTransform.position, 20f).SetEase(Ease.InCubic);
    }

}
