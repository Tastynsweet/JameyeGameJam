using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int playerHealth = 100;
    [SerializeField] private int soulHealth = 100;
    [SerializeField] private float damageCooldown = 1.0f;
    private float damageTimer = 0f;
    private bool soulMode = false;
    private float soulDecayStart = 0.25f; 
    private float soulDecayTimer = 0;

    public GameObject death;

    // Update is called once per frame
    void Update()
    {
        if (damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
        }
        if (soulDecayTimer > 0)
        {
            soulDecayTimer -= Time.deltaTime;
        } else
        {
            takeSoulDamage(1);
            soulDecayTimer = soulDecayStart;
        }
    }
    public void takeDamage(int damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            Debug.Log("Entering soul mode");
            death.SetActive(true);
            death.transform.position = transform.position;
            soulMode = true;
            soulHealth = 70;
            soulDecayTimer = soulDecayStart;
        }
    }

    public void healDamage(int heal)
    {
        playerHealth += heal;
        if (playerHealth > 100)
        {
            playerHealth = 100;
        }
    }

    public void takeSoulDamage(int damage)
    {
        soulHealth -= damage;
        if (soulHealth <= 0)
        {
            Debug.Log("Player has died");
            Destroy(gameObject);
        }
    }

    public void healSoulDamage(int heal)
    {
        soulHealth += heal;
        if (soulHealth >= 100)
        {
            death.SetActive(false);
            soulMode = false;
            playerHealth = 100;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && Time.time > (damageTimer + damageCooldown))
        {
            if (soulMode)
            {
                takeSoulDamage(5);
            } else
            {
                takeDamage(10);
            }
            damageTimer = Time.time;
        }
    }

    public int getHealth()
    {
        return playerHealth;
    }

    public int getSoulHealth()
    {
        return soulHealth;
    }

    public bool getSoulMode()
    {
        return soulMode;
    }
}
