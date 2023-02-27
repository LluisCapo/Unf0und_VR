using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BowlingState/Positioning SemiPleno", fileName = "new Positioning state")]
public class BPositioningSemiPleno : BState
{
    // 07/02/2023 Lluís Capó
    public override void Init(BStateController _class)
    {
        _stateController = _class;
        _bowlContainer = _stateController.BowlContainer;
        //_bowlContainer.CreatePoints();
    }

    public override void OnFinishWaiting()
    {
        _stateController.ChangeState(nextState);
    }

    public override void OnTrigerEnter(Collider _collider, MonoBehaviour _class)
    {
        Debug.Log("ball hit");
        _stateController.StartCoroutine(_stateController.StartWaiting(this, 5f));
    }
}
