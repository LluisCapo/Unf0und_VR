using Autohand.Demo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PadLockController : ObjectDamagedBehavior
{
    public UnityEvent opendoor;

    public override void BulletEntry()
    {
        Debug.Log("break");
        foreach(Transform _child in transform)
            _child.gameObject.AddComponent<Rigidbody>();
        opendoor.Invoke();
        StartCoroutine(Wait());
        
    }

    public IEnumerator Wait() 
    { 
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Tutorial");
        this.enabled = false;

    }
}
