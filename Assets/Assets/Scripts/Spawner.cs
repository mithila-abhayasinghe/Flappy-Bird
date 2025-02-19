using UnityEngine;
public class Spawner : MonoBehaviour
{

    [SerializeField] float spawnRate = 2f;
    [SerializeField] float heightOffset = 3;

    public GameObject pipe;
    private float timer = 0;

    void Start()
    {
        spawnPipe();
    }
    void Update()
    {
        if (GameManager.Instance.isGamePaused || GameManager.Instance.isGameOver)
        { 
            return; 
        }
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }
    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
