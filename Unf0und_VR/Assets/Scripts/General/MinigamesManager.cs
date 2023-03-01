using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigamesManager : MonoBehaviour
{
    // 24/02/2023 Llu�s Cap�

    [SerializeField] BStateController bowling;

    #region Bowling
    public void StartBowling() 
    {
        /* Poner aqu� todo tipo de efectos de particulas y cualquier cosa relacionada
           con el inicio de la bolera, recomendaci�n hacer el SerActive(true) con una coroutine */
        bowling.gameObject.SetActive(true);
    }
    public void StopBowling() 
    {
        /* Poner aqu� todo tipo de efectos de particulas y cualquier cosa relacionada
           con el final de la bolera, recomendaci�n hacer el SerActive(false) con una coroutine */
        bowling.gameObject.SetActive(false);
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
}
