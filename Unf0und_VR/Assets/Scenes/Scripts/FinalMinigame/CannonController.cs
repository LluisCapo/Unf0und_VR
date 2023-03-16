using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform firePoint;
    public int speedC;
    public float segShoot;

    void Update()
    {

        if ((segShoot += Time.deltaTime) >= 2)
        {
            GameObject ball = Instantiate(ballPrefab, firePoint.position, Quaternion.identity);
            ball.GetComponent<Rigidbody>().AddForce(transform.forward * speedC);
            segShoot= 0;
        }
    }
}
