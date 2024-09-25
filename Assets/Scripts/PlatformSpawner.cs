using System.Collections;
using System.Collections.Generic;
using RunGame;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objectPrefab;
    public float obstacleSpawnTime = 2f;
    public float timeTillSpawn;

    public int difficulty = 1;

    public float wooshSpeed = 2f;

    GameManager gManager;
    void Start()
    {
        gManager = GameManager.Instance;
    }

    void Update()
    {
        if (gManager.isPlaying())
        {
            SpawnObject();

            if (gManager.GetTransferredPoints() == 10 && difficulty == 1)
            {
                wooshSpeed += 2;
                difficulty++;
            }
            else if (gManager.GetTransferredPoints() == 25 && difficulty == 2)
            {
                wooshSpeed += 2;
                difficulty++;
            }
        }
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
