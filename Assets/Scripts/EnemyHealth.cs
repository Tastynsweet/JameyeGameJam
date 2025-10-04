using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int enemyHealth = 10;
    public KillScore score;

    void Start()
    {
        score = FindObjectOfType<KillScore>();
    }

    public void takeDamage(int damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            score.addScore();
            Destroy(gameObject);
        }
    }
}
