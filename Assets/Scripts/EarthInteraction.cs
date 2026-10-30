using UnityEngine;

public class EarthInteraction : MonoBehaviour
{
    public float rotationSpeed = 0.2f;
    public float scaleSpeed = 0.005f;

    private float previousDistance;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.Rotate(
                    Vector3.up,
                    -touch.deltaPosition.x * rotationSpeed,
                    Space.World
                );
            }
        }

        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            float currentDistance =
                Vector2.Distance(touch1.position, touch2.position);

            if (touch2.phase == TouchPhase.Moved)
            {
                float difference = currentDistance - previousDistance;

                Vector3 newScale = transform.localScale +
                    Vector3.one * difference * scaleSpeed;

                float scale = Mathf.Clamp(newScale.x, 0.05f, 0.4f);

                transform.localScale = Vector3.one * scale;
            }

            previousDistance = currentDistance;
        }
    }
}