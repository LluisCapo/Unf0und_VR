using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DrawMeshObjects : MonoBehaviour
{
    public Mesh mesh;
    public Material material;
    public LayerMask layer;
    public float obj;
    public float separacion;

    private void Update()
    {
        for (float i = 0; i <= (separacion * obj); i+= separacion)
            Graphics.DrawMesh(mesh, new Vector3(transform.position.x+i, transform.position.y, transform.position.z), transform.rotation, material, layer);
    }
}
