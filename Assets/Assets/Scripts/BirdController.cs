using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component attached to this GameObject
        rb = GetComponent<Rigidbody2D>();

        // Configure the rigidbody for better game feel
        rb.gravityScale = 1f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        // Check for space key or left mouse button
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    void Jump()
    {
        // Apply an impulse force for instant velocity change
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
