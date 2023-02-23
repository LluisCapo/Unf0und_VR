using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] float secondsToInteract;
    float _delay;
    private void Start()
    {
        _delay = .0f;
    }
    private void OnTriggerStay(Collider other)
    {
        if (!canvas.activeInHierarchy)
        {
            if ((_delay += Time.deltaTime) >= secondsToInteract)
                Debug.Log("sale canvas"); //canvas.SetActive(true);
        }
        else
            canvas.SetActive(false);

    }
    private void OnTriggerExit(Collider other)
    {
        _delay = 0;
    }
}
