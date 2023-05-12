using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SStateBehavior : ScriptableObject
{
    public abstract void Init(SMachineController _controller);
    public virtual void OnUpdate(SMachineController _controller)
    {

    }

    public virtual void OnWaitingEnd(SMachineController _controller)
    {

    }
}
