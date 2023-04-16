using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "BD/Info", fileName = "new BDInfo")]
public class BDInfoManager : ScriptableObject
{
    public string[] nick;
    public string[] email;
    public string[] score;

    public void SetEmail(String _email) { email[0] = _email; }
    public void SetNick(String _nick) { nick[0] = _nick; }
}
