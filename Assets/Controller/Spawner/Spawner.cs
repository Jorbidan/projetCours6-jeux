using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate = 1;
        private float timeLeftBeforeSpawn = 0;
    private SpawnPoint[] spawnPoints;
    public GameObject ennemiCubePrefab;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = FindObjectsOfType<SpawnPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpawn();
    }
    private void UpdateSpawn()
    {
        timeLeftBeforeSpawn -= Time.deltaTime;
        if (timeLeftBeforeSpawn <= 0)
        {
            SpawnEnnemieCube();
            timeLeftBeforeSpawn = spawnRate;
        }
    }

    private void SpawnEnnemieCube()
    {
        int countSpawnPoints = spawnPoints.Length;
        int randomSpawnPoint = Random.Range(0, countSpawnPoints);
        SpawnPoint currentSpawnPoint = spawnPoints[randomSpawnPoint];
        Instantiate(ennemiCubePrefab, currentSpawnPoint.transform.position, Quaternion.identity);
    }
}
