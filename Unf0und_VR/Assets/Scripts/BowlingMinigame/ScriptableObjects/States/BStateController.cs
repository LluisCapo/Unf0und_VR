using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BStateController : MonoBehaviour
{
    [Header("First State")] [SerializeField]
    BState firstState;
    BState _currentState;

    [Header("Bowl Container Reference")] [SerializeField]
    BBowlContainer bowlContainerRef;

    [Header("Canvas Reference")] [SerializeField]
    BCanvasController canvasControllerRef;

    #region Getters && Setters
    public BBowlContainer BowlContainer { get { return bowlContainerRef; } }
    public BCanvasController CanvasReference { get { return canvasControllerRef; } }
    #endregion

    private void Start()
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
        Debug.Log("Corutine Started");
        yield return new WaitForSeconds(_seconds);
        _state.OnFinishWaiting();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ha entrado");
        _currentState.OnTrigerEnter(other, this);
    }
}
