using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Events;

public class SMachineController : MonoBehaviour
{
    [SerializeField, Header("Moving State")] SStateBehavior movingState, movingPlayer;
    [SerializeField, Header("Waiting State")] SStateBehavior waitingState;
    [SerializeField, Header("Pathing")] public List<Transform> _paths = new List<Transform>();
    public Transform PointToGo;
    [Header("Float Parametres")] public float incrementalSpeed, delay, decrementalDelay, distanceDifference;
    [Header("GameObjects Parameters")] public GameObject platform, objective;
    [Header("Transform Parameters")] public Transform camaraReference;
    SStateBehavior currentState;
    MovementBehavior _mvb;
    public Rigidbody rb;
    public UnityEvent OnTimeReaches;

    public MovementBehavior MovementBehavior { get { return _mvb; } }

    void Start()
    {
        rb= GetComponent<Rigidbody>();
        _mvb= GetComponent<MovementBehavior>();
        foreach (Transform _child in transform.parent.GetChild(transform.parent.childCount - 1))
            _paths.Add(_child);
        SetMoving();

    }

    void Update()
    {
        currentState.OnUpdate(this);
    }
    public void SetMoving()
    {
        currentState = movingState;
        currentState.Init(this);
    }
    public void SetPlayer()
    {
        currentState = movingPlayer;
        currentState.Init(this);
    }
    public void SetWaiting()
    {
        currentState = waitingState;
        currentState.Init(this);
    }
    public IEnumerator Wait(float _seconds)
    {
        yield return new WaitForSeconds(_seconds);
        currentState.OnWaitingEnd(this);
    }
}
