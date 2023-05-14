using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMChairController : MonoBehaviour
{
    [SerializeField] float secondsToDesable;
    [SerializeField] Rigidbody _rb;

    private void OnEnable()
    {
        StartCoroutine(wait());
    }
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(secondsToDesable);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogError("LLuis la ha liado " + other.name);
        if (_rb.velocity.y != 0)
            GameManager.Instance.DeadPlayer();
    }
}
