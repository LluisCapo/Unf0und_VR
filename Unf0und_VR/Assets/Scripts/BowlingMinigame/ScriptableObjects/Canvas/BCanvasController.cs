using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCanvasController : MonoBehaviour
{
    [Header("Shots List")]
    [SerializeField]
    List<BShotCanvas> shotList;
    int _index;
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
        _index++;
        _currentShot = shotList[_index];
    }
}
