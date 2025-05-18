using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{

    public void Start()
    {
        GenerateChunk();
    }
    public void GenerateChunk()
    {
        List<Vector3> vrcholy = new List<Vector3>();
        List<int> trojuhelniky = new List<int>();

        Vector3[] vrcholyJedneKostky = new Vector3[]
        {
            new Vector3(0, 0, 0),   //0
            new Vector3(1, 0, 0),   //1
            new Vector3 (1, 1, 0),  //2
            new Vector3(0, 1, 0),   //3
            new Vector3(0, 0, 1),   //4
            new Vector3(1, 0, 1),   //5 
            new Vector3(1, 1, 1),   //6
            new Vector3(0, 1, 1)    //7
        };
        int[] trojuhelnikyJedneKostky = new int[]
        {
            4, 7, 5, 5, 7, 6,
            1, 2, 0, 0, 2, 3,
            0, 3, 4, 4, 3, 7,
            5, 6, 1, 1, 6, 2,
            3, 2, 7, 7, 2, 6,
            0, 4, 1, 1, 4, 5
        };

        for (int x =  0; x < 16; x++)
        {
            for (int y = 0; y < 16; y++)
            {
                for(int z = 0; z < 16; z++)
                {
                    Vector3 pozice = new Vector3 (x, y, z);
                    int posunutiVrcholu = vrcholy.Count;

                    foreach(Vector3 v in vrcholyJedneKostky)
                    {
                        vrcholy.Add(pozice + v);
                    }
                    foreach(int troj in trojuhelnikyJedneKostky)
                    {
                        trojuhelniky.Add(posunutiVrcholu + troj);
                    }
                }
            }
        }
        Mesh mesh = new Mesh();
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        mesh.vertices = vrcholy.ToArray();
        mesh.triangles = trojuhelniky.ToArray();
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
    }

}
