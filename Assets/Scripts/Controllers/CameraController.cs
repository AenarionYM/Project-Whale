using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;  // Assign the player or target object here
    public Vector3 offset;    // Set this to control the camera position relative to the target
    public float smoothSpeed = 0.125f;  // Smooth transition speed (optional)// Smoothness factor

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

            // Update the camera position
            transform.position = smoothedPosition + ScreenShake.instance.GetShakeOffset();        }

        // Target position (player's position + offset
    }
}
