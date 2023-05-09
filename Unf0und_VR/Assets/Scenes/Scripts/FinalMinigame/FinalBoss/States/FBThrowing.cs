using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boss State/throw", fileName = "new Throwing")]
public class FBThrowing : FBState
{
    [SerializeField] float force;
    Rigidbody chair;
    bool isThrowed;
    public override void Init(FinalBossController _controller)
    {
        _controller.transform.LookAt(_controller.PlayerRef.position);

        chair = PoolingManager.Instance.GetPooledObject("Chair").GetComponent<Rigidbody>();
        chair.transform.parent = _controller.chairP;
        _controller.Animator.SetTrigger("throw");

        chair.transform.localPosition = Vector3.zero;
        chair.transform.rotation = Quaternion.Euler(-168.975f, 20.825f, 3.589005f);
        isThrowed = false;

        _dir = new Vector3(0f, .8f, 1);
    }
    public override void OnUpdate(FinalBossController _controller)
    {
        if(!isThrowed)
            chair.transform.localPosition = Vector3.zero;
    }
    public override void OnAnimFinish(FinalBossController _controller)
    {
        _controller.ChangeState(_controller.walkState);
    }
    public override void OnMiddleAnim(FinalBossController _controller)
    {
        chair.transform.rotation = Quaternion.Euler(.0f, .0f, .0f);
        //_controller.Chair.transform.parent = _controller.ChairParent;
        chair.transform.position= Vector3.zero;
        chair.gameObject.SetActive(true);
    }
    public override void Throw(FinalBossController _controller)
    {
        chair.velocity = Vector3.zero;
        chair.AddForce(_dir * force, ForceMode.Impulse);
        chair.transform.parent = null;
        isThrowed = true;
        //Debug.Log("throw");
    }
}
