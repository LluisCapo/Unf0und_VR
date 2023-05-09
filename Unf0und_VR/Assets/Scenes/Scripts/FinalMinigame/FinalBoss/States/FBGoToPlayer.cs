using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boss State/looking player", fileName = "new Looking")]
public class FBGoToPlayer : FBState
{
    public override void Init(FinalBossController _controller)
    {
        //_controller.transform.LookAt(_controller.PlayerRef.position);
    }
    public override void OnUpdate(FinalBossController _controller)
    {
        /*_dir = new Vector3(_controller.PlayerRef.position.x, .0f, _controller.PlayerRef.position.z);

        if (Vector3.Distance(_controller.PlayerRef.position, _controller.transform.position) >= 10)
            _controller.Movement.Move(_dir);
        else
            _controller.ChangeState(_controller.throwingState);

        Debug.Log(Vector3.Distance(_controller.PlayerRef.position, _controller.transform.position));*/
    }
}
