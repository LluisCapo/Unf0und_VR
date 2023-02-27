using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public void PlayClosedSound()
    {
        AudioManager.Instance.PlaySound("closeDoorSFX");
        Debug.Log("Closed Sound");
    }
}
