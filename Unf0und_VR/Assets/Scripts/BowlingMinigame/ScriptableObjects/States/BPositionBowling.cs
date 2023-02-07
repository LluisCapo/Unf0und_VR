using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BowlingState/Positioning", fileName = "new Positioning state")]
public class BPositionBowling : BState
{
    // 07/02/2023 Lluís Capó
    public override void Init(MonoBehaviour _class)
    {
        _stateController = (BStateController)_class;
        _bowlContainer = _stateController.BowlContainer;
        _bowlContainer.CreatePoints();
        _bowlContainer.InstantiateAllBowls();

        //
        _stateController.StartCoroutine(_stateController.StartWaiting(this, 2f));
    }

    public override void OnFinishWaiting()
    {
        _stateController.ChangeState(nextState);
    }

    public override void OnUpdate(MonoBehaviour _class)
    {
        //if (Input.GetKeyDown(KeyCode.K))
            //((BStateController)_class).ChangeState(nextState);
    }
}
