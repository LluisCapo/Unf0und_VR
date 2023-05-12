using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawObjectsTeatre : MonoBehaviour
{
    public UnityEngine.Mesh mesh;
    public Material material;
    public LayerMask layer;
    public float obj;
    public float separacion;

    private void Update()
    {
        for (float i = 0; i <= (separacion * obj); i += separacion)
            Graphics.DrawMesh(mesh, new Vector3(transform.position.x, transform.position.y + i, transform.position.z + i), transform.rotation, material, layer);
    }
}
