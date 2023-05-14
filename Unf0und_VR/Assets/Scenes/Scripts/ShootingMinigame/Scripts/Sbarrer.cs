using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sbarrer : MonoBehaviour
{
    private BoxCollider _BarrerCollider;
    private Animator _anim;
    public UnityEvent StartMinigame;

    private void OnEnable()
    {
        _BarrerCollider = GetComponent<BoxCollider>();
        _anim = GetComponent<Animator>();
        DisableCollider();
    }



    public void EnableCollision()
    {
        _BarrerCollider.enabled = true; 
    }
    public void DisableCollider()
    {
        _BarrerCollider.enabled = false;
        Destroy(_BarrerCollider);
    }


    public void Open()
    {
        Debug.Log("OpenDoor");
        _anim.SetInteger("state", 1);
        EnableCollision();
    }
    public void Close()
    {
        Debug.Log("CloseDoor");
        _anim.SetInteger("state", 0);
    }
    private void OnTriggerExit(Collider other)
    {
        Close();
        DisableCollider();
        StartMinigame.Invoke();
    }



}
