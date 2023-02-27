using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingDoorBehavior : MonoBehaviour
{
    // 27/02/2023 Lluís Capó

    List<Animator> _doors;
    private void Start()
    {
        _doors = new List<Animator>();

        foreach (Transform a in transform)
            _doors.Add(a.GetComponent<Animator>());
    }
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(CloseDoor());
    }

    IEnumerator CloseDoor()
    {
        for(int i = 0; i < _doors.Count; i += 2)
        {
            _doors[i].SetTrigger("close");
            _doors[i + 1].SetTrigger("close");
            yield return new WaitForSeconds(.5f);
        }
    }
}
