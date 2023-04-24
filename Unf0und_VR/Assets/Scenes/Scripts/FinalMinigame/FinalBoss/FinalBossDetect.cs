using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossDetect : MonoBehaviour
{
    FinalBossController controller;
    [SerializeField] RuntimeAnimatorController animator;

    private void Start()
    {
        GetComponent<Animator>().runtimeAnimatorController = animator;
        controller = GetComponent<FinalBossController>();
    }
    private void OnBecameVisible()
    {
        Debug.Log("Scream");
        GetComponent<Animator>().SetTrigger("Scream");
    }

    public void OnAnimFinish()
    {
        controller.enabled = true;
        this.enabled = false;
    }
}
