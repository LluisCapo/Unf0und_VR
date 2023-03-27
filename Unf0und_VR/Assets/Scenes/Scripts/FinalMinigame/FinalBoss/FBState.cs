using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FBState : ScriptableObject
{
    protected Vector3 _dir;
    public abstract void Init(FinalBossController _controller);
    public virtual void OnUpdate(FinalBossController _controller) { }
    public virtual void OnAnimFinish(FinalBossController _controller) { }
    public virtual void OnMiddleAnim(FinalBossController _controller) { }
    public virtual void Throw(FinalBossController _controller) { }
}
