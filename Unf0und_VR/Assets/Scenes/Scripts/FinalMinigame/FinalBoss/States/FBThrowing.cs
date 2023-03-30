using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boss State/throw", fileName = "new Throwing")]
public class FBThrowing : FBState
{
    [SerializeField] float force;
    bool isThrowed;
    public override void Init(FinalBossController _controller)
    {
        _controller.Animator.SetTrigger("throw");
        _controller.Chair.transform.localPosition = Vector3.zero;
        _controller.Chair.transform.rotation = Quaternion.Euler(-168.975f, 20.825f, 3.589005f);
        isThrowed = false;

        //Obtain direction towards player
        _dir = (_controller.transform.position - _controller.PlayerRef.transform.position).normalized; 
    }
    public override void OnUpdate(FinalBossController _controller)
    {
        if(!isThrowed)
            _controller.Chair.transform.localPosition = Vector3.zero;
    }
    public override void OnAnimFinish(FinalBossController _controller)
    {
        _controller.ChangeState(_controller.walkState);
    }
    public override void OnMiddleAnim(FinalBossController _controller)
    {
        _controller.Chair.gameObject.SetActive(true);
    }
    public override void Throw(FinalBossController _controller)
    {
        GameObject _refChair = Instantiate(_controller.ChairGO, new Vector3(_controller.transform.position.x, _controller.transform.position.y + 1.7f, _controller.transform.position.z), _controller.transform.rotation, _controller.transform);
        //Debug.Break();
        _refChair.layer = 13;
        _refChair.GetComponent<Rigidbody>().AddForce(_dir * force, ForceMode.Impulse);
        //_controller.Chair.AddForce(_dir * force, ForceMode.Impulse);
        //isThrowed = true;
        //Debug.Log("throw");
    }
}
