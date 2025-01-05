using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake instance; // Singleton instance for easy access

    private Vector3 shakeOffset; // Offset caused by the screen shake
    private float shakeDuration = 0f; // Remaining shake time
    private float shakeMagnitude = 0.1f; // Intensity of the shake
    private float dampingSpeed = 1.0f; // Speed at which the shake diminishes

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void LateUpdate()
    {
        if (shakeDuration > 0)
        {
            // Generate random shake offset
            shakeOffset = Random.insideUnitSphere * shakeMagnitude;
            shakeOffset.z = 0; // Keep the shake on the x/y plane for 2D games

            // Decrease the shake duration over time
            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeOffset = Vector3.zero; // Reset offset when shake is done
        }
    }

    // Public method to trigger the shake
    public void TriggerShake(float duration, float magnitude)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
    }

    // Public method to get the shake offset for use in CameraFollow or similar scripts
    public Vector3 GetShakeOffset()
    {
        return shakeOffset;
    }
}