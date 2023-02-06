using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BState : MonoBehaviour
{
    public abstract void Init();
    public abstract void OnUpdate();
}
