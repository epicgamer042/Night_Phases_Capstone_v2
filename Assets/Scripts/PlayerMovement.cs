
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

    private Vector2 _moveDirection;

    private void Update()
    {
        // Check if move action is valid before reading
        if (move != null && move.action != null)
        {
            _moveDirection = move.action.ReadValue<Vector2>();
        }
    }

    private void FixedUpdate()
    {
        // Ensure Rigidbody exists before applying velocity
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(
                _moveDirection.x * moveSpeed,
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
//original code based on youtube video - worked w/ left/right movement, but firing message was causing issues
/*public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    private Vector2 _moveDirection;
    public InputActionReference move;
    public InputActionReference fire;

    private void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(x:_moveDirection.x * moveSpeed, rb.linearVelocity.y * moveSpeed);
    }

    private void OnEnable()
    {
        fire.action.started += Fire;
    }

    private void OnDisable()
    {
        fire.action.started -= Fire;
    }
    private void Fire(InputAction.CallbackContext obj)
    {
        Debug.Log("Fired");
    }
}*/

