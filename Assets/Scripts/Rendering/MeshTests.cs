using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[ExecuteAlways]
public class MeshTests : MonoBehaviour
{
    [SerializeField]
    MeshFilter _meshFilter;
    [SerializeField]
    MeshRenderer _renderer;

    [SerializeField]
    Vector3[] newVertices = new Vector3[4];
    
    readonly Vector2[] newUV = new Vector2[] {
        Vector2.up,
        Vector2.one,
        Vector2.right,
        Vector2.zero
    };
    readonly int[] newTriangles = new int[]{0,1,2,0,2,3};

    Mesh mesh;

    [Button]
    void Start()
    {
        mesh = new Mesh();
        _meshFilter.mesh = mesh;

        SetMeshDetails();
    }

    [Button]
    void SetMeshDetails()
    {
        if (mesh is null) return;
        if (_meshFilter is null) return;
        if (_renderer is null) return;

        mesh.vertices = newVertices;

        var intersectionPoint = GetIntersectionPointOfDiagonals();

        float[] ds = new float[4];
        for (int i = 0; i < ds.Length; i++)
        {
            ds[i] = Vector2.Distance(newVertices[i], intersectionPoint);
        }

        Vector3[] uvq = new Vector3[newUV.Length];
        for (int i = 0; i < uvq.Length; i++)
        {
            uvq[i] = new Vector3(newUV[i].x, newUV[i].y, 1) * (ds[i] * ds[(i+2)%4]) / (ds[(i+2)%4]);
        }

        mesh.SetUVs(0, uvq);

        // mesh.uv = newUV;
        mesh.triangles = newTriangles;
    }

    //this is very ugly but whatever
    Vector2 GetIntersectionPointOfDiagonals()
    {
        if (newVertices.Length != 4)
        {
            Debug.LogError("Must be 4 vertices (quad).");
            return default;
        }
        float x = 0, y = 0;

        if (newVertices[0].x == newVertices[2].x && newVertices[1].x == newVertices[3].x)
        {
            x = newVertices[0].x;
            y = (newVertices[0].y + newVertices[2].y) / 2;
        } 
        else if (newVertices[0].x == newVertices[2].x)
        {
            x = newVertices[0].x;
            float m1 = Slope(newVertices[3], newVertices[1]);
            float b1 = newVertices[1].y - m1 * newVertices[1].x;
            y = m1*x + b1;
        } 
        else if (newVertices[1].x == newVertices[3].x)
        {
            x = newVertices[1].x;
            float m0 = Slope(newVertices[2], newVertices[0]);
            float b0 = newVertices[0].y - m0 * newVertices[0].x;
            y = m0 * x + b0;
        }
        else
        {
            float m1 = Slope(newVertices[3], newVertices[1]);
            float b1 = newVertices[1].y - m1 * newVertices[1].x;
            float m0 = Slope(newVertices[2], newVertices[0]);
            float b0 = newVertices[0].y - m0 * newVertices[0].x;

            x = (b1 - b0)/(m0-m1);
            y = m0 * x + b0;
        }

        return new Vector2(x,y);
    }

    float Slope(Vector2 a, Vector2 b)
    {
        return (b.y - a.y)/(b.x - a.x);
    }
}
