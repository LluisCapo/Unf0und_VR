using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BowlingState/SemiPlenoCount", fileName = "new CountBowls state")]
public class BCountBowlsSemiPleno : BState
{
    protected int _bowlsCount;
    public override void Init(MonoBehaviour _class)
    {
        _stateController = (BStateController)_class;
        _bowlContainer = _stateController.BowlContainer;

        _bowlsCount = 10 - _bowlContainer.CountNonDroppedBowls();
        //_bowlContainer.InstantiateAllBowls();
        _stateController.CanvasReference.CurrentShot.Parameters.UpdateSecondShot(_bowlsCount);
        _bowlContainer.DesactiveAllBowls();
        Debug.Log("finish semipleno");
        _stateController.ResetState();

        _bowlsCount = 0;
    }
}
