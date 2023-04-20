using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSoundPlayerIndividual : MonoBehaviour
{
    public string _nameSound;
    public GameObject _referencePos;
    private void Start()
    {
        if (!_referencePos)
        {
            if (!transform.GetChild(0))
                _referencePos = transform.GetChild(0).gameObject;
            else
                _referencePos = gameObject;
        }
            
    }
    private void OnTriggerEnter(Collider other)
    {
        AudioManager.Instance.PlaySoundOnPosition(_nameSound, _referencePos.transform.position);
        gameObject.SetActive(false);
    }

}
