using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeadController : MonoBehaviour
{
    public UnityEvent DeadEvent;
    private void OnTriggerEnter(Collider other)
    {
        DeadEvent.Invoke();
    }
}
