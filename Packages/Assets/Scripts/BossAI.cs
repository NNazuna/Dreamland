using UnityEngine;

public class BossAI : MonoBehaviour
{
    public Transform player; // Referensi ke transform pemain
    public float moveSpeed = 3f; // Kecepatan bos bergerak
    public float retreatSpeed = 2f; // Kecepatan mundur bos
    public float chaseRange = 10f; // Jarak di mana bos akan mengejar pemain
    public GameObject snowballPrefab; // Prefab snowball
    public Transform firePoint; // Titik di mana snowball akan ditembakkan
    public float fireRate = 2f; // Kecepatan menembak
    private float nextFireTime = 0f;
    private Renderer bossRenderer;
    private Vector3 initialPosition; // Posisi awal bos
    public GameObject iceSpikePrefab; // Prefab untuk icespike
    public float iceSpikeDelay = 2f; // Waktu yang dibutuhkan sebelum icespike muncul
    private Vector3 lastPlayerPosition;
    private float playerStationaryTime = 0f;
    private float originalFireRate;
    private float originalSnowballSpeed = 10f; // Kecepatan awal snowball

    private void Start()
    {
        bossRenderer = GetComponent<Renderer>();
        initialPosition = transform.position; // Simpan posisi awal
        lastPlayerPosition = player.position;
        originalFireRate = fireRate; // Simpan fire rate asli
    }

    private void Update()
    {
        if (player != null && bossRenderer.isVisible)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer < chaseRange)
            {
                // Gerakkan bos ke arah pemain
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * moveSpeed * Time.deltaTime;
            }
            else
            {
                // Kembalikan bos ke posisi awal
                Vector3 directionToInitial = (initialPosition - transform.position).normalized;
                transform.position += directionToInitial * retreatSpeed * Time.deltaTime;
            }

            // Cek apakah bos bisa menembak
            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }

            // Cek apakah pemain diam
            if (Vector3.Distance(player.position, lastPlayerPosition) < 0.01f)
            {
                playerStationaryTime += Time.deltaTime;
                if (playerStationaryTime >= iceSpikeDelay)
                {
                    SpawnIceSpike();
                    playerStationaryTime = 0f; // Reset waktu diam
                }
            }
            else
            {
                playerStationaryTime = 0f; // Reset waktu diam jika pemain bergerak
            }

            lastPlayerPosition = player.position;

            // Periksa health bos dan sesuaikan kecepatan snowball dan fire rate
            BossHealth bossHealth = GetComponent<BossHealth>();
            if (bossHealth != null && bossHealth.health < bossHealth.maxHealth * 0.5f)
            {
                fireRate = originalFireRate * 2; // Tingkatkan fire rate 2 kali lipat
            }
            else
            {
                fireRate = originalFireRate; // Kembalikan fire rate ke nilai asli
            }
        }
    }

    private void Shoot()
    {
        // Buat snowball dan arahkan ke pemain
        GameObject snowball = Instantiate(snowballPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = snowball.GetComponent<Rigidbody2D>();
        Collider2D snowballCollider = snowball.GetComponent<Collider2D>();
        Collider2D bossCollider = GetComponent<Collider2D>();

        if (rb != null && snowballCollider != null && bossCollider != null)
        {
            // Abaikan tabrakan antara snowball dan bos
            Physics2D.IgnoreCollision(snowballCollider, bossCollider);

            Vector2 shootDirection = (player.position - firePoint.position).normalized;
            float snowballSpeed = originalSnowballSpeed;

            // Periksa health bos dan sesuaikan kecepatan snowball
            BossHealth bossHealth = GetComponent<BossHealth>();
            if (bossHealth != null && bossHealth.health < bossHealth.maxHealth * 0.5f)
            {
                snowballSpeed *= 3; // Tingkatkan kecepatan snowball 3 kali lipat
            }

            rb.velocity = shootDirection * snowballSpeed;
        }
    }

    private void SpawnIceSpike()
    {
        // Buat icespike di bawah pemain
        Vector3 spawnPosition = new Vector3(player.position.x, player.position.y - 1f, player.position.z);
        Instantiate(iceSpikePrefab, spawnPosition, Quaternion.identity);
    }
}