using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMissle1 : EnemyBase
{
    public override void Start()
    {
        hp = maxHp;
    }
}
