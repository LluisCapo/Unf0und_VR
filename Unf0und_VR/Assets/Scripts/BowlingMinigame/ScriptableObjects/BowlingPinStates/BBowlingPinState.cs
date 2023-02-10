using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BBowlingPinState : ScriptableObject
{
    [Header("Next State")] [SerializeField]
    protected BBowlingPinState nextState;
    public abstract void OnUpdate(BBowlBehavior _owner);
    //public abstract void SetPickUp(BBowlBehavior _owner);
}
