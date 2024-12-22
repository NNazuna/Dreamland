using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject player;
    public Transform respawnPoint;

    void Start()
    {
        // Kode yang akan dijalankan saat objek pertama kali dibuat
    }

    void Update()
    {
        // Kode yang akan dijalankan setiap frame
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawnPoint.position;
        }
    }
}