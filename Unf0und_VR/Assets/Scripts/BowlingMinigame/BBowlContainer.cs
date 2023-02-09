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
        Init();
    }

    public void Init()
    {
        CreatePoints();
        bowlsList = new List<BBowlBehavior>();
        for (int i = 0; i < 10; i++)
        {
            GameObject _bowl = PoolingManager.Instance.GetPooledObject("bowlingBowl");
            _bowl.transform.position = bowlsPoints[i].position;
            BBowlBehavior _bowlBehavior = _bowl.GetComponent<BBowlBehavior>();
           // _bowlBehavior.Init();
            bowlsList.Add(_bowlBehavior);
            _bowl.SetActive(true);
        }
    }

    public void CreatePoints()
    {
        bowlsPoints = new List<Transform>();

        foreach (Transform a in transform) bowlsPoints.Add(a);
    }
    public void PositioningAllBowls()
    {
        for (int i = 0; i < 10; i++)//foreach (BBowlBehavior _current in bowlsList)
        {
            /*_current*/bowlsList[i].transform.position = bowlsPoints[i].position;
            /*_current*/
            bowlsList[i].Init();
            /*_current*/
            bowlsList[i].gameObject.SetActive(true);
        }
    }
    public void DesactiveAllBowls()
    {
        Debug.Log("Desactivar bolas");
        foreach (BBowlBehavior _current in bowlsList)
        {

            //_current.gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
            _current.gameObject.SetActive(false);
        }
    }
    public void PositioningActiveBowls()
    {
        foreach(BBowlBehavior _current in bowlsList) if (!_current.IsDropped) _current.gameObject.SetActive(true);
    }
    public void ResetBowl()
    {
        foreach (BBowlBehavior _currentBowl in bowlsList) _currentBowl.Init();
    }

    public int CountNonDroppedBowls()
    {
        int index = 0;
        foreach (BBowlBehavior _current in bowlsList)
        {
            if (!_current.IsDropped) index++;
        }

        return index;
    }
}
