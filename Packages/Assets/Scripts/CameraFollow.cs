using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Referensi ke transform pemain
    public float FollowSpeed = 2f; // Kecepatan mengikuti
    public float yOffset = 1f; // Offset vertikal

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}