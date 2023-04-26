using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossDetect : MonoBehaviour
{
    FinalBossController controller;
    [SerializeField] RuntimeAnimatorController animator;

    private void Start()
    {
        GetComponentInParent<Animator>().runtimeAnimatorController = animator;
        controller = GetComponentInParent<FinalBossController>();
    }
    private void OnBecameVisible()
    {
        Debug.Log("Scream");
        GetComponentInParent<Animator>().SetTrigger("scream");
    }

    private void OnBecameInvisible()
    {
        Debug.Log("NoneScream");
        GetComponentInParent<Animator>().SetTrigger("cream");
    }

    public void OnAnimFinish()
    {
        controller.enabled = true;
        GetComponentInChildren<FinalBossController>().enabled = false;
        this.enabled = false;
    }
}
