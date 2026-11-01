using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class OrbitPath : MonoBehaviour
{
    public float radius = 0.6f;
    public int segments = 120;

    void Start()
    {
        LineRenderer line = GetComponent<LineRenderer>();

        line.useWorldSpace = false;
        line.loop = true;
        line.positionCount = segments;
        line.startWidth = 0.008f;
        line.endWidth = 0.008f;

        for (int i = 0; i < segments; i++)
        {
            float angle = 2f * Mathf.PI * i / segments;

            line.SetPosition(i, new Vector3(
                Mathf.Cos(angle) * radius,
                Mathf.Sin(angle) * radius,
                0
            ));
        }
    }
}