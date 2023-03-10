using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDartBoardManagment : MonoBehaviour
{
    #region Variables
    private Animator _anim;
    [SerializeField]
    private int _dartBoardScore = 10;


    #endregion
    #region StartFunctions
    private void OnEnable()
    {
        _anim = GetComponent<Animator>();
    }
    #endregion
    #region Functions
    //private void OnTriggerEnter(Collider other)
    //{
    //    GetComponent<SScoreBehaviour>().RecieveScore(_dartBoardScore);
    //    //_anim.SetTrigger("Hit");
    //    //Invoke("ResetAnimation", Random.Range(1, 5));
    //}

    //private void ResetAnimation()
    //{
    //    _anim.SetTrigger("Restart");
    //}
    public int GetDartBoardScore()
    {
        return _dartBoardScore;
    }
    #endregion


}
