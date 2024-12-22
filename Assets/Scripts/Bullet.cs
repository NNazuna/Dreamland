using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f; // Waktu hidup peluru sebelum dihancurkan

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed; // Peluru bergerak ke arah kanan
        Destroy(gameObject, lifetime); // Hancurkan peluru setelah waktu tertentu
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