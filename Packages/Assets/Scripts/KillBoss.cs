using UnityEngine;

public class KillBoss : MonoBehaviour
{
    public BossHealth bossHealth;
    public float damageAmount = 10f; // Jumlah damage yang diberikan setiap kali terkena

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Berikan damage ke bos
            bossHealth.TakeDamage(damageAmount);

            // Cek apakah bos sudah mati
            if (bossHealth.health <= 0)
            {
                // Logika tambahan jika bos mati, misalnya memicu animasi atau efek
                Debug.Log("Boss defeated!");
            }
        }
    }
} 