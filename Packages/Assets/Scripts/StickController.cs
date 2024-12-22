using UnityEngine;

public class StickController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Transform player; // Referensi ke transform pemain

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Cek arah pemain dan balikkan tongkat
        if (player.localScale.x < 0)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
    }
}
