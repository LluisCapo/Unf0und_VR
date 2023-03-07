using Autohand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class BasketManager : MonoBehaviour
{
    // 3/3/2023 Lluís Capó

    #region Inspector

    [Header("Father of the lights object"), SerializeField] 
    Transform basketLights;

    [Header("Light intensity if dosen't score"), SerializeField]
    float noneScoreLightIntensity;

    [Header("Button Component Reference"), SerializeField]
    PhysicsGadgetButton button;

    [Header("Unity Events")]
    public UnityEvent BasketStart;
    public UnityEvent BasketStop;
    #endregion
    List<Light> lLights;
    int _score;

    private void Start()
    {
        lLights = new List<Light>();

        foreach (Transform light in basketLights)
            lLights.Add(light.GetComponent<Light>());

        _score = 0;
    }

    public void StartBasket()
    {
        foreach (Light light in lLights)
            light.intensity = noneScoreLightIntensity;

        button.enabled = false;
        BasketStart.Invoke();
    }

    public void OnScoreABasket()
    {
        if (_score < lLights.Count)
        {
            lLights[_score].intensity = .1f;
            _score++;

            Debug.Log("Basket score ---> " + _score + " / " + lLights.Count);
        }
        else
            BasketStop.Invoke();
    }

    public void OnStopBasket()
    {
        button.enabled = true;
    }

    public void TimeOut()
    {
        Debug.Log("Time out");

        _score = 0;
        OnStopBasket();
    }
}
