using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigamesManager : MonoBehaviour
{
    // 24/02/2023 Lluís Capó

    [SerializeField] BStateController bowling;

    #region Bowling
    public void StartBowling() 
    {
        /* Poner aquí todo tipo de efectos de particulas y cualquier cosa relacionada
           con el inicio de la bolera, recomendación hacer el SerActive(true) con una coroutine */
        bowling.gameObject.SetActive(true);
    }
    public void StopBowling() 
    {
        /* Poner aquí todo tipo de efectos de particulas y cualquier cosa relacionada
           con el final de la bolera, recomendación hacer el SerActive(false) con una coroutine */
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
}
