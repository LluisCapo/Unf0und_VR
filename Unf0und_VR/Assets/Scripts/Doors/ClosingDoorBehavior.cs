using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingDoorBehavior : MonoBehaviour
{
    // 27/02/2023 Lluís Capó

    List<Animator> _doors;

    [SerializeField] Animator finalDoor, secondaryDoor;
    private void Start()
    {
        _doors = new List<Animator>();

        foreach (Transform a in transform)
            _doors.Add(a.GetComponent<Animator>());
    }

    public void OnFirstEventCall()
    {
        finalDoor.SetTrigger("close");
        secondaryDoor.gameObject.SetActive(true);
    }

    public void OnEventCall()
    {
        StartCoroutine(CloseDoor());
    }

    IEnumerator CloseDoor()
    {
        for(int i = _doors.Count - 1; i > 0; i -= 2)
        {
            _doors[i].SetTrigger("close");
            _doors[i - 1].SetTrigger("close");
            yield return new WaitForSeconds(.5f);
        }

        yield return new WaitForSeconds(.5f);

        finalDoor.SetTrigger("open");

        Debug.Log("Modificar la luz de arriba y abrir la puerta");
    }
}
