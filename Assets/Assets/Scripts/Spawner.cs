using UnityEngine;
public class Spawner : MonoBehaviour
{
    public GameObject pipe;
    [SerializeField] float spawnRate = 2f;
    private float timer = 0;
    public float heightOffset = 3;
    void Start()
    {
        spawnPipe();
    }
    void Update()
    {
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
