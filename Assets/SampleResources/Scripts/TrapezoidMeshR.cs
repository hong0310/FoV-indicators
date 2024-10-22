using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class TrapezoidMeshR : MonoBehaviour
{
    void Start()
    {
        MeshFilter meshFilter = this.GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();

        // Vertices of the trapezoid
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-0.5f, 0, -0.36f),  // Bottom-left
            new Vector3(0.23f, 0, -0.36f),   // Bottom-right
            new Vector3(0.23f, 0, 0.36f), // Top-right
            new Vector3(-0.1f, 0, 0.36f) // Top-left
        };

        // Triangles (the order of vertices to create triangles)
        int[] triangles = new int[]
        {
            0, 2, 1, // First triangle
            0, 3, 2  // Second triangle
        };

        // Usually UVs are needed for texturing, simple placeholder
        Vector2[] uv = new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1)
        };

        // Assign data to mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;

        mesh.RecalculateNormals(); // To light the mesh correctly
        meshFilter.mesh = mesh;
    }
}
