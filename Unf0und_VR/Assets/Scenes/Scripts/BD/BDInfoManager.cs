using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "BD/InfoFromTheServer", fileName = "new serverInfo"), Serializable]
public class BDInfoManager : ScriptableObject
{
    public string[] nick;
    public string[] email;
    public string[] score;

    public void SetPharams(string[] nicks, string[] emails, string[] scores)
    {
        nick = nicks;
        email = emails;
        score = scores;
    }
}
