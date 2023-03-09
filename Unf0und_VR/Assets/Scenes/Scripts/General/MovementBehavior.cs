using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    private Rigidbody _rB = null;
    private Rigidbody2D _rB2D;
    [SerializeField] float velocity;
    private float maxVelocity;
    

				void Awake()
				{
        maxVelocity = velocity;
                    if (TryGetComponent(out Rigidbody rB))
                        _rB = rB;

                    if (TryGetComponent(out Rigidbody2D riB)) _rB2D = riB;

				}
				public void Move(Vector3 direction)
    {
        transform.position = transform.position + velocity * direction * Time.deltaTime;
    }

    public void Move(float vel, Vector3 dir)
				{
        transform.position = transform.position + vel * dir * Time.deltaTime;
    }

    public void MoveToTarget(Vector3 _target)
    {
        _rB.MovePosition(Vector3.MoveTowards(transform.position, _target, velocity));
    }

    public void MovePosition(Vector3 dir, float vel)
				{
        _rB.MovePosition(transform.position + vel * dir * Time.deltaTime);
				}

    public void MovePosition(Vector3 dir)
    {
        _rB.MovePosition(transform.position + velocity * dir * Time.deltaTime);
    }

    public void MovePosition2D(Vector3 dir)
    {
        _rB2D.MovePosition(transform.position + velocity * dir * Time.deltaTime);
    }

    public float GetVelocity()
				{
        return velocity;
				}

    public void SetVelocity(float _newVelocity)
    {
        velocity = _newVelocity;
    }

    public void MoveRB(Vector3 dir)
				{
        if (_rB != null)
            _rB.velocity = dir;
				}

    public void MoveRB2D(Vector3 _dir)
    {
        if (_rB2D != null)
            _rB2D.velocity = _dir;
    }
    public void ResetVelocity()
    {
        velocity = maxVelocity;
    }
}
