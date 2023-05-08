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
        _BarrerCollider.enabled = false;
    }



    public void EnableCollision()
    { 
        _BarrerCollider.enabled = true; 
    }
    public void DisableCollider()
    {
        _BarrerCollider.enabled = false;
    }


    public void Open()
    {
        _anim.SetInteger("state", 1);
    }
    public void Close()
    {
        _anim.SetInteger("state", 0);
    }
    private void OnTriggerExit(Collider other)
    {
        Close();
        DisableCollider();
        StartMinigame.Invoke();
    }



}
