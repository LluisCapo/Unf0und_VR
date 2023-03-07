using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
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
    [SerializeField] MinigamesManager minigames; 
    #endregion

    #region Getters && Setters
    public MinigamesManager MinigamesManager { get { return minigames; } set { minigames = value; } }
    #endregion 
}
