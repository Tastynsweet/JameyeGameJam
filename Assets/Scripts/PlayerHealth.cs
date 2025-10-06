using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int playerHealth = 100;
    [SerializeField] private int soulHealth = 100;
    [SerializeField] private float damageCooldown = 0.5f;
    [SerializeField] private FullScreenEffectController fullScreenEffectController;
    [SerializeField] private HealthText healthText;
    [SerializeField] private HealthFillController healthFillController;
    private float damageTimer = 0f;
    private bool soulMode = false;
    private float soulDecayStart = 0.2f; 
    private float soulDecayTimer = 0;
    private SpriteRenderer spriteRenderer;
    private Color originalSpriteColor;

    private float damageMultiplierTimer = 0f;

    public GameObject death;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSpriteColor = spriteRenderer.color;
        fullScreenEffectController.enableFogShader();
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
            if (getSoulMode())
            {
                takeSoulDamage(1);
                soulDecayTimer = soulDecayStart;
            }
        }
        damageMultiplierTimer += Time.deltaTime;
    }



    // When player goes from normal mode to soul mode
    private void normalToSoul()
    {
        Debug.Log("Entering soul mode");
        death.SetActive(true);
        fullScreenEffectController.enableSoulShader();
        death.transform.position = transform.position + new Vector3(0, 1, 0);
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



    private float damageTimerToMultiplier()
    {
        return 1f + (damageMultiplierTimer / 300f);
    }

    public void takeDamage(int damage)
    {
        playerHealth -= (int) (damage * damageTimerToMultiplier());
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
        soulHealth = (int)(damage * damageTimerToMultiplier());
        if (soulHealth <= 0)
        {
            Debug.Log("Player has died");
            soulHealth = 0;
            fullScreenEffectController.disableAllShaders();
            Destroy(gameObject);
            SceneManager.LoadSceneAsync(2);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile") && Time.time > (damageTimer + damageCooldown))
        {
            EnemyAttack enemyAttack = other.gameObject.GetComponent<EnemyAttack>();
            int damage = enemyAttack.getDamage();

            if (soulMode)
            {
                takeSoulDamage(damage / 4);
                spriteRenderer.color = new Color32(166, 91, 91, 255);
                StartCoroutine(flashRed());
            }
            else
            {
                takeDamage(damage);
            }
            damageTimer = Time.time;

            Destroy(other.gameObject);
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
