using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // 01/03/2023 Llu�s Cap�

    public GameObject light;

    public void PlayClosedSound() { AudioManager.Instance.PlaySoundOnPosition("closeDoorSFX", transform.position); }
    public void OpenLight()
    {
        light.SetActive(true);
    }
}
