using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class BasketManager : MonoBehaviour
{
    // 3/3/2023 Lluís Capó

    public UnityEvent BasketStart;
    public UnityEvent BasketStop;
    [SerializeField] Transform basketLights;
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
        BasketStart.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            OnScoreABasket();
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
        Debug.Log("Basket out");
    }

    public void TimeOut()
    {
        Debug.Log("Time out");

        foreach (Light light in lLights)
            light.intensity = .01f;

        _score = 0;
    }
}
