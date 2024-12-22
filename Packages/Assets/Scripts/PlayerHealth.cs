using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;
    public Transform respawnPoint; // Tambahkan referensi ke titik respawn

    void Start()
    {
        maxHealth = health;
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Pindahkan pemain ke titik respawn
        transform.position = respawnPoint.position;
        // Reset health
        health = maxHealth;
        // Perbarui health bar
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
    }
}