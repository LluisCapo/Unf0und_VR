using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BBullet : MonoBehaviour
{
    [SerializeField]
    float speed;

    private Rigidbody _rb;
    private GameObject BulletMark;
    [SerializeField]
    private float _divideBulletMark;
    private ContactPoint _contactPoint;

    public float Speed { get { return speed; } set { speed = value; } }


    private void Start()
    {
       // speed = 2;
    }

    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = new Vector3(0, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _contactPoint = collision.contacts[0];
        //)
        //Vector3 puntocolision = ClosestPointOnBounds(transform.position);//other.ClosestPoint(transform.position);
        Debug.Log("Ha entrado en la colisión");
        BulletMark = PoolingManager.Instance.GetPooledObject("BulletMark");
        BulletMark.transform.position = new Vector3 (_contactPoint.point.x, _contactPoint.point.y, _contactPoint.point.z);
        BulletMark.transform.rotation = Quaternion.LookRotation(_contactPoint.normal);
        BulletMark.transform.Rotate(Vector3.right * 90);
        BulletMark.transform.Translate(Vector3.up * 0.005f);
        BulletMark.transform.localScale = BulletMark.transform.localScale / _divideBulletMark;
        if(collision.gameObject.GetComponent<SScoreBehaviour>())
            collision.gameObject.GetComponent<SScoreBehaviour>().RecieveScore(collision.gameObject.GetComponent<DDartBoardManagment>().GetDartBoardScore());

        BulletMark.SetActive(true);
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
    private void OnDisable()
    {
        _rb.velocity= Vector3.zero;
    }
}
