using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HidingBehaviour : MonoBehaviour
{
    private List<MeshRenderer> _childrenMeshList;

    private void Start()
    {
        _childrenMeshList= new List<MeshRenderer>();
        //Debug.Log("Al iniciar, la lista tiene " + _childrenMeshList.Count);
        foreach (Transform child in transform)
        {
            try
            {
                _childrenMeshList.Add(child.GetComponent<MeshRenderer>());
            }
            catch (System.Exception)
            {
                Debug.Log(child.name + "doesn't have a MeshRenderer");
            }
        }
    }

    public void Hide()
    {
        try
        {
            foreach (MeshRenderer mr in _childrenMeshList)
                mr.forceRenderingOff = true;
        }
        catch (System.Exception e)
        {

            Debug.LogWarning("[HidingBehaviour.Hide()] Ignoring error : " + e);
        }
    }

    public void UnHide()
    {
        try
        {
            foreach (MeshRenderer mr in _childrenMeshList)
                mr.forceRenderingOff = false;
        }
        catch (System.Exception e)
        {
            Debug.LogWarning("[HidingBehaviour.UnHide()] Ignoring error: " + e);
        }
    }
}
