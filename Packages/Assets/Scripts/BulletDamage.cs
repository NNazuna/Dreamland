using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float damageAmount = 10f; // Jumlah damage yang diberikan oleh peluru

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cek apakah peluru terlihat oleh kamera utama
        if (!IsVisibleToCamera())
        {
            return; // Jika tidak terlihat, keluar dari fungsi
        }

        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);
            }
        }
        else if (other.CompareTag("Boss"))
        {
            BossHealth bossHealth = other.GetComponent<BossHealth>();
            if (bossHealth != null)
            {
                bossHealth.TakeDamage(damageAmount);
            }
        }

        // Hancurkan peluru setelah mengenai target
        Destroy(gameObject);
    }

    private bool IsVisibleToCamera()
    {
        // Dapatkan kamera utama
        Camera mainCamera = Camera.main;
        if (mainCamera == null) return false;

        // Cek apakah peluru berada dalam frustum kamera
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);
        return GeometryUtility.TestPlanesAABB(planes, GetComponent<Collider2D>().bounds);
    }
}