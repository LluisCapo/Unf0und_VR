using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBowlBehavior : MonoBehaviour
{
    //07/02/2023 Llu�s Cap�

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
        Debug.Log("bolo ca�do");
    }
}
