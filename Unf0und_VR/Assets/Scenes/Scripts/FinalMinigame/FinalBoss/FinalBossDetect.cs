using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossDetect : MonoBehaviour
{
    FinalBossController controller;
    [SerializeField] RuntimeAnimatorController animator;

    private void Start()
    {
        Animator anim = GetComponentInParent<Animator>();
        anim.runtimeAnimatorController = animator;
        anim.ResetTrigger("scream");
        controller = GetComponentInParent<FinalBossController>();
    }

    public void OnAnimFinish()
    {
        controller.enabled = true;
        GetComponentInChildren<FinalBossDetect>().enabled = false;
        this.enabled = false;
    }
}
