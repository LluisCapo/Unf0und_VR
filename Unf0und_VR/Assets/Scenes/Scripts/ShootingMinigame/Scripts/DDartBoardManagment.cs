using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DDartBoardManagment : ObjectDamagedBehavior
{
    #region StartFunctions
    private void OnEnable()
    {
        _anim = GetComponent<Animator>();
    }    
    #region Variables
    private Animator _anim;
    [SerializeField]
    private int _dartBoardScore = 10;
    public UnityEvent<int> GiveScore;

    #endregion

    #endregion
    #region Functions
    public override void BulletEntry()
    {
        GiveScore.Invoke(_dartBoardScore);
    }
    public int GetDartBoardScore()
    {
        return _dartBoardScore;
    }
    #endregion


}
