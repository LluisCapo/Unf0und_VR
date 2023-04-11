using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BD/Info", fileName = "new BDInfo")]
public class BDInfoManager : ScriptableObject
{
    public string[] nick;
    public string[] email;
    public string[] score;
}
