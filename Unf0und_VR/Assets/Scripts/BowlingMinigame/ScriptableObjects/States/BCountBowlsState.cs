using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BowlingState/CountBowls", fileName = "new CountBowls state")]
public class BCountBowlsState : BState
{

    // 07/02/2023 Llu�s Cap�

    [Header("IF SEMIPLENO")][SerializeField]
    BState semiPlenoState;

    protected int _bowlsCount;
    public override void Init(MonoBehaviour _class)
    {
        _stateController = (BStateController)_class;
        _bowlContainer = _stateController.BowlContainer;

        _bowlsCount = 10 - _bowlContainer.CountNonDroppedBowls();

        if(_bowlsCount < 10)
        {
            _bowlContainer.InstantiateNonDroppedBowls();
            _stateController.CanvasReference.CurrentShot.Parameters.UpdateFirstShoot(_bowlsCount);
            Debug.Log("Go to semipleno");
            _stateController.ChangeState(semiPlenoState);
        }
        else
        {
            _bowlContainer.InstantiateAllBowls();
            _bowlContainer.ResetBowl();
            _stateController.CanvasReference.CurrentShot.Parameters.UpdateFirstShoot(_bowlsCount);
            _stateController.ChangeState(nextState);
        }
        _bowlsCount = 0;
    }
}
