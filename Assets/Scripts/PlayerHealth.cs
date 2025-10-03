using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int playerHealth;
    public EnemyFollow enemyFollow;

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage()
    {
        playerHealth--;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        takeDamage();
    }
}
