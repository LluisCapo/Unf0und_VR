using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BNoneHandCamera : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] Camera cam;

    [Header("Speeds")]
    public float camYawVelocity;
    public float camPitchVelocity;
    public float cameraVelocity;
    public float force;

    MovementBehavior _mvb;
    float yaw, pitch;

    void Start()
    {
        _mvb = GetComponent<MovementBehavior>();
    }
    void Update()
    {
        RotateCamera();
        MoveCamera();
    }

    public void RotateCamera()
    {
        yaw += camYawVelocity * Input.GetAxis("Mouse X");
        pitch -= camPitchVelocity * Input.GetAxis("Mouse Y");

        transform.rotation = Quaternion.Euler(pitch, yaw, .0f);
    }
    public void MoveCamera()
    {
        if (Input.GetKey(KeyCode.W))
            _mvb.MoveRB(transform.forward * _mvb.GetVelocity());
        else
            _mvb.MoveRB(Vector3.zero);
    }
}
