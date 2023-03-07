using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BShotCanvas : MonoBehaviour
{
    [Header("Text References")] [SerializeField]
    public TMP_Text firstShot;
    public TMP_Text secondShot; 
    public TMP_Text total;

    [Header("Parameters Refecence")] [SerializeField]
    BBowlingShot _parameters;
    #region Getters && Setters
    public BBowlingShot Parameters { get { return _parameters; } }
    #endregion
    private void Start()
    {
        _parameters.Init(this);
    }

    public void SetParametersToText()
    {
        firstShot.text = _parameters.firstShot.ToString();
        secondShot.text = _parameters.secondShot.ToString();
        total.text = (_parameters.firstShot + _parameters.secondShot).ToString();
    }
}
