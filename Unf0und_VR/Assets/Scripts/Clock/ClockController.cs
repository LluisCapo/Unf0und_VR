using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] float secondsToInteract;
    [SerializeField] BoxCollider boxCollider;
    float _delay;
    private void Start()
    {
        _delay = .0f;
        gameObject.layer = 30;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!canvas.activeInHierarchy)
        {
            if ((_delay += Time.deltaTime) >= secondsToInteract)
            {
                Debug.Log("entra canvas"); //canvas.SetActive(true);
                StartCoroutine(HandClock());
                _delay = .0f;
            }

        }
        else
        {
            //canvas.SetActive(false);
            _delay = .0f;
        }
            

    }
    private IEnumerator HandClock()
    {
        boxCollider.enabled = false;
        yield return new WaitForSeconds(4f);
        boxCollider.enabled = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("sale canvas");
        _delay = 0;
    }
}
