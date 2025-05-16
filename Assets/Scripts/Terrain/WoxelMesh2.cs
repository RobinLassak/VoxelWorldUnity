using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoxelMesh2 : MonoBehaviour
{

    public void Start()
    {
        GenerateMesh();
    }
    public void GenerateMesh()
    {
        Mesh mesh = new Mesh();

        Vector3[] vrcholy = new Vector3[]
        {
            new Vector3(2, 0, 0),   //0
            new Vector3(3, 0, 0),   //1
            new Vector3 (3, 1, 0),  //2
            new Vector3(2, 1, 0),   //3
            new Vector3(2, 0, 1),   //4
            new Vector3(3, 0, 1),   //5 
            new Vector3(3, 1, 1),   //6
            new Vector3(2, 1, 1)    //7
        };
        int[] trojuhelniky = new int[]
        {
            4, 7, 5, 5, 7, 6,
            1, 2, 0, 0, 2, 3,
            0, 3, 4, 4, 3, 7,
            5, 6, 1, 1, 6, 2,
            3, 2, 7, 7, 2, 6,
            0, 4, 1, 1, 4, 5
        };

        mesh.vertices = vrcholy;
        mesh.triangles = trojuhelniky;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
    }

}
