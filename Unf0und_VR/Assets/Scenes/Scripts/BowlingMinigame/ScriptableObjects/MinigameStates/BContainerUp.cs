using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BowlingState/ContainerUp", fileName = "new ContainerUp state")]
public class BContainerUp : BState
{
    [Header("IF SEMIPLENO STATE")] [SerializeField]
    BState ifSemipleno;
    public override void Init(BStateController _class)
    {
        Debug.Log("Init up");
        _class.BallInstantiate.SapawnBall();
        _class.PlaneController.isUP = true;
    }
    public override void OnUpdate(BStateController _class)
    {
        if (_class.PlaneController.transform.localPosition.y >= 3.83f)
        {
            if (_class.isSemipleno)
                _class.ChangeState(ifSemipleno);
            else
            {
                Debug.Log("llega");
                _class.ChangeState(nextState);
            }
        }  
    }
}
