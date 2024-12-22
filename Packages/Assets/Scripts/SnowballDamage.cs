using UnityEngine;

public class SnowballDamage : MonoBehaviour
{
    public float damageAmount = 10f; // Jumlah damage yang diberikan oleh snowball
    public float snowballHealth = 5f; // Health dari snowball

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth pHealth = other.GetComponent<playerHealth>();
            if (pHealth != null)
            {
                pHealth.health -= damageAmount;
                Debug.Log("Pemain terkena snowball, menerima damage: " + damageAmount);
            }
        }

        // Kurangi health snowball ketika mengenai sesuatu
        snowballHealth -= 1f;
        if (snowballHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
} 