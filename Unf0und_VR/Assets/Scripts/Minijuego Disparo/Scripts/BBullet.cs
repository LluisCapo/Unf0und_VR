using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBullet : MonoBehaviour
{
    [SerializeField]
    float speed;

    private Rigidbody _rb;


    public float Speed { get { return speed; } set { speed = value; } }


    private void Start()
    {
        speed = 2;
    }

    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = new Vector3(0, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        gameObject.SetActive(false);
    }

    public void MakeForce(Transform POF)
    {
        _rb.AddForce(POF.TransformDirection(new Vector3(speed, 0,0)), ForceMode.Impulse);
    }
}
