using Autohand.Demo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadLockController : ObjectDamagedBehavior
{
    public override void BulletEntry()
    {
        GetComponent<CubeBreak>().Break();
        GetComponent<Rigidbody>().useGravity = true;
    }
}
