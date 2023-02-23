using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BowlingState/SemiPlenoCount", fileName = "new CountBowls state")]
public class BCountBowlsSemiPleno : BState
{
    protected int _bowlsCount;
    public override void Init(BStateController _class)
    {
        _stateController = _class;
        _bowlContainer = _stateController.BowlContainer;
        _stateController.isSemipleno = false;
        _bowlsCount = 10 - _bowlContainer.CountNonDroppedBowls();
        _stateController.CanvasReference.CurrentShot.Parameters.UpdateSecondShot(_bowlsCount);
        _bowlContainer.DesactiveAllBowls();
        _stateController.CanvasReference.NextShot();
        _stateController.BowlContainer.PositioningAllBowls();
        _stateController.ResetState();

        _bowlsCount = 0;
    }
}
