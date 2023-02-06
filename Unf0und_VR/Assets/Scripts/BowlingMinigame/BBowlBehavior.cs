using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBowlBehavior : MonoBehaviour
{
    public bool _isDropped;

    #region Getters && Setters
    public bool IsDropped { get { return _isDropped; } set { _isDropped = value; } }
    #endregion

    public void Init()
    {
        _isDropped = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        _isDropped = true;
        Debug.Log("bolo caído");
    }
}
