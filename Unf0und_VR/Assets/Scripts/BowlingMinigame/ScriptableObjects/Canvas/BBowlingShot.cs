using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Canvas Shot", fileName = "new Parameters")]
public class BBowlingShot : ScriptableObject
{
    // 07/02/2023
    BShotCanvas _canvas;

    [Header("Shot parameters")]
    [SerializeField]
    public int firstShot; 
    public int secondShot;
    public void Init(BShotCanvas _newCanvas)
    {
        _canvas = _newCanvas;
        firstShot = 0;
        secondShot = 0;
        _canvas.SetParametersToText();
    }

    public void UpdateFirstShoot(int _firstShot)
    {
        firstShot = _firstShot;
        _canvas.SetParametersToText();
    }

    public void UpdateSecondShot(int _secondShot)
    {
        secondShot = _secondShot - firstShot;
        _canvas.SetParametersToText();
    }
}
