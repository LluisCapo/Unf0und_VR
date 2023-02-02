using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBowlContainer : MonoBehaviour
{
    //02/02/2023 Lluís Capó
    List<Transform> bowlsPoints;
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        bowlsPoints = new List<Transform>();

        foreach (Transform a in transform) bowlsPoints.Add(a);
        Debug.Log(bowlsPoints.Count);
    }
}
