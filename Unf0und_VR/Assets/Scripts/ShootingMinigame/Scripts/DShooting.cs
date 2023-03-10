using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DShooting : MonoBehaviour
{
    [SerializeField]
    Transform shootPoint, bulletCasing;
    Animator _anim;
    Rigidbody _rb;

    private GameObject lastBullet, projectile;
    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }
    public void ShootGun()
    {
        _anim.SetTrigger("shoot");
        Debug.Log("Ha presionado el objeto");
    }

    public void LaunchBullet()
    {
        try
        {
            _anim.SetTrigger("launch");
            lastBullet = PoolingManager.Instance.GetPooledObject("Bullet");
            lastBullet.SetActive(true);
            lastBullet.transform.position = shootPoint.position;
            lastBullet.GetComponent<BBullet>().MakeForce(shootPoint);
            Debug.Log("Disparo: " + lastBullet.GetComponent<Rigidbody>().velocity);
        }
        catch (Exception e)
        {
            Debug.Log("Error Recargar" + e.Message);
        }
    }
    public void EjectProjectile()
    {
        try
        {
            projectile = PoolingManager.Instance.GetPooledObject("BulletCasing");
            projectile.gameObject.SetActive(true);
            projectile.transform.position = bulletCasing.position;
            projectile.GetComponent<Test>().Launch(bulletCasing);
            //projectile.GetComponent<BBullet>().Eject(bulletCasing);
        }
        catch(Exception e)
        {
            Debug.Log("No Ejection:" + e.Message);
        }
    }
}
