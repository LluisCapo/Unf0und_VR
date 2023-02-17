using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BStateController : MonoBehaviour
{

    #region Inspector References
    [Header("First State")] [SerializeField]
    BState firstState;
    public BState _currentState;

    [Header("Bowl Container Reference")] [SerializeField]
    BBowlContainer bowlContainerRef;

    [Header("Canvas Reference")] [SerializeField]
    BCanvasController canvasControllerRef;

    //[Header("Ball Reference")] [SerializeField]
    //BBallController ballReference;

    [Header("Plane Reference")] [SerializeField]
    BPlaneBehavior planeBehavior;

    [Header("Ball instantiate Reference")]
    [SerializeField]
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

        //
        BCanvasTesting.Instance.SetCurrentStateText(_currentState.name);
        //
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            ChangeState(b);
        _currentState.OnUpdate(this);
    }

    public void ChangeState(BState _newState)
    {
        _currentState = _newState;
        _currentState.Init(this);

        //
        BCanvasTesting.Instance.SetCurrentStateText(_currentState.name);
        //
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
