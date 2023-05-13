using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BowlingState/CountBowls", fileName = "new CountBowls state")]
public class BCountBowlsState : BState
{

    // 07/02/2023 Lluís Capó

    [Header("IF SEMIPLENO")][SerializeField]
    BState semiPlenoState;

    protected int _bowlsCount;
    public override void Init(BStateController _class)
    {
        _stateController = _class;
        _bowlContainer = _stateController.BowlContainer;

        _bowlsCount = 10 - _bowlContainer.CountNonDroppedBowls();

        if(_bowlsCount < 10)
        {
            _bowlContainer.PositioningActiveBowls();
            _stateController.CanvasReference.CurrentShot.Parameters.UpdateFirstShoot(_bowlsCount);
            _stateController.isSemipleno = true;
            _stateController.BowlContainer.PositioningActiveBowls();
            _stateController.ChangeState(semiPlenoState);
        }
        else
        {
            _bowlContainer.PositioningAllBowls();
            _bowlContainer.ResetBowl();
            _stateController.CanvasReference.CurrentShot.Parameters.UpdateFirstShoot(_bowlsCount);
            _stateController.CanvasReference.NextShot();
            
            _stateController.ChangeState(nextState);
        }

        _bowlsCount = 0;
    }
}
