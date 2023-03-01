using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryDoor : MonoBehaviour
{
    // 01/03/2023 Llu�s Cap�

    [SerializeField] ClosingDoorBehavior controller;

    private void OnTriggerEnter(Collider other)
    {
        controller.OnEventCall();
        gameObject.SetActive(false);
    }
}
