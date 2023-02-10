using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PinStates/Normal state", fileName = "new Normal state")]
public class BBowlingNormalState : BBowlingPinState
{
    public override void OnUpdate(BBowlBehavior _owner)
    {
    }
    /*public override void SetPickUp(BBowlBehavior _owner)
    {
        _owner.CurrentState = nextState;
    }*/
}

