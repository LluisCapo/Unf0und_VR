using Autohand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 27/02/2023 Llu�s Cap�
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
    [SerializeField] MinigamesManager minigames; //Ported in from MinigamesManager
    [SerializeField] GameObject directionalLight; //Ported in from the directional light in the park scene
    [Header("Camera Efect"), SerializeField] GameObject closeEyes; //Ported in from the camera child
    [Header("Levels"), SerializeField]
    public GameObject parkObject;
    public GameObject firstLvlObject;

    float playerVelocity;
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
        closeEyes.SetActive(true);
        playerVelocity = autoHandPlayer.maxMoveSpeed;
        autoHandPlayer.maxMoveSpeed = 0;
        autoHandPlayer.GetComponent<Rigidbody>().velocity = Vector3.zero;
        StartCoroutine(waitToChange());
    }
    IEnumerator waitToChange()
    {
        yield return new WaitForSeconds(1.5f);
        autoHandPlayer.maxMoveSpeed = playerVelocity;
        parkObject.SetActive(false);
        firstLvlObject.SetActive(true);
        RenderSettings.fog = false;
        directionalLight.SetActive(false);
    }
}
