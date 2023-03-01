using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public void PlayClosedSound()
    {
        //AudioManager.Instance.PlaySound("closeDoorSFX");
        AudioManager.Instance.PlaySoundOnPosition("closeDoorSFX", transform.position);
        Debug.Log("Closed Sound");
    }
}
