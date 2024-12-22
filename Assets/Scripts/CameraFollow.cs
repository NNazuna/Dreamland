using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Referensi ke transform pemain
    public Vector3 offset; // Offset dari posisi pemain
    public float smoothSpeed = 0.125f; // Kecepatan smoothing

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}