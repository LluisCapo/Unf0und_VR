using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STimerDisable : MonoBehaviour
{
    [SerializeField]
    private float _timeToReach = 5f;


    private void OnEnable()
    {
        StartCoroutine(UnableObject());
    }

    IEnumerator UnableObject()
    {
        yield return new WaitForSeconds(_timeToReach);
        gameObject.SetActive(false);
    }
}
