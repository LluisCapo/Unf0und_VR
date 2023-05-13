using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;

[CreateAssetMenu(menuName ="SMachine/Moving")]
public class SMMovingState : SStateBehavior
{
    [SerializeField] private Transform _point;
    [SerializeField] private bool hasPersonalizatedPoint;
    private Vector3 direction;
    public override void Init(SMachineController _controller)
    {
        if (!hasPersonalizatedPoint)
            _controller.PointToGo = _controller._paths[Random.Range(0, _controller._paths.Count)];
        else
            _controller.PointToGo.position = new Vector3(_controller.camaraPoint.transform.position.x, _controller.camaraPoint.transform.position.y, _controller.cameraReference.transform.position.z);

        _controller.MovementBehavior.SetVelocity(_controller.MovementBehavior.GetVelocity() + _controller.incrementalSpeed);
        
        Vector3 direction = _controller.PointToGo.transform.position - _controller.transform.position;
        _controller.platform.GetComponent<PlatformActing>().Rotate(direction.magnitude, _controller.MovementBehavior.GetVelocity() *3, "CodoX");
    }

    public override void OnUpdate(SMachineController _controller)
    {
        direction = _controller.PointToGo.transform.position - _controller.transform.position;
        //Vector3.Distance(_controller.transform.position, _controller.PointToGo.position)
        if (direction.magnitude <= _controller.distanceDifference)
        {

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
