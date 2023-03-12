using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBallInstantiate : MonoBehaviour
{
    // 02/02/2023 --> Lluís Capó
    [SerializeField] Transform spawnPoint;
    [SerializeField] float force;
    Vector3 _dir;
    int numBalls;
    List<GameObject> ballList;

    private void Start()
    {
        ballList = new List<GameObject>();
        Init();
    }

    private void Init()
    {
        _dir = new Vector3(1.0f, .0f, .0f);
        numBalls = 0;

        for (int i = 0; i < 3; i++)
        {
            GameObject ball = PoolingManager.Instance.GetPooledObject("bowlingBall");
            ball.transform.position = spawnPoint.position;
            ball.SetActive(true);
            ball.GetComponent<Rigidbody>().AddForce(_dir * force, ForceMode.Impulse);
            ballList.Add(ball);
            numBalls++;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            GameObject a = PoolingManager.Instance.GetActiveObject("bowlingBall")[0];
            numBalls--;
            a.SetActive(false);
            SapawnBall();
        }
    }

    private void SapawnBall()
    {
        GameObject ball = PoolingManager.Instance.GetPooledObject("bowlingBall");
        ball.transform.position = spawnPoint.position;
        ball.SetActive(true);
        ball.GetComponent<Rigidbody>().AddForce(_dir * force, ForceMode.Impulse);
        numBalls++;
    }
}
