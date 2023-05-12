using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform firePoint;
    public int speedC;
    public float segShoot;

    //void Update()
    //{

    //    if ((segShoot += Time.deltaTime) >= 2)
    //    {
    //        GameObject ball = Instantiate(ballPrefab, firePoint.position, Quaternion.identity);
    //        ball.GetComponent<Rigidbody>().AddForce(transform.forward * speedC);
    //        segShoot= 0;
    //    }
    //}

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Vector3 objectScale = collision.gameObject.transform.localScale;
        //collision.gameObject.transform.SetParent(transform);
        //collision.transform.position = Vector3.zero;
        //collision.gameObject.transform.localScale = objectScale;
    }
    public void CannonShoot() 
    {
        /*if(transform.childCount >=1)
        {
            ballPrefab = transform.GetChild(0).gameObject;
            //GameObject ball = Instantiate(ballPrefab, firePoint.position, Quaternion.identity);
            ballPrefab.transform.SetParent(null);
            ballPrefab.GetComponent<Rigidbody>().AddForce(transform.forward * speedC);
        }*/
        
    }

}
