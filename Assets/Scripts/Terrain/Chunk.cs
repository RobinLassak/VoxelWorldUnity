using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public int width = 16;
    public int height = 32;
    public int depth = 16;
    public float noiseScale = 0.1f;

    private Block[,,] blocks;
    
    void Start()
    {
        GenerateChunk();
        CreateVisualMesh();
    }
    void CreateVisualMesh()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        mesh.vertices = new Vector3[]
    {
        new Vector3(0, 0, 0),
        new Vector3(1, 0, 0),
        new Vector3(1, 1, 0),
        new Vector3(0, 1, 0),
        new Vector3(0, 1, 1),
        new Vector3(1, 1, 1),
        new Vector3(1, 0, 1),
        new Vector3(0, 0, 1)
    };

        mesh.triangles = new int[]
        {
        0, 2, 1, 0, 3, 2,
        2, 3, 4, 2, 4, 5,
        1, 2, 5, 1, 5, 6,
        0, 7, 4, 0, 4, 3,
        5, 4, 7, 5, 7, 6,
        0, 6, 7, 0, 1, 6
        };

        mesh.RecalculateNormals();
    }
    void GenerateChunk()
    {
        blocks = new Block[width, height, depth];

        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < depth; j++)
            {
                int terrainHeight = Mathf.FloorToInt(Mathf.PerlinNoise(
                    (transform.position.x + i) * noiseScale,
                    (transform.position.z + j) * noiseScale) * height);

                for(int k = 0; k < height; k++)
                {
                    BlockType type = BlockType.Air;

                    if (k < terrainHeight - 4)
                    {
                        type = BlockType.Stone;
                    }    
                    else if (k < terrainHeight - 1)
                    {
                        type = BlockType.Dirt;
                    }    
                    else if (k < terrainHeight)
                    {
                        type = BlockType.Grass;
                    }
                    blocks[i, k, j] = new Block(type);
                }
            }
        }
        Debug.Log("Chunk vygenerovan.");
    }
}
