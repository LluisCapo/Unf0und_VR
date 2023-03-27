using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FBState : ScriptableObject
{
    public abstract void Init(FinalBossController _controller);
    public virtual void OnUpdate(FinalBossController _controller) { }
}
