using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BowlingState/CountBowls", fileName = "new CountBowls state")]
public class BCountBowlsState : BState
{
    // 07/02/2023 Lluís Capó
    int _bowlsCount;
    public override void Init(MonoBehaviour _class)
    {
        _stateController = (BStateController)_class;
        _bowlContainer = _stateController.BowlContainer;

        _bowlsCount = 10 - _bowlContainer.CountNonDroppedBowls();

        //aqui va un if que compruebe si va a semipleno
        _bowlContainer.InstantiateNonDroppedBowls();
        Debug.Log("From Init(), " + _bowlsCount);

        _stateController.CanvasReference.CurrentShot.Parameters.UpdateFirstShoot(_bowlsCount);
        _bowlsCount = 0;
    }
}
