using UnityEngine;
using Vuforia;

public class RightMeshCreator : MonoBehaviour
{
    public GameObject meshObject;
    public ObserverBehaviour targetTable;
    public ObserverBehaviour targetRobot;
    public Transform[] tableRightPoints = new Transform[4];  // Adjust size as needed for more points
    public Transform[] robotRightPoints = new Transform[4];

    private void Update()
    {
        if (targetTable.TargetStatus.Status == Status.TRACKED &&
            targetRobot.TargetStatus.Status == Status.TRACKED)
        {
            CreateMesh();
        }
        CreateMesh();
    }

    void CreateMesh()
    {
        Vector3[] vertices = new Vector3[8];
        for (int i = 0; i < 4; i++)
        {
            vertices[i] = tableRightPoints[i].position;
            vertices[i + 4] = robotRightPoints[i].position;
        }

        int[] triangles = new int[] {
            4,1,0,4,0,5,
            6,3,1,6,1,4,
            6,7,2,6,2,3,
            7,5,0,7,0,2,
            0,2,3,0,3,1,
            4,5,7,4,7,6
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        meshObject.GetComponent<MeshFilter>().mesh = mesh;
        meshObject.SetActive(true);
    }
}
