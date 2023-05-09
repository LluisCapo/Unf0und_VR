using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] TMP_Text optionsText, volumeText;
    [SerializeField] TMP_Dropdown languageList;
    [SerializeField] LanguageBehavior spanish, english;
    bool activeInvoke = false;



    private void Start()
    {
        gameObject.layer = 30;
        //ChangeValue();
        SetClockTexts();
    }

    public void InitCanvas()
    {
        canvas.SetActive(!canvas.activeInHierarchy);
    }

    public void ChangeValue(int value) 
    {
        if (value == 0)
             LanguageManager.Instance.currentLanguage = spanish;
        else
             LanguageManager.Instance.currentLanguage = english;


        SetClockTexts();
    }
    

    public void SetClockTexts()
    {
        optionsText.text = LanguageManager.Instance.currentLanguage.menuTexts.optionsText;
        volumeText.text = LanguageManager.Instance.currentLanguage.menuTexts.volumeText;
    }

    //private void OpenCanvas()
    //{
    //    //if (!canvas.activeInHierarchy)
    //    //{
    //    //    Debug.Log("entra canvas"); //canvas.SetActive(true);
    //    //    StartCoroutine(HandClock());
    //    //    _delay = .0f;

    //    //}
    //    //else
    //    //{
    //    //    //canvas.SetActive(false);
    //    //    _delay = .0f;
    //    //}
    //    if(!activeInvoke)
    //    {
    //        Invoke("ActiveCanvas", 0);
    //        activeInvoke = true;
    //    }


    //}

    //private void ActivateCanvas()
    //{

    //    activeInvoke= false;
    //}
}
