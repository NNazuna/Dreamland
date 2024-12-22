using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public Image healthBar;
    private Renderer bossRenderer;

    void Start()
    {
        health = maxHealth;
        bossRenderer = GetComponent<Renderer>();
        healthBar.enabled = false; // Mulai dengan health bar tersembunyi
    }

    void Update()
    {
        // Periksa apakah bos terlihat oleh kamera
        if (bossRenderer.isVisible)
        {
            healthBar.enabled = true; // Tampilkan health bar
        }
        else
        {
            healthBar.enabled = false; // Sembunyikan health bar
        }

        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float amount)
    {
        Debug.Log("Bos menerima damage: " + amount);
        health -= amount;
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
    }

    public void ResetHealth()
    {
        health = maxHealth; // Reset health ke nilai maksimum
        healthBar.fillAmount = 1; // Reset tampilan health bar
    }

    void Die()
    {
        // Logika ketika bos mati, misalnya memicu animasi kematian atau menghancurkan objek
        Debug.Log("Boss defeated!");
        Destroy(gameObject);
    }
} 