using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    // 01/03/2023 Llu�s Cap�

    [SerializeField] ClosingDoorBehavior controller;


    private void OnTriggerEnter(Collider other)
    {
        controller.OnFirstEventCall();
        GetComponent<BoxCollider>().enabled = false;
    }
}
