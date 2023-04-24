using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossController : MonoBehaviour
{
    #region Variables
    public FBState walkState, throwingState, goToPlayerState;
    FBState currentState;

    public Transform pointToWalk1, pointToWalk2;

    [SerializeField] Transform playerPosition, chairParent;
    public Transform chairP;
    [SerializeField] Rigidbody chair;
    [SerializeField] RuntimeAnimatorController animator;

    Animator _anim;
    MovementBehavior _mvb;
    Rigidbody _rb;
    #endregion

    #region Getters && Setters
    public MovementBehavior Movement { get { return _mvb; } }
    public Animator Animator { get { return _anim; } }
    public Transform PlayerRef { get { return playerPosition; } }
    public Transform ChairParent { get { return ChairParent; } }
    public Rigidbody Chair { get { return chair; } }
    #endregion
    private void Start()
    {
        _anim = GetComponent<Animator>();
        _mvb = GetComponent<MovementBehavior>();
        _rb = GetComponent<Rigidbody>();

        _anim.runtimeAnimatorController = animator;

        currentState = walkState;
        currentState.Init(this);
    }

    private void Update()
    {
        currentState.OnUpdate(this);

        //
        Testing();
    }

    public void ChangeState(FBState _newState)
    {

        Debug.Log($"Change boss state from ---> {currentState.name} ------ TO ------ {_newState.name}");

        currentState = _newState;
        currentState.Init(this);
    }

    public void StopVelocity()
    {
        _mvb.SetVelocity(0);
        _rb.velocity *= 0;
    }

    public void AnimFinished()
    {
        currentState.OnAnimFinish(this);
    }
    public void MiddleAnim()
    {
        currentState.OnMiddleAnim(this);
    }

    public void ThrowInAnim()
    {
        currentState.Throw(this);
    }

    void Testing()
    {
        if (Input.GetKeyDown(KeyCode.K))
            ChangeState(throwingState);

        if (Input.GetKeyDown(KeyCode.P))
            ChangeState(walkState);

        if (Input.GetKeyDown(KeyCode.L))
            ChangeState(goToPlayerState);
    }
}
