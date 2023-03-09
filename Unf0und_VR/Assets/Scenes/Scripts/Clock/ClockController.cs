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

    public void InitCanvas()
    {
        Debug.LogWarning("Aaron hueles fatal");
        canvas.SetActive(!canvas.activeInHierarchy);
    }

    //private void OpenCanvas()
    //{
    //    //if (!canvas.activeInHierarchy)
    //    //{
    //    //    Debug.Log("entra canvas"); //canvas.SetActive(true);
    //    //    StartCoroutine(HandClock());
    //    //    _delay = .0f;

    //    //}
    //    //else
    //    //{
    //    //    //canvas.SetActive(false);
    //    //    _delay = .0f;
    //    //}
    //    if(!activeInvoke)
    //    {
    //        Invoke("ActiveCanvas", 0);
    //        activeInvoke = true;
    //    }
            
            
    //}

    //private void ActivateCanvas()
    //{
        
    //    activeInvoke= false;
    //}
}
