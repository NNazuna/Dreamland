using UnityEngine;

public class PinkBullet : MonoBehaviour
{
    public float lifetime = 2f; // Waktu hidup peluru sebelum dihancurkan

    void Start()
    {
        // Hancurkan peluru setelah waktu tertentu
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Logika ketika peluru mengenai sesuatu
        if (collision.CompareTag("Enemy"))
        {
            // Misalnya, hancurkan musuh
            Destroy(collision.gameObject);
        }

        // Hancurkan peluru setelah mengenai sesuatu
        Destroy(gameObject);
    }
} 