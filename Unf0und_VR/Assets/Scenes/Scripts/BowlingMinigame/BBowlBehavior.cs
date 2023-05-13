using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBowlBehavior : MonoBehaviour
{
    //07/02/2023 Lluís Capó

    public bool _isDropped;
    public Transform _point;

    #region Getters && Setters
    public bool IsDropped { get { return _isDropped; } set { _isDropped = value; } }
    public Transform Point { get { return _point; } set { _point = value; } }
    #endregion

    public void Init(Transform _newPoint)
    {
        _isDropped = false;
        transform.localRotation = Quaternion.Euler(-90, 0, 0);
        _point = _newPoint;
        GetComponent<Rigidbody>().velocity *= 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        _isDropped = true;
        Debug.LogWarning("Bolo tirado");
    }
}
