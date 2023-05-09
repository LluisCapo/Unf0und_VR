using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Experimental.GraphView.GraphView;
using VisualDesignCafe.Nature.Materials.Editor.Sections;

public class DrawMeshObjects : MonoBehaviour
{
    public  List<UnityEngine.Mesh> mesh;
    public Vector3 vector3;
    public Quaternion quaternion;
    public Material material;
    public int layer;
    private void Start()
    {
        for(int i = 0; i < mesh.Count;i++)
            Graphics.DrawMesh(mesh[i], vector3, quaternion, material, layer);
    }
}
