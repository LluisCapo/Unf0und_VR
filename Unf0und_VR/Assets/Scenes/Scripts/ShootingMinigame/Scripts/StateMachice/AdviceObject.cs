using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class AdviceObject : MonoBehaviour
{
    public GameObject reference;

    //public delegate void RNAdvice(Transform _pos);
    //public event RNAdvice ;

    public event Action<Transform> ReturnAdvice = delegate { };

    private void OnEnable()
    {
    }




    private void ReturnMessage()
    {
        ReturnAdvice.Invoke(transform);
    }

}
