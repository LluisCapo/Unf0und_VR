using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingBehaviour : MonoBehaviour
{
    private List<MeshRenderer> _childrenMeshList;

    private void Start()
    {
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
        foreach (MeshRenderer mr in _childrenMeshList)
            mr.forceRenderingOff = true;
    }

    public void UnHide()
    {
        foreach (MeshRenderer mr in _childrenMeshList)
            mr.forceRenderingOff = false;
    }
}
