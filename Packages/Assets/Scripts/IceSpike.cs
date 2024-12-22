using UnityEngine;
using System.Collections;

public class IceSpike : MonoBehaviour
{
    public float riseSpeed = 5f; // Kecepatan naiknya icespike
    public float health = 50f; // Health dari icespike
    public float knockbackForce = 5f; // Kekuatan knockback
    public float slowDuration = 3f; // Durasi perlambatan
    public float slowAmount = 0.25f; // Persentase perlambatan (75% lebih lambat)
    public float damageAmount = 20f; // Jumlah damage yang diberikan oleh icespike

    private void Start()
    {
        // Tidak menghancurkan icespike berdasarkan waktu hidup
    }

    private void Update()
    {
        // Naikkan icespike ke atas
        transform.Translate(Vector3.up * riseSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth pHealth = other.GetComponent<playerHealth>();
            if (pHealth != null)
            {
                pHealth.health -= damageAmount; // Kurangi health pemain
                Debug.Log("Pemain terkena icespike!");

                // Berikan efek knockback
                Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
                if (playerRb != null)
                {
                    Vector2 knockbackDirection = (other.transform.position - transform.position).normalized;
                    playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
                }

                // Perlambat gerakan pemain
                StartCoroutine(SlowPlayer(other.gameObject));
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator SlowPlayer(GameObject player)
    {
        PlayerController controller = player.GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.moveSpeed *= slowAmount; // Kurangi kecepatan pemain
            yield return new WaitForSeconds(slowDuration);
            controller.moveSpeed /= slowAmount; // Kembalikan kecepatan pemain
        }
    }
}