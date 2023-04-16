using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CallFunctionChilld : MonoBehaviour
{
    public UnityEvent callFuntion;
    public void CallChilldFunction()
    {
        callFuntion.Invoke();
    }
}
