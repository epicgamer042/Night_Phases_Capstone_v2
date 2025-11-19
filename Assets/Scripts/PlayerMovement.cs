 
using UnityEngine;
using UnityEngine.InputSystem;

//trying copilot suggestions
public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D rb;
    public InputActionReference move;
    public InputActionReference fire;

    [Header("Settings")]
    public float moveSpeed = 5f;

    private float horizontal;

    private void Update() //Once per frame
    {
        // Check if move action is valid before reading
        if (move != null && move.action != null)
        {
            horizontal = move.action.ReadValue<float>();
        }
    }

    private void FixedUpdate() //Once per physic tick (50 times per second default)
    {
        // Ensure Rigidbody exists before applying velocity
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(
                horizontal * moveSpeed,
                rb.linearVelocity.y // Keep existing Y velocity
            );
        }
    }

    private void OnEnable()
    {
        // Subscribe to fire event safely
        if (fire != null && fire.action != null)
        {
            fire.action.started += Fire;
        }
    }

    private void OnDisable()
    {
        // Unsubscribe safely to prevent dangling references
        if (fire != null && fire.action != null)
        {
            fire.action.started -= Fire;
        }
    }

    private void Fire(InputAction.CallbackContext context)
    {
        // Double-check object is still valid before doing anything
        if (this != null && gameObject.activeInHierarchy)
        {
            Debug.Log("Fired");
        }
    }
}

