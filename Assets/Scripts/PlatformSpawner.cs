using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objectPrefab;
    public float obstacleSpawnTime = 2f;
    public float timeTillSpawn;

    public float wooshSpeed = 2f;

    void Update()
    {
        SpawnObject();
    }

    void SpawnObject()
    {
        timeTillSpawn += Time.deltaTime;

        if (timeTillSpawn >= obstacleSpawnTime)
        {
            Spawn();
            timeTillSpawn = 0f;
        }
    }

    void Spawn()
    {
        GameObject objToSpawn = objectPrefab[Random.Range(0, objectPrefab.Length)];
        GameObject spawnedObj = Instantiate(objToSpawn, transform.position, Quaternion.identity);

        Rigidbody2D rb = spawnedObj.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left*wooshSpeed;
    }
}
