using UnityEngine;

public class SetZRotation : MonoBehaviour
{
    // The fixed rotation on the Z-axis
    public float zRotation = 90f;

    void Update()
    {
        // Get the current rotation
        Quaternion currentRotation = transform.rotation;

        // Set the Z-axis to a fixed value while preserving the other axes
        Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y, zRotation);

        // Apply the new rotation
        transform.rotation = newRotation;
    }
}
