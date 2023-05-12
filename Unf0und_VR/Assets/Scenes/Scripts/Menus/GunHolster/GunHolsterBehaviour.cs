using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHolsterBehaviour : MonoBehaviour
{
    // 16/02/2023 Pablo Ruiz Calvo

    [SerializeField]
    private GameObject cameraReference;
    public float desplacement;

    private void Update()
    {
        transform.position= cameraReference.transform.position + cameraReference.transform.forward * desplacement;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 5.0f);
    }
}
