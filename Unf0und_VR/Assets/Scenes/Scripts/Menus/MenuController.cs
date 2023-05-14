using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    [SerializeField] List<Image> menusprites;
    [SerializeField] LanguageBehavior spanish, english;



    private void Start()
    {
        SetMenuSprite();
    }

    public void ChangeValue(int value)
    {
        if (value == 0)
            LanguageManager.Instance.currentLanguage = spanish;
        else
            LanguageManager.Instance.currentLanguage = english;

       // Debug.Log("entra enc hange");


        SetMenuSprite();
    }


    public void SetMenuSprite()
    {
        //for(int i = 0; i < menusprites.Count; i++)
            //menusprites[i].sprite = LanguageManager.Instance.currentLanguage.menuTexts.imgMenu[i];
    }
}
