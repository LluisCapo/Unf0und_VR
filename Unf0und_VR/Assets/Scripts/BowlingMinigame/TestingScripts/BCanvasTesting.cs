using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BCanvasTesting : MonoBehaviour
{
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

    [SerializeField] TMP_Text stateText;
    string defaultString;
    private void Start()
    {
        defaultString = stateText.text;
    }
    public void SetCurrentStateText(string _state)
    {
        stateText.text = defaultString + _state;
    }
}
