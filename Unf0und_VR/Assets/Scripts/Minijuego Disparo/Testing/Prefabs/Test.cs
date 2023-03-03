using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField, Range(2, 4)]
    private float max;

    [SerializeField, Range(0, 2)]
    private float min;

    [SerializeField]
    private float divideValue;

    public float speed;
    public Transform pos;
    private Rigidbody rb;


    private void OnEnable()
    {
        speed = Random.Range(min, max);
        transform.position = pos.position;
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, 0);
        Launch();
    }


    public void Launch()
    {
        rb.AddForce(pos.TransformDirection(new Vector3(-speed/divideValue, speed, 0)), ForceMode.Impulse);
    }

    private void OnDisable()
    {
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }

}
