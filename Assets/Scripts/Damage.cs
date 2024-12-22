using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damageAmount = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerHealth healthScript = collision.gameObject.GetComponent<playerHealth>();
        if (healthScript != null)
        {
            healthScript.TakeDamage(damageAmount);
        }
    }
}
