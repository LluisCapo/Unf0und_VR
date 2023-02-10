using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBowlBehavior : MonoBehaviour
{
    //07/02/2023 Lluís Capó

    [Header("Normal State")] [SerializeField]
    BBowlingPinState normalState;
    [Header("Pickup State")] [SerializeField]
    BBowlingPinState pickipState;
    BBowlingPinState _currentState;

    public bool _isDropped;
    private Transform _point;

    #region Getters && Setters
    public bool IsDropped { get { return _isDropped; } set { _isDropped = value; } }
    public Transform Point { get { return _point; } set { _point = value; } }
    public BBowlingPinState CurrentState { get { return _currentState; } set { _currentState = value; } }
    #endregion

    public void Init(Transform _newPoint)
    {
        _isDropped = false;
        transform.localRotation = Quaternion.Euler(-90, 0, 0);
        _point = _newPoint;
        GetComponent<Rigidbody>().velocity *= 0;
    }

    private void Start()
    {
        StateToNormal();
    }

    private void Update()
    {
        _currentState.OnUpdate(this);
    }

    public void StateToNormal() { _currentState = normalState; }
    public void StateToPickUp() { _currentState = pickipState; }
    private void OnTriggerEnter(Collider other)
    {
        _isDropped = true;
    }
}
