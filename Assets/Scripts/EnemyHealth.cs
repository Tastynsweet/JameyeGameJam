using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int enemyHealth = 10;
    public GameObject healthPickup;
    public KillScore score;
    private SpriteRenderer spriteRenderer;
    private Color originalSpriteColor;

    void Start()
    {
        score = FindObjectOfType<KillScore>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSpriteColor = spriteRenderer.color;
    }

    public void takeDamage(int damage)
    {
        enemyHealth -= damage;
        StartCoroutine(flashRed());

        if (enemyHealth <= 0)
        {
            score.addScore();
            Instantiate(healthPickup, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    IEnumerator flashRed()
    {
        spriteRenderer.color = new Color32(234, 116, 116, 255);
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = originalSpriteColor;
    }
}
