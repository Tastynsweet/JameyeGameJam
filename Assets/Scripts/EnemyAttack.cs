using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class EnemyAttack : MonoBehaviour
{
    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    public abstract int getDamage();
}
