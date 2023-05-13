using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GSoundPlayerIndividual : MonoBehaviour
{
    public string _nameSound;
    public GameObject _referencePos;
    public UnityEvent _playAnimationEvent, onFinishAnimation;
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
    private void OnEnable()
    {
        if(gameObject.GetComponent<BoxCollider>())
            gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        _playAnimationEvent.Invoke();
        AudioManager.Instance.PlaySoundAttachedAtPosition(_nameSound, _referencePos);
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    public void StartAnimation()
    {
        _playAnimationEvent.Invoke();
        AudioManager.Instance.PlaySoundOnPosition(_nameSound, _referencePos.transform.position);
    }

    public void OnFinishAnimation()
    {
        onFinishAnimation.Invoke();
    }

}
