using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // 01/03/2023 Llu�s Cap�
    public void PlayClosedSound() { AudioManager.Instance.PlaySoundOnPosition("closeDoorSFX", transform.position); }
}
