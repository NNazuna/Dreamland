using System.Collections;
using UnityEngine;

public class Damagespike : MonoBehaviour
{
    public float damagePerSecond = 5f;
    private Coroutine damageCoroutine;

    void Start()
    {
        // Kode yang akan dijalankan saat objek pertama kali dibuat
    }

    void Update()
    {
        // Kode yang akan dijalankan setiap frame
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Boss"))
        {
            if (damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(ApplyDamageOverTime(other.gameObject));
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if ((other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Boss")) && damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
        }
    }

    private IEnumerator ApplyDamageOverTime(GameObject target)
    {
        while (true)
        {
            if (target.CompareTag("Player"))
            {
                playerHealth pHealth = target.GetComponent<playerHealth>();
                if (pHealth != null)
                {
                    pHealth.health -= damagePerSecond * Time.deltaTime;
                }
            }
            else if (target.CompareTag("Boss"))
            {
                BossHealth bossHealth = target.GetComponent<BossHealth>();
                if (bossHealth != null)
                {
                    bossHealth.TakeDamage(damagePerSecond * Time.deltaTime);
                }
            }
            yield return null;
        }
    }
}