using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PABLO RUIZ CALVO [06/03/2023]

public class TransitionalCheckerBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject sandboxAudioSource;

    private void OnTriggerEnter(Collider other)
    {
        sandboxAudioSource.SetActive(false);
        AudioManager.Instance.PlaySound("crash");

        GameManager.Instance.ChangeSceneParkToGame();
        gameObject.SetActive(false);
        
    }
}
