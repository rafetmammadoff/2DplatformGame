using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject bigBushPrefab;
    [SerializeField] float bigBushYPos = -2.1f;
    [SerializeField] float minSpawnWaitTime = 1f;
    [SerializeField] float maxSpawnWaitTime = 4.5f;
    float spawnWaitTime;
    private int obstacleTypesCount = 2;
    private int obstacleToSpawn;
    private Camera mainCam;
    private Vector3 obstacleSpawnPos = Vector2.zero;
    private GameObject newObstacle;
    [SerializeField] GameObject diamondPrefab;
    [SerializeField] float minDiamondY = -2.27f;
    [SerializeField] float maxDiamondY = 1.42f;
    private Vector3 diamondSpawnPos = Vector3.zero;
    [SerializeField] int diamondSpawnProbability = 1;

    private void Awake() {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        HandleObstacleSpawning();
    }

    void HandleObstacleSpawning()
    {

        if (Time.time > spawnWaitTime)
        {
            spawnWaitTime = Time.time + Random.Range(minSpawnWaitTime, maxSpawnWaitTime);
            SpawnObstacle();
            SpawnDiamond();
        }

    }

    void SpawnObstacle()
    {

        obstacleToSpawn = 0;

        obstacleSpawnPos.x = mainCam.transform.position.x + 20f;

        switch (obstacleToSpawn)
        {
            case 0:
                newObstacle = Instantiate(bigBushPrefab);
                obstacleSpawnPos.y = bigBushYPos;
                break;
        }

        newObstacle.transform.position = obstacleSpawnPos;

    }

    void SpawnDiamond()
    {
        if (Random.Range(0, 5) > diamondSpawnProbability)
        {
            diamondSpawnPos.x = mainCam.transform.position.x + 30f;
            diamondSpawnPos.y = Random.Range(minDiamondY, maxDiamondY);
            Instantiate(diamondPrefab, new Vector2(diamondSpawnPos.x -0.82f, diamondSpawnPos.y -3f), Quaternion.identity)
                .transform.SetParent(transform);

        }
    }
}
