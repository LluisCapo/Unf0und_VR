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

    [SerializeField] List<MeshRenderer> lLights;
    [SerializeField] Material noneScoredMat, scoredMat;
    [SerializeField] Transform ballInstantiate;
    [SerializeField] Rigidbody ballReference;
    int _score;

    private void Start()
    {

        _score = 0;
    }

    public void StartBasket()
    {
        foreach (MeshRenderer light in lLights)
            light.material = noneScoredMat;

        button.enabled = false;
        BasketStart.Invoke();
    }

    public void OnScoreABasket()
    {
        if (_score < lLights.Count)
        {
            AudioManager.Instance.PlaySound("basketScore_SFX");
            lLights[_score].material = scoredMat;
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

    public void SetBallOnPosition()
    {
        ballReference.velocity = Vector3.zero;
        ballReference.transform.position = ballInstantiate.position;
    }

    public void TimeOut()
    {
        Debug.Log("Time out");

        _score = 0;
        OnStopBasket();
    }
}
