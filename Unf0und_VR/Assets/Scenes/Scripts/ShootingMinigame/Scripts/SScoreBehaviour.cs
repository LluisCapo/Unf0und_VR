using DotLiquid.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SScoreBehaviour : MonoBehaviour
{
    [SerializeField]
    private int _score;
    [SerializeField]
    BDEncryption bDEncryption;
    [SerializeField]
    BDInfoToInsert playerInfo;

    public UnityEvent<string> UpdateScore;

    private void Start()
    {
        _score = 0;
    }


    public void RecieveScore(int newScore)
    {
        _score += newScore;
        UpdateScore.Invoke(_score.ToString());
    }

    public void SendScore()
    {
        playerInfo.score = _score.ToString();
        bDEncryption.StartBDCall();
    }
    
}
