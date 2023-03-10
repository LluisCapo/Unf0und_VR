using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BCanvasTesting : MonoBehaviour
{
    // 14/02/2023 Lluís Capó

    #region Singleton
    private static BCanvasTesting _instance;
    public static BCanvasTesting Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<BCanvasTesting>();

            return _instance;
        }
    }
    #endregion

    [SerializeField] TMP_Text stateMachineText;
    [SerializeField] TMP_Text stateBowlPinText;
    string defaulMtString;
    string defaulBtString;
    private void Start()
    {
        defaulMtString = stateMachineText.text;
        defaulBtString = stateBowlPinText.text;
    }
    public void SetCurrentStateText(string _state)
    {
        stateMachineText.text = defaulMtString + _state;
    }
    public void SerCurrentBowlStateText(string _state)
    {
        stateBowlPinText.text = defaulBtString + _state;
    }
}
