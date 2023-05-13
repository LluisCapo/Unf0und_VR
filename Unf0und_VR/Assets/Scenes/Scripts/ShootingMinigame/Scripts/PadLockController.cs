using Autohand.Demo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadLockController : ObjectDamagedBehavior
{

    public override void BulletEntry()
    {
        Debug.Log("break");
        foreach(Transform _child in transform)
            _child.gameObject.AddComponent<Rigidbody>();
        this.enabled = false;
    }
}
