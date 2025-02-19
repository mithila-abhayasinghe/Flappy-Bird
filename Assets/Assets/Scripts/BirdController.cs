using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip startSound;
    [SerializeField] private AudioClip pointSound;
    [SerializeField] private AudioClip endSound;

    [SerializeField] private TextMeshProUGUI scoreText;
    private int score;

    private Rigidbody2D rb;
    private AudioSource audioSource;

    void Start()
    {
        // Get the Rigidbody2D component attached to this GameObject
        rb = GetComponent<Rigidbody2D>();
        
        audioSource = rb.GetComponent<AudioSource>();

        // Configure the rigidbody for better game feel
        rb.gravityScale = 1f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        audioSource.PlayOneShot(startSound);
        

    }

    void Update()
    {
        // Check for space key or left mouse button
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        UpdateScoreDisplay();
    }

    void Jump()
    {
        // Apply an impulse force for instant velocity change
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        audioSource.PlayOneShot(jumpSound);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the bird passed through a pillar's trigger
        if (collision.gameObject.CompareTag("ScoreTrigger"))
        {
            IncrementScore();
        }
    }

    void IncrementScore()
    {
        score++;
        UpdateScoreDisplay();
        audioSource.PlayOneShot(pointSound);
    }

    void UpdateScoreDisplay()
    {
        scoreText.text = score.ToString();
    }
}

