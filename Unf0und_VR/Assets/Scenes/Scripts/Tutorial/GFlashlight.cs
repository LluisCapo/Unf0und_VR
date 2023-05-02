using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GFlashlight : MonoBehaviour
{
    private GameObject _light;


    private void Awake()
    {
        //_light = transform.GetChild(transform.childCount).GetChild(0).gameObject;
    }

    public void LigthFunction()
    {
        //_light.gameObject.SetActive(!_light.gameObject.activeInHierarchy);
    }
}
