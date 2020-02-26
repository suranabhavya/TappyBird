using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePool : MonoBehaviour
{
    public float ColumnMin = -1f;
    public float ColumnMax = 3.5f;
    public GameObject PipePrefab;
    public int pipePoolSize = 5;
    private GameObject[] pipes;
    private Vector2 pipePoolPosition = new Vector3(-150f, -250f, -5f);
    private float timeSinceLastSpawned;
    public float spawnRate = 4f;
    private int currentPipe = 0;
    private float spawnXPosition = 150f;
    // Start is called before the first frame update
    void Start()
    {
        pipes = new GameObject[pipePoolSize];
        for(int i=0; i<pipePoolSize; i++)
        {
            pipes[i] = (GameObject) Instantiate (PipePrefab, pipePoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if(GameManager.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range ( ColumnMin, ColumnMax );
            pipes[currentPipe].transform.position = new Vector2 (spawnXPosition, spawnYPosition);
            currentPipe++;
            if(currentPipe >= pipePoolSize)
            {
                currentPipe = 0;
            }
        }
    }
}
