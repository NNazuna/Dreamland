using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;

    void Start()
    {
        // Kode yang akan dijalankan saat objek pertama kali dibuat
    }

    void Update()
    {
        // Kode yang akan dijalankan setiap frame
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawnPoint.transform.position;
        }
    }
}