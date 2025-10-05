using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int playerHealth = 100;
    [SerializeField] private int soulHealth = 100;
    [SerializeField] private float damageCooldown = 1.0f;
    [SerializeField] private FullScreenEffectController fullScreenEffectController;
    [SerializeField] private HealthText healthText;
    [SerializeField] private HealthFillController healthFillController;
    private float damageTimer = 0f;
    private bool soulMode = false;
    private float soulDecayStart = 0.25f; 
    private float soulDecayTimer = 0;
    private SpriteRenderer spriteRenderer;
    private Color originalSpriteColor;

    public GameObject death;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSpriteColor = spriteRenderer.color;
    }

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



    // When player goes from normal mode to soul mode
    private void normalToSoul()
    {
        Debug.Log("Entering soul mode");
        death.SetActive(true);
        fullScreenEffectController.enableSoulShader();
        death.transform.position = transform.position;
        soulMode = true;
        healthText.setSoulHeart();
        healthFillController.setSoulColor();
        soulHealth = 70;
        soulDecayTimer = soulDecayStart;
    }

    // When player goes from soul mode to normal mode
    private void soulToNormal()
    {
        death.SetActive(false);
        fullScreenEffectController.enableFogShader();
        soulMode = false;
        healthText.setNormalHeart();
        healthFillController.setNormalColor();
        playerHealth = 100;
    }

    // updates all health related elements in the UI
    private void updateHealthUI()
    {
        if (getSoulMode())
        {
            healthText.setHealth(soulHealth);
            healthFillController.setHealth(soulHealth);
        }
        else
        {
            healthText.setHealth(playerHealth);
            healthFillController.setHealth(playerHealth);
        }
    }




    public void takeDamage(int damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            normalToSoul();
        }
        updateHealthUI();

        spriteRenderer.color = new Color32(166, 91, 91, 255);
        StartCoroutine(flashRed());
    }

    IEnumerator flashRed()
    {
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = originalSpriteColor;
    }

    public void healDamage(int heal)
    {
        playerHealth += heal;
        if (playerHealth > 100)
        {
            playerHealth = 100;
        }
        updateHealthUI();
    }

    public void takeSoulDamage(int damage)
    {
        soulHealth -= damage;
        if (soulHealth <= 0)
        {
            Debug.Log("Player has died");
            soulHealth = 0;
            fullScreenEffectController.disableAllShaders();
            Destroy(gameObject);
        }
        updateHealthUI();
    }

    public void healSoulDamage(int heal)
    {
        soulHealth += heal;
        if (soulHealth >= 100)
        {
            soulToNormal();
        }
        updateHealthUI();
    }

    public void healPickup(int heal)
    {
        if (getSoulMode())
        {
            healSoulDamage(heal);
        } else
        {
            healDamage(heal);
        }
    }



    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && Time.time > (damageTimer + damageCooldown))
        {
            EnemyAttack enemyAttack = other.gameObject.GetComponent<EnemyAttack>();
            int damage = enemyAttack.getDamage();

            if (soulMode)
            {
                takeSoulDamage(damage/2);
                spriteRenderer.color = new Color32(166, 91, 91, 255);
                StartCoroutine(flashRed());
            } else
            {
                takeDamage(damage);
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
