using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSoundPlayerIndividual : MonoBehaviour
{
    [SerializeField]
    private string soundName;

    private void OnCollisionEnter()
    {
        Sound();
        gameObject.SetActive(false);
    }
    public void Sound()
    {
        AudioManager.Instance.PlaySoundOnPosition(soundName, gameObject.transform.position);
    }
}
