using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SScoreBehaviour : MonoBehaviour
{
    [SerializeField]
    private int _score;

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

}
