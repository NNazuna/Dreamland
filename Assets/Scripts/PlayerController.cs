using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;
    private int jumpCount = 0;
    public int maxJumps = 2; // Set to 2 for double jump
    public float dashSpeed = 20f; // Kecepatan dash
    public float dashDuration = 0.2f; // Durasi dash
    private bool isDashing = false;
    private float dashTime;
    public float dashCooldownDuration = 1f; // Durasi cooldown dash
    private float dashCooldownTime = 0f; // Waktu tersisa untuk cooldown
    public float fastFallSpeed = 30f; // Kecepatan turun saat menekan tombol S

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        if (!isDashing)
        {
            Move();
            Jump();
            FastFall(); // Logika untuk fast fall
        }
        Dash();
        UpdateCooldown();
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip the character based on movement direction
        if (moveInput > 0)
            spriteRenderer.flipX = false;
        else if (moveInput < 0)
            spriteRenderer.flipX = true;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
        }
    }

    void FastFall()
    {
        // Jika pemain tidak di tanah dan menekan tombol S
        if (!isGrounded && Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, -fastFallSpeed);
        }
    }

    void Dash()
    {
        if (Input.GetMouseButton(1) && !isDashing && dashCooldownTime <= 0f)
        {
            isDashing = true;
            dashTime = dashDuration;

            // Tentukan arah dash
            float dashDirection = 0;
            if (Input.GetKey(KeyCode.A))
                dashDirection = -1;
            else if (Input.GetKey(KeyCode.D))
                dashDirection = 1;

            rb.velocity = new Vector2(dashDirection * dashSpeed, rb.velocity.y);
            dashCooldownTime = dashCooldownDuration; // Set cooldown setelah dash
        }

        if (isDashing)
        {
            dashTime -= Time.deltaTime;
            if (dashTime <= 0)
            {
                isDashing = false;
                rb.velocity = new Vector2(0, rb.velocity.y); // Hentikan dash
            }
        }
    }

    void UpdateCooldown()
    {
        if (dashCooldownTime > 0)
        {
            dashCooldownTime -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0; // Reset jump count when grounded
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
