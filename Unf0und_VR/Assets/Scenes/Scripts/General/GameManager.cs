using Autohand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
    [Header("AutoHand Player"), SerializeField] AutoHandPlayer autoHandPlayer;
    [SerializeField, Header("Minigames manager")] MinigamesManager minigames; //Ported in from MinigamesManager
    [SerializeField] GameObject directionalLight; //Ported in from the directional light in the park scene
    [Header("Camera Efect"), SerializeField] GameObject closeEyes; //Ported in from the camera child
    [Header("Fog Colors")]
    public Color parkFog;
    public float parkFogDensity;
    public Color gameFog;
    public float gameFogDensity;
    [Header("Data base manager"), SerializeField] BDManager bdManager;
    [Header("Levels"), SerializeField]
    public GameObject parkObject;
    public GameObject firstLvlObject;
    public AudioSource audiorooms;
    public AudioClip cliproom;

    float playerVelocity;
    #endregion

    #region Getters && Setters
    public MinigamesManager MinigamesManager { get { return minigames; } set { minigames = value; } }
    public BDManager BDManager { get { return bdManager; } }
    #endregion 

    private void Start()
    {
        SetInParkScene();
    }

    public void SetInParkScene()
    {
        parkObject.SetActive(true);
        firstLvlObject.SetActive(false);
        RenderSettings.fogColor = parkFog;
        RenderSettings.fogDensity = parkFogDensity;
        RenderSettings.fogMode = FogMode.Exponential;
        directionalLight.SetActive(true);
    }
    public void ChangeSceneParkToGame()
    {
        closeEyes.SetActive(true);
        playerVelocity = autoHandPlayer.maxMoveSpeed;
        autoHandPlayer.maxMoveSpeed = 0;
        autoHandPlayer.GetComponent<Rigidbody>().velocity = Vector3.zero;
        StartCoroutine(waitToChange());
    }

    public void StartBDServer()
    {
        if (bdManager.CurrentGameInfo.email[0].Length > 2)
            bdManager.BDStart();
    }

    IEnumerator waitToChange()
    {
        yield return new WaitForSeconds(1.5f);
        autoHandPlayer.maxMoveSpeed = playerVelocity;
        parkObject.SetActive(false);
        firstLvlObject.SetActive(true);
        RenderSettings.fogColor = gameFog;
        RenderSettings.fogDensity = gameFogDensity;
        RenderSettings.fogMode = FogMode.ExponentialSquared;
        directionalLight.SetActive(false);
        audiorooms.clip = cliproom;
        audiorooms.Play();
    }

    public void TestBowling()
    {
        RenderSettings.fogDensity = .05f;
    }
}
