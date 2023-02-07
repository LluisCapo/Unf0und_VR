using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BowlingState/Pickup", fileName = "new Pickup state")]
public class BBowlingPickupState : BState
{
    // 07/02/2023 Lluís Capó

    [Header("Seconds to wait")] [SerializeField]
    float secondsToPickUp;
    
    public override void Init(MonoBehaviour _class)
    {
        _stateController = (BStateController)_class;
        _bowlContainer = _stateController.BowlContainer;
        _stateController.StartCoroutine(_stateController.StartWaiting(this, secondsToPickUp));
    }
    public override void OnFinishWaiting()
    {
        int _bowlsDropped = _bowlContainer.CountNonDroppedBowls();
        Debug.Log(_bowlsDropped);
        _bowlContainer.DesactiveAllBowls();
        _stateController.ChangeState(nextState);
    }
}
