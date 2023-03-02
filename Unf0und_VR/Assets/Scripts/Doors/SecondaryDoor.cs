using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SecondaryDoor : MonoBehaviour
{
    // 01/03/2023 Lluís Capó

    [SerializeField] ClosingDoorBehavior controller;

    private void OnTriggerEnter(Collider other)
    {
        controller.OnEventCall();
        gameObject.SetActive(false);
    }
}
