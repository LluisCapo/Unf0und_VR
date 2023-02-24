using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

    [Header("Minigames Events")]
    public UnityEvent StartBowling;
    public UnityEvent stopBowling;
}
