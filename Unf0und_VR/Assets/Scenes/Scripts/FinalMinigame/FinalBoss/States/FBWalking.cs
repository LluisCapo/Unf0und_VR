using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boss State/walk", fileName = "new State")]
public class FBWalking : FBState
{
    bool point1;
    public override void Init(FinalBossController _controller)
    {
        _controller.Movement.ResetVelocity();
        point1 = true;
        _dir = _controller.pointToWalk1.position;
    }

    public override void OnUpdate(FinalBossController _controller)
    {

        if(point1)
        {
            if (_controller.transform.position.x <= 5)
                _dir = new Vector3(1, 0f, 0f);
            else
                point1 = false;

            _controller.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else
        {
            if (_controller.transform.position.x >= -1)
                _dir = new Vector3(-1, 0f, 0f);
            else
                point1 = true;

            _controller.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }

        _controller.Movement.Move(_dir);
    }
}
