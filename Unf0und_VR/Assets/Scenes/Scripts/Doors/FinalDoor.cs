using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    // 01/03/2023 Llu�s Cap�

    [SerializeField] ClosingDoorBehavior controller;
    [SerializeField] Animator lightAnim;
    public AudioSource audioSource;
    public GameObject closeDoorleft;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void StopBlink()
    {
        lightAnim.SetTrigger("noblink");
        audioSource.Stop();
        lightAnim.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //GetComponent<DoorController>().GetComponent<Light>().SetActive(false);
        lightAnim.gameObject.SetActive(true);
        lightAnim.SetTrigger("blink");
        closeDoorleft.SetActive(true);
        audioSource.Play();
        controller.OnFirstEventCall();
        GetComponent<BoxCollider>().enabled = false;
    }
}
