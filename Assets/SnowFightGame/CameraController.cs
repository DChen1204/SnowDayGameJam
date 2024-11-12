using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public float sensitivityX = 1f; // Sensitivity for horizontal (yaw) rotation
    public float sensitivityY = 1f; // Sensitivity for vertical (pitch) rotation

    private float rotationX = 0f; // To track the current horizontal rotation
    private float rotationY = 0f; // To track the current vertical rotation

    private Vector2 lookInputValue;

    private void OnLook(InputValue value)
    {
        lookInputValue = value.Get<Vector2>();
        Debug.Log(lookInputValue);
    }

    void Update()
    {
        // Update the rotationX and rotationY based on the input
        rotationX += lookInputValue.x * sensitivityX;
        rotationY += lookInputValue.y * sensitivityY;

        // Clamp the vertical rotation to -90 and 90 degrees
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        // Apply the rotation to the camera
        transform.localRotation = Quaternion.Euler(-rotationY, rotationX, 0f);
    }
}
