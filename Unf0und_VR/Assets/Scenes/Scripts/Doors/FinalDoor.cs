using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    // 01/03/2023 Llu�s Cap�

    [SerializeField] ClosingDoorBehavior controller;
    [SerializeField] Animator lightAnim;

    public void StopBlink()
    {
        lightAnim.SetTrigger("noblink");
        lightAnim.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //GetComponent<DoorController>().GetComponent<Light>().SetActive(false);
        lightAnim.SetTrigger("blink");
        controller.OnFirstEventCall();
        GetComponent<BoxCollider>().enabled = false;
    }
}
