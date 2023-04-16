using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MButtonsMenu : MonoBehaviour
{
    public void NweGame()
    {
        SceneManager.LoadScene("Beta");
    }

    public void Exit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                         Application.Quit();
        #endif
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Raul");
    }
}
