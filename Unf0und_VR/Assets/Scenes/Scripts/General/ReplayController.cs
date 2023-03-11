using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReplayController: MonoBehaviour
{
    //11/03/2023 Lluís Capó

    #region
    private static ReplayController _instance;
    public static ReplayController Instance
    {
        get
        { 
            if (_instance == null)
                _instance = FindObjectOfType<ReplayController>();
            return _instance; 
        }
    }
    #endregion

    [Header("Replay Parameters")]
    [SerializeField] GameObject player;
    [SerializeField] Transform playerSpawn;
    [SerializeField] Transform detecters;

    public UnityEvent Replay;

    private void Start()
    {
        OnReplay();
    }

    public void OnReplay()
    {
        player.transform.position = playerSpawn.position;
        player.transform.rotation = playerSpawn.rotation;

        RenderSettings.fog = true;

        foreach (Transform t in detecters)
            t.gameObject.SetActive(true);

        Replay.Invoke();
    }
}
