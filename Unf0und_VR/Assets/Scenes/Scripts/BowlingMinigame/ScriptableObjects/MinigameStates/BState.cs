using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BState : ScriptableObject
{
    // 07/02/2023 Lluís Capó

    [Header("Next State")] [SerializeField]
    protected BState nextState;

    protected BStateController _stateController;
    protected BBowlContainer _bowlContainer;

    public abstract void Init(BStateController _class);

    public virtual void OnFinishWaiting(){}
    public virtual void OnUpdate(BStateController _class) { }
    public virtual void OnTrigerEnter(Collider _collider, MonoBehaviour _class){}
}
