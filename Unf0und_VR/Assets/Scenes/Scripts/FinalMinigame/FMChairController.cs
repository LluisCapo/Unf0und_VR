using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMChairController : MonoBehaviour
{
    [SerializeField] float secondsToDesable;
    //public void StartDesable() { StartCoroutine(wait()); }

    private void OnEnable()
    {
        StartCoroutine(wait());
    }
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(secondsToDesable);
        gameObject.SetActive(false);
    }
}
