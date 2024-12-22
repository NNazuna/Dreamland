using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage;

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
            playerHealth pHealth = other.gameObject.GetComponent<playerHealth>();
            if (pHealth != null)
            {
                pHealth.health -= damage;
            }
        }
        else if (other.gameObject.CompareTag("Boss"))
        {
            BossHealth bossHealth = other.gameObject.GetComponent<BossHealth>();
            if (bossHealth != null)
            {
                bossHealth.TakeDamage(damage);
            }
        }
    }
}