using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class SaturnRingGenerator : MonoBehaviour
{
    public float innerRadius = 0.35f;
    public float outerRadius = 0.85f;
    public int segments = 180;

    void Start()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[segments * 2];
        int[] triangles = new int[segments * 6];

        for (int i = 0; i < segments; i++)
        {
            float angle = 2f * Mathf.PI * i / segments;
            float x = Mathf.Cos(angle);
            float y = Mathf.Sin(angle);

            vertices[i * 2] = new Vector3(x * innerRadius, y * innerRadius, 0);
            vertices[i * 2 + 1] = new Vector3(x * outerRadius, y * outerRadius, 0);

            int next = (i + 1) % segments;
            int t = i * 6;

            triangles[t] = i * 2;
            triangles[t + 1] = next * 2;
            triangles[t + 2] = i * 2 + 1;

            triangles[t + 3] = i * 2 + 1;
            triangles[t + 4] = next * 2;
            triangles[t + 5] = next * 2 + 1;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
    }
}