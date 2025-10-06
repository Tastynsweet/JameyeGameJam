using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float soulSpeedMultiplier = 1.5f;
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private float scytheCooldown = 0.5f;

    private SpriteRenderer spriteRenderer;
    private PlayerAttack playerAttack;
    private PlayerHealth playerHealth;
    private float attackCooldownTimer = 0f;
    private float scytheCooldownTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerAttack = GetComponent<PlayerAttack>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void FixedUpdate()
    {
        updateMovement();
    }

    // Update is called once per frame
    void Update()
    {
        updateAttack();
    }

    private void updateMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movementDirection = new Vector3(horizontal, vertical, 0);
        movementDirection.Normalize();

        if (movementDirection.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (movementDirection.x < 0)
        {
            spriteRenderer.flipX = true;
        }

        float finalSpeed = speed;
        if (playerHealth.getSoulMode())
        {
            finalSpeed *= soulSpeedMultiplier;
        }

        transform.Translate(Time.deltaTime * finalSpeed * movementDirection);
    }

    private void updateAttack()
    {
        if (attackCooldownTimer <= 0 && scytheCooldownTimer <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                if (playerHealth.getSoulMode())
                {
                    playerAttack.scytheAttack();
                    scytheCooldownTimer = scytheCooldown;
                } else
                {
                    playerAttack.basicSwordAttack();
                    attackCooldownTimer = attackCooldown;
                }
            }
        } else
        {
            attackCooldownTimer -= Time.deltaTime;
            scytheCooldownTimer -= Time.deltaTime;
        }
    }
}
