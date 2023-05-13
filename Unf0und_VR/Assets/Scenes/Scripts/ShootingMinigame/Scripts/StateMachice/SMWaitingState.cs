using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SMachine/Waiting")]
public class SMWaitingState : SStateBehavior
{
    public float secondsToWait;
    public override void Init(SMachineController _controller)
    {
        _controller.StartCoroutine(_controller.Wait(secondsToWait));
    }

    public override void OnWaitingEnd(SMachineController _controller)
    {
        //incrementa vel
        //decrementa score
        _controller.objective.transform.GetChild(0).GetComponent<MeshCollider>().enabled = false;
        _controller.delay -= _controller.incrementalSpeed;
        if(_controller.delay <= 1.5)
        {
            _controller.delay = 100;
            _controller.SetPlayer();
        }
        else
            _controller.SetMoving();


    }
}
