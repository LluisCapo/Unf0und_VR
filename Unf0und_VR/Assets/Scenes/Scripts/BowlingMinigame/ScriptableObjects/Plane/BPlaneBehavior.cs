using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPlaneBehavior : MonoBehaviour
{
    MovementBehavior _mvb;
    Vector3 _dir;
    public bool isUP;

    [SerializeField] float downY, upY;
    private void Start()
    {
        _mvb = GetComponent<MovementBehavior>();
        _dir = new Vector3(.0f, 1f, .0f);
    }
    private void Update()
    {
        if (isUP)
            Up();
        else
            Down();
    }
    private void Up()
    {
        if (transform.localPosition.y < upY)
            _mvb.Move(_dir);
    }

    private void Down()
    {
        if (transform.localPosition.y > downY)
            _mvb.Move(_dir * -1);
    }
}
