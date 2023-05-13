using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BowlingState/ContainerDown", fileName = "new ContainerUp state")]
public class BContainerDown : BState
{
    [Header("IF SEMIPLENO STATE")] [SerializeField]
    BState ifSemipleno;
    public override void Init(BStateController _class)
    {
        _class.BallInstantiate.RemoveBall();
        _class.PlaneController.isUP = false;
    }
    public override void OnUpdate(BStateController _class)
    {
        if (_class.PlaneController.transform.position.y <= 1.7f)
        {
            if (_class.isSemipleno)
                _class.ChangeState(ifSemipleno);
            else
                _class.ChangeState(nextState);
        }
    }
}
