using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField] GameObject groundPrefab;
    [SerializeField] int groundsToSpawn = 1;
    [SerializeField] float groundYPos = -4.4f;
    [SerializeField] float groundXDist = 17.85f;
    private float lastGroundXPos;
    [SerializeField] float generateLevelWaitTime = 10f;
    float waitTimer;
    void Start()
    {
        StartCoroutine(SpawnGrounds());
    }

    // Update is called once per frame
    void Update()
    {
        CheckToSpawnLevelParts();
    }

    void CheckToSpawnLevelParts()
    {

        if (Time.time > waitTimer)
        {
            GenerateGrounds();

            waitTimer = Time.time + generateLevelWaitTime;
        }

    }

    IEnumerator SpawnGrounds()
    {
        while (true)
        {
            GenerateGrounds();
            yield return new WaitForSeconds(generateLevelWaitTime);
        }
    }

    void GenerateGrounds()
    {

        Vector3 groundPosition = Vector3.zero;

        for (int i = 0; i < groundsToSpawn; i++)
        {

            groundPosition = new Vector3(lastGroundXPos, groundYPos, 0f);

            Instantiate(groundPrefab, groundPosition, Quaternion.identity)
                .transform.SetParent(transform);

            lastGroundXPos += groundXDist;
        }

    }
}
