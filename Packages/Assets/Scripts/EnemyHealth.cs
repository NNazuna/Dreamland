using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 50f;
    public float maxHealth = 50f;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Logika ketika musuh mati, misalnya memicu animasi kematian atau menghancurkan objek
        Destroy(gameObject);
    }
}