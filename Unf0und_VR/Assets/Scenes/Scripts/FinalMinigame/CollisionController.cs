using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionController : MonoBehaviour
{
    [Header("Unity Events")]
    public UnityEvent ControlTime;

    private void OnTriggerEnter(Collider other)
    {
        ControlTime.Invoke();
        other.gameObject.layer = 0;
        

    }
}
