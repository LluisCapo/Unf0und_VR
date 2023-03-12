using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] float secondsToInteract;
    [SerializeField] BoxCollider boxCollider;
    bool activeInvoke = false;



    private void Start()
    {
        gameObject.layer = 30;
    }

    private void OnTriggerExit(Collider other)
    {
        Invoke("OpenCanvas", 0);
    }

    private void OpenCanvas()
    {
        //if (!canvas.activeInHierarchy)
        //{
        //    Debug.Log("entra canvas"); //canvas.SetActive(true);
        //    StartCoroutine(HandClock());
        //    _delay = .0f;

        //}
        //else
        //{
        //    //canvas.SetActive(false);
        //    _delay = .0f;
        //}
        if(!activeInvoke)
        {
            Invoke("ActiveCanvas", 1);
            activeInvoke = true;
        }
            
            
    }

    private void ActiveCanvas()
    {
        canvas.SetActive(!canvas.activeInHierarchy);
        activeInvoke= false;
    }
}
