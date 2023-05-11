using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BD/InfoToInsert", fileName = "new playerInfo")]
public class BDInfoToInsert : ScriptableObject
{
    public string nick;
    public string email;
    public string score;
}
