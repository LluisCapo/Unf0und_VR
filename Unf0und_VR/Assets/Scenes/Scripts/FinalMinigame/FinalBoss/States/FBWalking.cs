using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boss State/walk", fileName = "new State")]
public class FBWalking : FBState
{
    Vector3 _currentPoint;
    public override void Init(FinalBossController _controller)
    {
        _controller.Movement.ResetVelocity();

        if (Random.Range(0, 2) == 0)
        {
            _dir = new Vector3(1, 0f, 0f);
            _controller.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            _currentPoint = _controller.pointToWalk1.position;
        }
        else
        {
            _currentPoint = _controller.pointToWalk2.position;
            _dir = new Vector3(-1, 0f, 0f);
            _controller.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
    }

    public override void OnUpdate(FinalBossController _controller)
    {
        _controller.Movement.Move(_dir);

        if (Vector3.Distance(_controller.transform.position, _currentPoint) < 1f)
            _controller.ChangeState(_controller.throwingState);
    }
}

/*if(point1)
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
        }*/