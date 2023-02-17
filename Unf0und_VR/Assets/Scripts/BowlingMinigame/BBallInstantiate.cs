using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBallInstantiate : MonoBehaviour
{
    // 02/02/2023 --> Lluís Capó
    [SerializeField] Transform spawnPoint;
    [SerializeField] float force;
    Vector3 _dir;
    [SerializeField] GameObject _ball;
    [SerializeField] Rigidbody _ballRB;

    private void Start()
    {
        Init();
        _ballRB = _ball.GetComponent<Rigidbody>();
    }

    private void Init()
    {
        _dir = new Vector3(1.0f, .0f, .0f);
    }

    public void SapawnBall()
    {
        //_ball = PoolingManager.Instance.GetPooledObject(prefabPoolingName);
        _ball.transform.position = spawnPoint.position;
        _ball.SetActive(true);
        //_ball.GetComponent<Rigidbody>()
        _ballRB.AddForce(_dir * force, ForceMode.Impulse);
    }

    public void RemoveBall()
    {
        _ball.GetComponent<Rigidbody>().velocity *= 0;
        _ball.SetActive(false);
    }
}
