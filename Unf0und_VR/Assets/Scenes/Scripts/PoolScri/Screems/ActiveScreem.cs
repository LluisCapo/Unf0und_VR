using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActiveScreem : MonoBehaviour
{
    public UnityEvent _playEvent;
    private void OnTriggerEnter(Collider other)
    {
        _playEvent.Invoke();
    }
}
