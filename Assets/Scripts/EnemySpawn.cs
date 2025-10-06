using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    [SerializeField] private float minxRange = 5f;
    [SerializeField] private float minyRange = 4f;
    [SerializeField] private float maxxRange = 10f;
    [SerializeField] private float maxyRange = 8f;
    [SerializeField] private float spawnInterval = 2f;

    private float spawnAccelerationTimer = 0f;
    private float spawnAccelerationInterval = 10f;
    private float spawnTimer = 0f;
    public int currentEnemies;
    public GameObject player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        spawnAccelerationTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            Spawner();
            spawnTimer = 0f;
        }

        if (spawnAccelerationTimer >= spawnAccelerationInterval)
        {
            spawnAccelerationTimer = 0f;
            if (spawnInterval >= 0.2f)
            {
                spawnInterval -= 0.1f;
            }
        }
    }

    void Spawner()
    {
        Transform newPos = player.transform;
        
        Vector3 randomSpawn = new Vector3(Random.Range(minxRange + newPos.position.x, maxxRange + newPos.position.x), Random.Range(minyRange + newPos.position.y, maxyRange + newPos.position.y), 0f);
        Instantiate(pickEnemy(), randomSpawn, Quaternion.identity);
        currentEnemies++;
    }

    private GameObject pickEnemy()
    {
        int random = Random.Range(0, 100);

        if (random <= 30)
        {
            return enemyPrefab[0];
        }
        if (random <= 60)
        {
            return enemyPrefab[1];
        }
        if (random <= 90)
        {
            return enemyPrefab[2];
        }
        return enemyPrefab[3];
    }
}
