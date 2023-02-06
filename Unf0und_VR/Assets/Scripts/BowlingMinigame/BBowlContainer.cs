using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBowlContainer : MonoBehaviour
{
    //02/02/2023 Lluís Capó
    List<Transform> bowlsPoints;
    List<BBowlBehavior> bowlsList;
    private void Start()
    {
        CreatePoints();
        InstantiateAllBowls();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            DesactiveAllBowls();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            InstantiateNonDroppedBowls();
        }
    }

    private void CreatePoints()
    {
        bowlsPoints = new List<Transform>();

        foreach (Transform a in transform) bowlsPoints.Add(a);
        //Debug.Log(bowlsPoints.Count);
    }
    private void InstantiateAllBowls()
    {
        bowlsList = new List<BBowlBehavior>();
        for(int i = 0; i < 10; i++)
        {
            GameObject _bowl = PoolingManager.Instance.GetPooledObject("bowlingBowl");
            _bowl.transform.position = bowlsPoints[i].position;
            BBowlBehavior _bowlBehavior = _bowl.GetComponent<BBowlBehavior>();
            _bowlBehavior.Init();
            bowlsList.Add(_bowlBehavior);
            _bowl.SetActive(true);
        }
    }
    private void DesactiveAllBowls()
    {
        Debug.Log("Desactivar bolas");
        foreach (BBowlBehavior _current in bowlsList) _current.gameObject.SetActive(false);
    }
    private void InstantiateNonDroppedBowls()
    {
        Debug.Log("instanciar bolas");
        foreach(BBowlBehavior _current in bowlsList)
        {
            if (!_current.IsDropped) _current.gameObject.SetActive(true);
        }
    }
}
