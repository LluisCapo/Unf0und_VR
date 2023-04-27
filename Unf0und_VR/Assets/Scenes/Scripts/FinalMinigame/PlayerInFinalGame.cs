using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInFinalGame : MonoBehaviour
{
    RaycastHit _hit;
    public float maxDistance;
    public bool hitDetect;
    [SerializeField] Transform point;

    void Update()
    {
        hitDetect = Physics.BoxCast(point.position, transform.localScale, point.forward, out _hit, transform.rotation, maxDistance);
        if (hitDetect)
        {
            //Output the name of the Collider your Box hit
            Debug.Log("Hit");
        }
    }

    //Draw the BoxCast as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Check if there has been a hit yet
        if (hitDetect)
        {
            //Draw a Ray forward from GameObject toward the hit
            //Gizmos.DrawRay(transform.position, transform.forward * m_Hit.distance);
            //Draw a cube that extends to where the hit exists
            //Gizmos.DrawWireCube(transform.position + transform.forward * m_Hit.distance, transform.localScale);
            Debug.Log("Si");
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            //Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(point.position + transform.forward * maxDistance, transform.localScale);
            Debug.DrawLine(point.position, transform.forward * maxDistance);
        }
    }
}
