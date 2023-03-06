using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetecterBehavior : MonoBehaviour
{
    [Header("Event when collide")]
    public UnityEvent whenCollide;

    private void OnTriggerEnter(Collider other)
    {
        whenCollide.Invoke();
        gameObject.SetActive(false);
    }
}
