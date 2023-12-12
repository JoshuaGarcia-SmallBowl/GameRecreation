using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int columnPoolSize = 5;
    public GameObject columnPrefab;
    public float spawnrate = 4f;
    public float columnMin = -1f;
    public float columnMax = 3.5f;

    private GameObject[] obstacles;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 20f;
    private int currentColumn = 0;
    // Start is called before the first frame update
    void Start()
    {
        obstacles = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            obstacles[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if(GameControlScript.instance.gameOver == false && timeSinceLastSpawned >= spawnrate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range (columnMin, columnMax);
            obstacles[currentColumn].transform.position = new Vector2 (spawnXPosition, spawnYPosition);
            currentColumn++;
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}
