using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int playerHealth = 100;
    [SerializeField] private float damageCooldown = 1.0f;
    private float damageTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        if (damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
        }
    }
    public void takeDamage(int damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            Debug.Log("Player Dead");
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && Time.time > (damageTimer + damageCooldown))
        {
            takeDamage(10);
            damageTimer = Time.time;
        }
    }

    public int GetHealth()
    {
        return playerHealth;
    }
}
