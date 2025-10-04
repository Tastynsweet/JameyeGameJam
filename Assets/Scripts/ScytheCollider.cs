using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheCollider : MonoBehaviour
{
    [SerializeField] private float knockbackDuration = 0.05f;
    [SerializeField] private float knockbackSpeed = 30f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            EnemyFollow enemyFollow = other.gameObject.GetComponent<EnemyFollow>();
            if (enemyHealth != null && enemyFollow != null)
            {
                enemyHealth.takeDamage(3);
                Vector3 playerToEnemy = other.gameObject.transform.position - transform.parent.gameObject.transform.position;
                enemyFollow.takeKnockback(knockbackSpeed * playerToEnemy.normalized, knockbackDuration);
            }
        }
    }
}
