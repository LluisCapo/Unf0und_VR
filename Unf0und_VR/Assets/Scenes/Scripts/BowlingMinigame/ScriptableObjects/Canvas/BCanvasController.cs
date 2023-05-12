using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCanvasController : MonoBehaviour
{
    //Lluís Capó

    [Header("Shots List")]
    [SerializeField]
    List<BShotCanvas> shotList;
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
        Debug.Log("shot ---> " + _index);
        _index++;
        if(_index < 5)
        {
            _currentShot = shotList[_index];
            Debug.LogError("NextShot");
        }
        else
        {
            GameManager.Instance.MinigamesManager.StopBowling();
            //int _score = 0;
            //foreach (BShotCanvas shot in shotList) _score += int.Parse(shot.total.text);

            //GameManager.Instance.BDManager.CurrentGameInfo.score[0] = _score.ToString();
            //GameManager.Instance.MinigamesManager.StopBowling();
        }
    }
}
