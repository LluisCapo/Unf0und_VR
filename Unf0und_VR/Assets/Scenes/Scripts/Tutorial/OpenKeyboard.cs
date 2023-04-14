using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKeyboard : MonoBehaviour
{
    private TouchScreenKeyboard overlayKeyboard;
    public static string inputText = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void FOpenkeyboard()
    {
        //Debug.Log("Sale el teclado");
        //overlayKeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        //if (overlayKeyboard != null)
        //    inputText = overlayKeyboard.text;

        TouchScreenKeyboard.Open("");
    }
}
