using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PinStates/Pickup state", fileName = "new Pickup state")]
public class BBowlingPinPickUp : BBowlingPinState
{
    public override void OnUpdate(BBowlBehavior _owner)
    {
        _owner.transform.position = _owner.Point.position;
    }
    public override void SetPickUp(BBowlBehavior _owner)
    {
        _owner.CurrentState = nextState;
    }
}
