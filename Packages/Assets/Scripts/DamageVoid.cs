using System.Collections;
using UnityEngine;

public class DamageVoid : MonoBehaviour
{
    public float damagePerSecond = 10f; // Damage yang diterima per detik
    private playerHealth playerHealthScript;
    private Coroutine damageCoroutine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealthScript = other.GetComponent<playerHealth>();
            if (playerHealthScript != null && damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(ApplyDamageOverTime());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
        }
    }

    private IEnumerator ApplyDamageOverTime()
    {
        while (true)
        {
            playerHealthScript.health -= damagePerSecond * Time.deltaTime;
            if (playerHealthScript.health <= 0)
            {
                playerHealthScript.health = 0;
                playerHealthScript.transform.position = playerHealthScript.respawnPoint.position;
                playerHealthScript.health = playerHealthScript.maxHealth;
                playerHealthScript.healthBar.fillAmount = 1;
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
                yield break;
            }
            yield return null;
        }
    }
} 