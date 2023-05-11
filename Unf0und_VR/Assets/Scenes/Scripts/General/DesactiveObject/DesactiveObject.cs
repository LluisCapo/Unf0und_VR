using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactiveObject : MonoBehaviour
{
    public GameObject _object;

    public void DesactiveO()
    {
        _object.SetActive(false); 
    }
}
