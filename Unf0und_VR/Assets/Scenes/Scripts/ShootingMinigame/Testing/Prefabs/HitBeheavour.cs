using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBeheavour : MonoBehaviour
{
    [SerializeField, Range(2, 3)]
    private float max;

    [SerializeField, Range(0, 2)]
    private float min;


    private GameObject hit;
    private float speed;
    public Transform pos;
    private Rigidbody _rb;
    private void OnEnable()
    {
        transform.position = pos.position;
        _rb = GetComponent<Rigidbody>();
        speed = Random.Range(min, max);
        _rb.velocity = new Vector3(0, 0, 0);
        Launch();

    }

    private void OnCollisionEnter(Collision collision)
    {
        //)
        //Vector3 puntocolision = ClosestPointOnBounds(transform.position);//other.ClosestPoint(transform.position);
        hit = PoolingManager.Instance.GetPooledObject("BulletMark");
        hit.transform.position = collision.contacts[0].point; // puntocolision;//  new Vector3(transform.position.x, transform.position.y, transform.position.z - other.GetComponent<BoxCollider>().transform.position.z);
        hit.transform.localScale = transform.localScale / 6;//new Vector3(transform.localScale.x, transform.localScale.y, hit.transform.localScale.z);
        hit.transform.rotation = new Quaternion(hit.transform.rotation.x - collision.transform.rotation.x, collision.transform.rotation.y, collision.transform.rotation.z, hit.transform.rotation.w);
            //;
        gameObject.SetActive(false);
    }


    public void Launch()
    {
        _rb.AddForce(pos.TransformDirection(new Vector3(0, speed, -speed)), ForceMode.Impulse);
    }
}

