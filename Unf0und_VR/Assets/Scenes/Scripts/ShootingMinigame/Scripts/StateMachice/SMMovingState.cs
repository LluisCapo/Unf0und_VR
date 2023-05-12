using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
            _controller.platform.GetComponent<PlatformActing>().Rotate((_controller.PointToGo.transform.position - _controller.transform.position).magnitude, _controller.GetComponent<MovementBehavior>().GetVelocity(), "MuñecaX", _controller.PointToGo.gameObject);
            _controller.rb.velocity = new Vector3(0, 0, 0);
            _controller.SetWaiting();
            _controller.rb.AddForce(_controller.transform.up * 0.8f, ForceMode.Impulse);
            _controller.objective.transform.GetChild(0).GetComponent<MeshCollider>().enabled = true;
            if (hasPersonalizatedPoint)
            {
                _controller.OnTimeReaches.Invoke();
                _controller.enabled = false;
            }
                
        }
        else
            _controller.MovementBehavior.Move(_controller.PointToGo.position - _controller.transform.position);
    }
}
