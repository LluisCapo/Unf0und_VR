using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DesactiveObject : MonoBehaviour
{
    public UnityEvent _object;

    public void EventInvoke()
    {
        _object.Invoke(); 
    }

    private void OnTriggerEnter()
    {
        _object.Invoke();
    }
}
