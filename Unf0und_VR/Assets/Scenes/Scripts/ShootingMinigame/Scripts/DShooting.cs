using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DShooting : MonoBehaviour
{
    [SerializeField]
    Transform shootPoint, bulletCasing;
    Animator _anim;
    Rigidbody _rb;
    private RaycastHit _hit;

    private GameObject lastBullet, projectile;
    private bool _canShoot;
    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _canShoot= true;
    }
    public void ShootGun()
    {
        if (_canShoot)
        {
            AudioManager.Instance.PlaySoundOnPosition("PistolShoot", shootPoint.position);
            _anim.SetTrigger("shoot");
            Debug.Log("Ha presionado el objeto");
        }

    }

    public void LaunchBullet()
    {
        try
        {
            _anim.SetTrigger("launch");
            if (Physics.Raycast(shootPoint.transform.position, -transform.forward, out _hit))
            {
                GameObject BulletMark = PoolingManager.Instance.GetPooledObject("BulletMark");
                BulletMark.transform.parent = _hit.transform;
                BulletMark.transform.position = _hit.point; 
                BulletMark.transform.rotation = Quaternion.LookRotation(_hit.normal);
                BulletMark.transform.Rotate(Vector3.right * 90);
                BulletMark.transform.Translate(Vector3.up * 0.005f);
                if (_hit.collider.GetComponent<DDartBoardManagment>())
                {
                    _hit.collider.gameObject.GetComponent<ObjectDamagedBehavior>().BulletEntry();
                    //if (_hit.collider.gameObject.TryGetComponent<MeshCollider>(out MeshCollider msh))
                    //    msh.enabled = false;
                }
                
                Invoke("ShootingBeheavour", 0.15f);

                _canShoot = false;
                BulletMark.SetActive(true);
            }
        }
        catch (Exception e)
        {
            Debug.Log("Error Recargar" + e.Message);
        }
    }

    private void ShootingBeheavour()
    {
        _canShoot= true;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(shootPoint.transform.position, -transform.forward);
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
