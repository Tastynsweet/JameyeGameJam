using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    [SerializeField] private float minxRange = -9f;
    [SerializeField] private float minyRange = 1f;
    [SerializeField] private float maxxRange = 9f;
    [SerializeField] private float maxyRange = 1.6f;
    [SerializeField] private float spawnInterval = 2f;

    private float timer;
    public int maxEnemies = 100;
    public int currentEnemies;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (currentEnemies < maxEnemies && timer >= spawnInterval)
        {
            Spawner();
            timer = 0f;
        }
    }

    void Spawner()
    {
        Vector3 randomSpawn = new Vector3(Random.Range(minxRange, maxxRange), Random.Range(minyRange, maxyRange), 0f);
        Instantiate(enemyPrefab, randomSpawn, Quaternion.identity);
        currentEnemies++;
    }
}
