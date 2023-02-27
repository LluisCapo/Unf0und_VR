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

    [SerializeField]
    Rigidbody ballRigidBody;

    MovementBehavior _mvb;
    float yaw, pitch, velX, velZ;

    void Start()
    {
        _mvb = GetComponent<MovementBehavior>();
    }
    void Update()
    {
        RotateCamera();
        MoveCamera();
        Shoot();
    }

    public void RotateCamera()
    {
        yaw += camYawVelocity * Input.GetAxis("Mouse X");
        pitch -= camPitchVelocity * Input.GetAxis("Mouse Y");

        transform.rotation = Quaternion.Euler(pitch, yaw, .0f);
    }
    public void MoveCamera()
    {
        velX = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.W))
            _mvb.MoveRB(new Vector3(velX * cameraVelocity, .0f, 1f));
        else
        {
            if (Input.GetKey(KeyCode.S))
                _mvb.MoveRB(new Vector3(velX * cameraVelocity, .0f, -1f));
            else
                _mvb.MoveRB(new Vector3(velX * cameraVelocity, .0f, .0f));
        }
    }
    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.N))
            ballRigidBody.AddForce(new Vector3(-1f, .0f, .0f) * force, ForceMode.Impulse);
    }
}
