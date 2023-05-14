using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitController : ObjectDamagedBehavior
{
    HealthBehavior _hB;
    private void Start()
    {
        _hB = GetComponent<HealthBehavior>();
    }
    public override void BulletEntry()
    {
        _hB.Hurt(1);
    }
}
