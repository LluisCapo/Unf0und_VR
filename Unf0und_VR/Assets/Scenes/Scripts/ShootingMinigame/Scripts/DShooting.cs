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
            //lastBullet = PoolingManager.Instance.GetPooledObject("Bullet");
            //lastBullet.SetActive(true);
            //lastBullet.transform.position = shootPoint.position;
            //lastBullet.GetComponent<BBullet>().MakeForce(shootPoint); //, LayerMask.GetMask("BBullet")
            Debug.Log("hoplaaaaaaaaaa");
            //Debug.DrawRay(shootPoint.transform.position, shootPoint.forward, Color.red);
            if (Physics.Raycast(shootPoint.transform.position, -transform.forward, out _hit))
            {
                GameObject BulletMark = PoolingManager.Instance.GetPooledObject("BulletMark");
                BulletMark.transform.parent = _hit.transform;
                BulletMark.transform.position = _hit.point; //new Vector3(_contactPoint.point.x, _contactPoint.point.y, _contactPoint.point.z);
                BulletMark.transform.rotation = Quaternion.LookRotation(_hit.normal);
                BulletMark.transform.Rotate(Vector3.right * 90);
                BulletMark.transform.Translate(Vector3.up * 0.005f);
                //BulletMark.transform.localScale = BulletMark.transform.localScale / 10;
                if (_hit.collider.GetComponent<DDartBoardManagment>())
                    _hit.collider.gameObject.GetComponent<DDartBoardManagment>().BulletEntry();
                if(_hit.collider.gameObject.TryGetComponent<MeshCollider>(out MeshCollider msh))
                    msh.enabled = false;
                Invoke("ShootingBeheavour", 0.15f);

                _canShoot = false;
                BulletMark.SetActive(true);
            }
            //Debug.Log("Disparo: " + lastBullet.GetComponent<Rigidbody>().velocity);
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
