using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int enemyHealth = 10;

    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        } 
    }
}
