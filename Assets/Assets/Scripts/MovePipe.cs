using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    public float deadZone = -45;
    void Update()
    {

        if (GameManager.Instance.isGamePaused || GameManager.Instance.isGameOver)
        {
            return;
        }

        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
