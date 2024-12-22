using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBoss : MonoBehaviour
{
    public GameObject boss;
    private BossHealth bossHealthScript;

    void Start()
    {
        // Dapatkan komponen BossHealth dari bos
        bossHealthScript = boss.GetComponent<BossHealth>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Hancurkan bos
            Destroy(boss);
        }
    }
} 