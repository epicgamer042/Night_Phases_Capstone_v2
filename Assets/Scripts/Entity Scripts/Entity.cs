using UnityEngine;

public class Entity : MonoBehaviour
{

    protected Rigidbody2D rb;
    protected Collider2D col;

    [Header("Health")]
    [SerializeField] private int maxHealth = 1;
    [SerializeField] private int currentHealth;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
    }

    private void TakeDamage()
    {
        currentHealth = currentHealth - 1;

        //PlayDamageFeedback();

        if (currentHealth <= 0)
            Die();
    }

    protected virtual void Die()
    {
        //anim.enabled = false;
        col.enabled = false;

        rb.gravityScale = 12;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 15);

        Destroy(gameObject, 3);
    }
}
