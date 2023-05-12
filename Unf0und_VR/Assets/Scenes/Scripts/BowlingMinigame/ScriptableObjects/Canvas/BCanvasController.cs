using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BCanvasController : MonoBehaviour
{
    //Lluís Capó

    [Header("Shots List")]
    [SerializeField]
    List<BShotCanvas> shotList;
    [SerializeField] TMP_Text totalScore;
    public int _index;
    BShotCanvas _currentShot;
    #region Getters && Setters
    public BShotCanvas CurrentShot { get { return _currentShot; } }
    #endregion
    private void Start()
    {
        _index = 0;
        _currentShot = shotList[_index];
    }
    public void NextShot()
    {
        Debug.LogError("I'm in --> " + _currentShot.name);
        if(_index++ < 4)
        {
            Debug.LogError("I'm going to --> " + _currentShot.name);
            _currentShot = shotList[_index];
        }
        else
        {
            GameManager.Instance.MinigamesManager.StopBowling();
            //int _score = 0;
            //foreach (BShotCanvas shot in shotList) _score += int.Parse(shot.total.text);

            //GameManager.Instance.BDManager.CurrentGameInfo.score[0] = _score.ToString();
            //GameManager.Instance.MinigamesManager.StopBowling();
        }
        UpdateTotalScore();
    }

    void UpdateTotalScore()
    {
        int _score = 0;
        foreach(BShotCanvas shot in shotList) _score += int.Parse(shot.total.text);

        totalScore.text = _score.ToString();
    }
}
