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

    private float timer;
    private float spawnTimer;
    public int maxEnemies = 100;
    public int currentEnemies;
    public GameObject player;
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        timer += Time.deltaTime;

        if (currentEnemies < maxEnemies && spawnTimer >= spawnInterval)
        {
            Spawner();
            spawnTimer = 0f;
        }
    }

    void Spawner()
    {
        Transform newPos = player.transform;
        
        Vector3 randomSpawn = new Vector3(Random.Range(minxRange + newPos.position.x, maxxRange + newPos.position.x), Random.Range(minyRange + newPos.position.y, maxyRange + newPos.position.y), 0f);
        Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], randomSpawn, Quaternion.identity);
        currentEnemies++;
    }
}
