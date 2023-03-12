using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBullet : MonoBehaviour
{
    [SerializeField]
    float speed;

    private Rigidbody _rb;
    private GameObject hit;
    [SerializeField]
    private float _divideBulletMark;

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

    private void OnCollisionEnter(Collision collision)
    {
        //)
        //Vector3 puntocolision = ClosestPointOnBounds(transform.position);//other.ClosestPoint(transform.position);
        Debug.Log("Ha entrado en la colisión");
        hit = PoolingManager.Instance.GetPooledObject("BulletMark");
        hit.SetActive(true);
        hit.transform.position = -collision.contacts[0].point; // puntocolision;//  new Vector3(transform.position.x, transform.position.y, transform.position.z - other.GetComponent<BoxCollider>().transform.position.z);
        hit.transform.localScale = transform.localScale / _divideBulletMark;//new Vector3(transform.localScale.x, transform.localScale.y, hit.transform.localScale.z);
        //hit.transform.rotation.x - 
        hit.transform.rotation = new Quaternion(collision.transform.rotation.x, collision.transform.rotation.y, collision.transform.rotation.z, hit.transform.rotation.w);
        //;
        collision.gameObject.GetComponent<SScoreBehaviour>().RecieveScore(collision.gameObject.GetComponent<DDartBoardManagment>().GetDartBoardScore());

        gameObject.SetActive(false);
    }

    public void MakeForce(Transform POF)
    {
        _rb.AddForce(POF.TransformDirection(new Vector3(speed, 0,0)), ForceMode.Impulse);
    }
    public void Eject(Transform POF)
    {
        _rb.AddForce(POF.TransformDirection(new Vector3(0, 0, -speed)), ForceMode.Impulse);
    }
}
