using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBowlBehavior : MonoBehaviour
{
    //07/02/2023 Lluís Capó

    public bool _isDropped;

    #region Getters && Setters
    public bool IsDropped { get { return _isDropped; } set { _isDropped = value; } }
    #endregion

    public void Init()
    {
        _isDropped = false;
        transform.localRotation = Quaternion.Euler(-90, 0, 0);

        GetComponent<Rigidbody>().velocity *= 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        _isDropped = true;
    }
}
