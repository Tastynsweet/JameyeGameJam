using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour
{
    [SerializeField] private float knockbackDuration = 0.03f;
    [SerializeField] private float knockbackSpeed = 20f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            EnemyFollow enemyFollow = other.gameObject.GetComponent<EnemyFollow>();
            RangedEnemyFollow rangedEnemyFollow = other.gameObject.GetComponent<RangedEnemyFollow>();
            if (enemyHealth != null && (enemyFollow != null || rangedEnemyFollow != null))
            {
                enemyHealth.takeDamage(1);
                Vector3 playerToEnemy = other.gameObject.transform.position - transform.parent.gameObject.transform.position;
                enemyFollow.takeKnockback(knockbackSpeed * playerToEnemy.normalized, knockbackDuration);
            }
        }
    }
}
