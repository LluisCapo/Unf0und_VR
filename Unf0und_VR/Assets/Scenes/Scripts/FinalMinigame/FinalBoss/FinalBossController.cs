using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossController : MonoBehaviour
{
    #region Variables
    [SerializeField] FBState firstState;
    public FBState currentState;

    public Transform pointToWalk1, pointToWalk2;

    Animator _anim;
    MovementBehavior _mvb;
    #endregion

    #region Getters && Setters
    public MovementBehavior Movement { get { return _mvb; } }
    #endregion
    private void Start()
    {
        currentState = firstState;
        currentState.Init(this);

        _anim = GetComponent<Animator>();
        _mvb = GetComponent<MovementBehavior>();
    }

    private void Update()
    {
        currentState.OnUpdate(this);
    }

    public void ChangeState(FBState _newState)
    {
        currentState = _newState;
        currentState.Init(this);
    }
}
