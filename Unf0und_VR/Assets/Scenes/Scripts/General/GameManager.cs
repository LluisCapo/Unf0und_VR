using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 27/02/2023 Lluís Capó
    #region Singleton && Awake
    private static GameManager _instance = null;
    public static GameManager Instance => _instance;
    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this);
    }
    #endregion

    #region Variables
    [SerializeField] MinigamesManager minigames; //Ported in from MinigamesManager
    [SerializeField] GameObject directionalLight; //Ported in from the directional light in the park scene
    [Header("Levels"), SerializeField]
    public GameObject parkObject;
    public GameObject firstLvlObject;
    #endregion

    #region Getters && Setters
    public MinigamesManager MinigamesManager { get { return minigames; } set { minigames = value; } }
    #endregion 

    public void SetInParkScene()
    {
        parkObject.SetActive(true);
        firstLvlObject.SetActive(false);
        RenderSettings.fog = true;
        directionalLight.SetActive(true);
    }
    public void ChangeSceneParkToGame()
    {
        parkObject.SetActive(false);
        firstLvlObject.SetActive(true);
        RenderSettings.fog = false;
        directionalLight.SetActive(false);
    }
}
