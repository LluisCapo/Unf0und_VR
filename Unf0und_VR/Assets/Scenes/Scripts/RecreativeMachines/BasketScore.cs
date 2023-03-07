using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketScore : MonoBehaviour
{
    [SerializeField] BasketManager manager;

    private void OnTriggerEnter(Collider other)
    {
        manager.OnScoreABasket();
    }
}
