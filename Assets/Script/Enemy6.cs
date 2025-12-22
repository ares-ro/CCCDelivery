using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Enemy6 : EnemyBase
{
    public override void MoveRandom()
    {
        Vector2 targetPos = new Vector2(Random.Range(minRange.x, maxRange.x), Random.Range(minRange.y, maxRange.y));
        transform.DOMove(targetPos, Random.Range(2f, 4f)).SetEase(Ease.InOutSine).OnComplete(MoveRandom);
    }
}