using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlatformBeheavour : MonoBehaviour
{
    [SerializeField]
    private GameObject _pathing, _platform;
    [SerializeField]
    private List<Transform> _paths = new List<Transform>();
    [SerializeField]
    private float _delay, _speed, _incrementalSpeed, _decrementalTiming, _platformForce, _incrementalForce, _distance;

    public UnityEvent MovementHasFinished;

    private int _pathInd, _index;
    private Rigidbody _springPlatform;
    public GameObject _player;

    void Start()
    {
        _springPlatform = transform.GetChild(0).gameObject.GetComponent<Rigidbody>();
        _pathInd = 0;
        foreach(Transform _child in transform.parent.GetChild(transform.parent.childCount-1))
        {
            _paths.Add(_child);
        }
        Invoke("NextPath", 2f);
    }

    void Update()
    {
        
    }

    public void NextPath()
    {
        StartCoroutine(MoveToNextZone());
    }


    IEnumerator MoveToNextZone()
    {
        bool firstTime = true;
        //_pathInd < _paths.Count
        while (_speed < 5)
        {
            Vector3 direction = _paths[_pathInd].transform.position - transform.position;
            
            if (direction.magnitude < 0.01f)
            {
                _pathInd = UnityEngine.Random.Range(0, _paths.Count);
                Invoke("UpdateValues", _delay);
                yield return new WaitForSeconds(_delay);
                firstTime = true;
            }
            else
            {
                if(firstTime)
                {
                    _platform.GetComponent<PlatformActing>().Rotate(direction.magnitude, _speed, "CodoZ");
                    firstTime= false;
                }
                    

                transform.position = Vector3.MoveTowards(transform.position, _paths[_pathInd].transform.position, _speed * Time.deltaTime);
                yield return null;
            }
        }
        //MovementHasFinished.Invoke();
        JumpScare();
        yield return null;
    }

    private void UpdateValues()
    {
        _speed += _incrementalSpeed;
        _delay -= _decrementalTiming;
        _springPlatform.AddForce(new Vector3(0,-_platformForce,0), ForceMode.Impulse);
        _platformForce += _incrementalForce;

    }

    IEnumerator JumpScare()
    {
        bool running = true;
        while (running)
        {
            Vector3 direction = _player.transform.position - transform.position;

            if (direction.magnitude < _distance)
            {
                running = false;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
                yield return null;
            }
        }
        yield return null;
    }



}
