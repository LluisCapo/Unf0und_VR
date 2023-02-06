using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDartBoardManagment : MonoBehaviour
{
    #region Variables
    private Animator _anim;

    #endregion
    #region StartFunctions
    private void OnEnable()
    {
        _anim = GetComponent<Animator>();
    }
    #endregion
    #region Functions
    private void OnTriggerEnter(Collider other)
    {
        _anim.SetTrigger("Hit");
    }
    #endregion
}
