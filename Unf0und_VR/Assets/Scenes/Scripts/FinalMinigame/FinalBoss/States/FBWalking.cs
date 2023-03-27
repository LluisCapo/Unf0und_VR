using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boss State/walk", fileName = "new State")]
public class FBWalking : FBState
{
    public override void Init(FinalBossController _controller)
    {
        
    }

    public override void OnUpdate(FinalBossController _controller)
    {
        if (_controller.transform.position.x >= _controller.pointToWalk1.position.x)
        {
            _controller.Movement.Move(_controller.pointToWalk1.position);
            //_controller.transform.LookAt(_controller.pointToWalk1);
        }
        else
        {
            _controller.Movement.Move(_controller.pointToWalk2.position);
            //_controller.transform.LookAt(_controller.pointToWalk2);
        }
    }
}
