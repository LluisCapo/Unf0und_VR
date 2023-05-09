using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SMachine/Moving")]
public class SMMovingState : SStateBehavior
{
    [SerializeField] private Transform _point;
    [SerializeField] private bool hasPersonalizatedPoint;

    public override void Init(SMachineController _controller)
    {
        if (!hasPersonalizatedPoint)
            _controller.PointToGo = _controller._paths[Random.Range(0, _controller._paths.Count)];
        else
            _controller.PointToGo = _controller.camaraReference;

        _controller.MovementBehavior.SetVelocity(_controller.MovementBehavior.GetVelocity() + _controller.incrementalSpeed);
    }

    public override void OnUpdate(SMachineController _controller)
    {
        if (Vector3.Distance(_controller.transform.position, _controller.PointToGo.position) <= _controller.distanceDifference)
        {
            _controller.rb.velocity = new Vector3(0, 0, 0);
            _controller.SetWaiting();
            _controller.rb.AddForce(_controller.transform.up * 0.8f, ForceMode.Impulse);
            if (hasPersonalizatedPoint)
                _controller.enabled = false;
        }
        else
            _controller.MovementBehavior.Move(_controller.PointToGo.position - _controller.transform.position);
    }
}
