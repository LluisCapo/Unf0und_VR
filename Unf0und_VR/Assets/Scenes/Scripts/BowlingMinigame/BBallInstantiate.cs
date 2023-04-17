using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBallInstantiate : MonoBehaviour
{
    // 02/02/2023 --> Llu�s Cap�
    [SerializeField] Transform spawnPoint;
    [SerializeField] float force;
    Vector3 _dir;
    [SerializeField] GameObject _ball;
    [SerializeField] Rigidbody _ballRB;

    public GameObject GetBall()
    {
        return _ball;
    }

    private void Awake()
    {     
        Init();
    }

    private void Init()
    {
        _dir = new Vector3(1.0f, .0f, .0f);
    }
    public void SapawnBall()
    {
        _ball.transform.position = spawnPoint.position;
        _ball.SetActive(true);

        StartCoroutine(wait());
    }

    public void RemoveBall()
    {
        _ball.GetComponent<Rigidbody>().velocity *= 0;
        _ball.SetActive(false);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(.5f);
        _ballRB.AddForce(_dir * force, ForceMode.Impulse);
    }
}
