using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class MeshCollector : MonoBehaviour
{
    [SerializeField]
    MeshFilter _meshFilter;
    [SerializeField]
    MeshRenderer _meshRenderer;

    Mesh mesh;

    //0-----1
    //|     |
    //|     |
    //3-----2

    static readonly Vector2[] defaultUVs = new Vector2[] {
        Vector2.up,
        Vector2.one,
        Vector2.right,
        Vector2.zero
    };

    static readonly int[] defaultTriangles = new int[]{0,1,2,0,2,3};

    public void UpdateMesh(Vector3[] newVertices, Vector3 offset, Sprite texture)
    {
        _meshRenderer.material.SetTexture("_MainTex", texture.texture);

        if (mesh is null)
            CreateMesh();

        var vertices = (Vector3[])newVertices.Clone();

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] += offset;
        }

        mesh.vertices = vertices;

        mesh.SetUVs(0, CalcUVQ(vertices));
    }

    Vector3[] CalcUVQ(Vector3[] vertices)
    {
        var intersectionPoint = GetIntersectionPointOfDiagonals(vertices);

        float[] ds = new float[4];
        for (int i = 0; i < ds.Length; i++)
        {
            ds[i] = Vector2.Distance(vertices[i], intersectionPoint);
        }

        Vector3[] uvq = new Vector3[defaultUVs.Length];
        for (int i = 0; i < uvq.Length; i++)
        {
            uvq[i] = new Vector3(defaultUVs[i].x, defaultUVs[i].y, 1) * (ds[i] * ds[(i+2)%4]) / (ds[(i+2)%4]);
        }

        return uvq;
    }

    //this is very ugly but whatever
    Vector2 GetIntersectionPointOfDiagonals(Vector3[] vertices)
    {
        if (vertices.Length != 4)
        {
            Debug.LogError("Must be 4 vertices (quad).");
            return default;
        }
        
        float x = 0, y = 0;

        if (vertices[0].x == vertices[2].x && vertices[1].x == vertices[3].x)
        {
            //should hopefully never happen
            x = vertices[0].x;
            y = (vertices[0].y + vertices[2].y) / 2;
        } 
        else if (vertices[0].x == vertices[2].x)
        {
            x = vertices[0].x;
            var (m1, b1) = slopeintercept(vertices[3], vertices[1]);
            y = m1*x + b1;
        } 
        else if (vertices[1].x == vertices[3].x)
        {
            x = vertices[1].x;
            var (m0, b0) = slopeintercept(vertices[2], vertices[0]);
            y = m0 * x + b0;
        }
        else
        {
            var (m1, b1) = slopeintercept(vertices[3], vertices[1]);
            var (m0, b0) = slopeintercept(vertices[2], vertices[0]);

            x = (b1 - b0)/(m0-m1);
            y = m0 * x + b0;
        }

        static (float, float) slopeintercept(Vector2 p1, Vector2 p2)
        {
            float m = (p2.y - p1.y)/(p2.x - p1.x);
            float b = p1.y - m * p1.x;
            return (m,b);
        }

        return new Vector2(x,y);
    }

    void CreateMesh()
    {
        mesh = new Mesh
        {
            vertices = new Vector3[4],
            uv = defaultUVs,
            triangles = defaultTriangles,
            name = "Distorted Sprite Mesh"
        };

        _meshFilter.mesh = mesh;
    }

    [ShowInInspector, ReadOnly]
    public Vector3[] Vertices
    {
        get{
            if (mesh == null) return default;
            return mesh.vertices;
        }
    }
}