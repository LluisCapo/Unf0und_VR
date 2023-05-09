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
    public void Init()
    {
        transform.position = point.position;
        transform.rotation = new Quaternion(.0f, .0f, .0f, .0f);
        GetComponent<Rigidbody>().velocity *= 0;
    }
}
