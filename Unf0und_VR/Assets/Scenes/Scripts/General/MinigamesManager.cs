using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MinigamesManager : MonoBehaviour
{
    // 24/02/2023 Llu�s Cap�

    [SerializeField] BStateController bowling;
    [SerializeField] List<BasketManager> basketManager;

    #region Bowling
    [SerializeField, Header("Bowling objects to disable")]
    List<GameObject> objectsToDisable;

    [SerializeField, Header("Event bowling end")] UnityEvent onBowlingPas;
    public void StartBowling() 
    {
        Debug.Log("Start Bowling");
        /* Poner aqu� todo tipo de efectos de particulas y cualquier cosa relacionada
           con el inicio de la bolera, recomendaci�n hacer el SerActive(true) con una coroutine */
        bowling.gameObject.SetActive(true);
    }
    public void StopBowling()
    {
        bowling.gameObject.SetActive(false);
        //this runs when the player are in the +5th shot
        GetComponent<BoxCollider>().enabled = false;
        bowling.PlaneController.isUP = true; //mirar si eso funciona o es false
        //bowling.BowlContainer.DesactiveAllBowls();

        foreach (GameObject obj in objectsToDisable) { obj.SetActive(false); }
        onBowlingPas.Invoke();

        //GameManager.Instance.StartBDServer();

        List<GameObject> bowls = PoolingManager.Instance.GetActiveObject("bowlingBowl");
        //foreach (GameObject obj in bowls) { obj.SetActive(false); }
        bowling.BowlContainer.DesactiveAllBowls();
        bowling.BallInstantiate.GetBall().SetActive(false);

        
    }
    #endregion

    #region Shooting
    public void StartShootingMinigame()
    {
        // Que Ra�l aqu� ponda todo lo relacionado con el inicio del juego del disparo
    }

    public void StopShootingMinigame()
    {
        // Que Ra�l aqu� ponda todo lo relacionado con el final del juego del disparo
    }
    #endregion

    public void ResetMinigames() //Esto va a resetear todos los minigames
    {
        bowling.gameObject.SetActive(false);

        foreach(BasketManager _basket in basketManager) 
        {
            _basket.OnStopBasket();
            _basket.BasketStop.Invoke();
        }
    }
}
