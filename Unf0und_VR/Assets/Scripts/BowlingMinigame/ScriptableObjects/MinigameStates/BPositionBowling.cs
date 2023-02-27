using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BowlingState/Positioning", fileName = "new Positioning state")]
public class BPositionBowling : BState
{
    // 07/02/2023 Lluís Capó
    public override void Init(BStateController _class)
    {
        _stateController = _class;
        _class.isSemipleno = false;
        _bowlContainer = _stateController.BowlContainer;
        //_bowlContainer.PositioningAllBowls();
    }

    public override void OnFinishWaiting()
    {
        _stateController.ChangeState(nextState);
    }

    public override void OnTrigerEnter(Collider _collider, MonoBehaviour _class)
    {
        _stateController.StartCoroutine(_stateController.StartWaiting(this, 5f));
    }
}
