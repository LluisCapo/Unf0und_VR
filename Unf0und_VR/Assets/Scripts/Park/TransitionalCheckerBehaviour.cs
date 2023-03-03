using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionalCheckerBehaviour : MonoBehaviour
{
    BoxCollider _floorBxc;

    [SerializeField] GameObject floorCollider;

    void Start()
    {
        _floorBxc = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bing");
        _floorBxc.isTrigger = true;
    }
}
