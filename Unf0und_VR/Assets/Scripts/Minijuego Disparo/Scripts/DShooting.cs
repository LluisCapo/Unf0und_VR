using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DShooting : MonoBehaviour
{
    [SerializeField]
    Transform shootPoint;
    private GameObject lastBullet;
    public void Shoot()
    {
        lastBullet = PoolingManager.Instance.GetPooledObject("Bullet");
        lastBullet.gameObject.SetActive(true);
        lastBullet.transform.position = shootPoint.position;
        lastBullet.GetComponent<BBullet>().MakeForce(shootPoint);
        Debug.Log("Disparo: " + lastBullet.GetComponent<Rigidbody>().velocity);
    }
}
