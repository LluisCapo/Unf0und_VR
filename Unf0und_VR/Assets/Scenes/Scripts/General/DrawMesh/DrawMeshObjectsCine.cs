using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMeshObjectsCine : MonoBehaviour
{
    public Mesh mesh;
    public Material material;
    public LayerMask layer;
    public float obj;
    public float separacionY;


    private void Update()
    {
        for (float i = 0; i <= (separacionY * obj); i += separacionY)
            Graphics.DrawMesh(mesh, new Vector3(transform.position.x, transform.position.y + (i/5), transform.position.z - i),Quaternion.Euler(-90, gameObject.transform.localRotation.eulerAngles.y-180,0),material, layer);



    }
}
