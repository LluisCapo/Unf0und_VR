using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PABLO RUIZ CALVO [06/03/2023]

public class TransitionalCheckerBehaviour : MonoBehaviour
{
    [SerializeField] 
    GameObject parkObject;

    [SerializeField]
    GameObject firstLvlObject;

    [SerializeField]
    GameObject sandboxAudioSource;

    private void OnTriggerEnter(Collider other)
    {
        parkObject.SetActive(false);
        sandboxAudioSource.SetActive(false);
        firstLvlObject.SetActive(true);
        AudioManager.Instance.PlaySound("crash");
        gameObject.SetActive(false);
    }
}
