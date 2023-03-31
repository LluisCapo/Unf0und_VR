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
        Vector3 objectScale = collision.gameObject.transform.localScale;
        collision.gameObject.transform.parent = transform;
        collision.gameObject.transform.localScale= objectScale;
    }
    public void CannonShoot() 
    {
        if(transform.childCount > 0)
        {
            ballPrefab = GetComponentInChildren<GameObject>();
            //GameObject ball = Instantiate(ballPrefab, firePoint.position, Quaternion.identity);
            ballPrefab.transform.parent = null;
            ballPrefab.GetComponent<Rigidbody>().AddForce(transform.forward * speedC);
        }
        
    }

}
