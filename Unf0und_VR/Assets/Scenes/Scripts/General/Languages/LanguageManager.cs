using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    // 16/02/2023 Lluís Capó

    #region Singleton
    private static LanguageManager _instance;
    public static LanguageManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<LanguageManager>();
            return _instance;
        }
    }
    #endregion

    public LanguageBehavior currentLanguage;
}
