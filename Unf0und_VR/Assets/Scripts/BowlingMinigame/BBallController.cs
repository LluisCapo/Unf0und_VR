using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBallController : MonoBehaviour
{
    [SerializeField]
    Transform point;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            transform.position = point.position;
    }
}
