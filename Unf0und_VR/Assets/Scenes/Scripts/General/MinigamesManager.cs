using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigamesManager : MonoBehaviour
{
    // 24/02/2023 Lluís Capó

    [SerializeField] BStateController bowling;
    [SerializeField] List<BasketManager> basketManager;

    #region Bowling
    [SerializeField, Header("Bowling objects to disable")]
    List<GameObject> objectsToDisable;

    [SerializeField, Header("Beta habitation (not in the final game)")]
    GameObject betaHabitation;
    public void StartBowling() 
    {
        Debug.Log("Start Bowling");
        /* Poner aquí todo tipo de efectos de particulas y cualquier cosa relacionada
           con el inicio de la bolera, recomendación hacer el SerActive(true) con una coroutine */
        bowling.gameObject.SetActive(true);
    }
    public void StopBowling()
    {
        //this runs when the player are in the +5th shot

        bowling.PlaneController.isUP = true; //mirar si eso funciona o es false
        bowling.BowlContainer.DesactiveAllBowls();

        foreach (GameObject obj in objectsToDisable) { obj.SetActive(false); }
        betaHabitation.SetActive(true);

        //GameManager.Instance.StartBDServer();

        bowling.gameObject.SetActive(false);
    }
    #endregion

    #region Shooting
    public void StartShootingMinigame()
    {
        // Que Raúl aquí ponda todo lo relacionado con el inicio del juego del disparo
    }

    public void StopShootingMinigame()
    {
        // Que Raúl aquí ponda todo lo relacionado con el final del juego del disparo
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
