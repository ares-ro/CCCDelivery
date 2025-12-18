using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Enemy3 : EnemyBase
{
    public override void MoveRandom()
    {
        Vector2 targetPos = new Vector2(Random.Range(minRange.x, maxRange.x), Random.Range(minRange.y, maxRange.y));
        transform.DOMove(targetPos, Random.Range(1f, 3f)).SetEase(Ease.InOutSine).OnComplete(MoveRandom);
    }
}