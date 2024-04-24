using UnityEngine;

public class SpinObject : MonoBehaviour
{
    public float rotationSpeed = 90.0f; // Rotation speed in degrees per second

    // Update is called once per frame
    void Update()
    {
        // Rotate around the y-axis at rotationSpeed degrees per second
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    // Public method to set the rotation speed from other scripts
    public void SetRotationSpeed(float speed)
    {
        rotationSpeed = speed;
    }
}
