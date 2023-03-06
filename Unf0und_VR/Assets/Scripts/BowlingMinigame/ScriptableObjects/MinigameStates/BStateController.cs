using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BStateController : MonoBehaviour
{
    // 07/02/2023 Lluís Capó
    #region Inspector References
    [Header("First State"), SerializeField]
    BState firstState;
    public BState _currentState;

    [Header("Bowl Container Reference"), SerializeField]
    BBowlContainer bowlContainerRef;

    [Header("Canvas Reference"), SerializeField]
    BCanvasController canvasControllerRef;

    [Header("Plane Reference"), SerializeField]
    BPlaneBehavior planeBehavior;

    [Header("Ball instantiate Reference"), SerializeField]
    BBallInstantiate ballInstantiate;

    public bool isSemipleno;
    #endregion

    #region Getters && Setters
    public BBowlContainer BowlContainer { get { return bowlContainerRef; } }
    public BCanvasController CanvasReference { get { return canvasControllerRef; } }
    public BBallInstantiate BallInstantiate { get { return ballInstantiate; } }
    public BPlaneBehavior PlaneController { get { return planeBehavior; } }
    #endregion

    [SerializeField] BContainerUp b;

    private void OnEnable()
    {
        _currentState = firstState;
        _currentState.Init(this);
    }

    private void Update()
    {
        _currentState.OnUpdate(this);
    }

    public void ChangeState(BState _newState)
    {
        _currentState = _newState;
        _currentState.Init(this);
    }
    public void ResetState()
    {
        _currentState = firstState;
        _currentState.Init(this);
    }
    public IEnumerator StartWaiting(BState _state, float _seconds)
    {
        yield return new WaitForSeconds(_seconds);
        _state.OnFinishWaiting();
    }
    private void OnTriggerEnter(Collider other)
    {
        _currentState.OnTrigerEnter(other, this);
    }
}
