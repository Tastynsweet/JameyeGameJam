using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float attackCooldown = 0.5f;

    private SpriteRenderer spriteRenderer;
    private PlayerAttack playerAttack;
    private PlayerHealth playerHealth;
    private float attackCooldownTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerAttack = GetComponent<PlayerAttack>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        updateMovement();
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

        transform.Translate(Time.deltaTime * speed * movementDirection);
    }

    private void updateAttack()
    {
        if (attackCooldownTimer <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                attackCooldownTimer = attackCooldown;
                if (playerHealth.getSoulMode())
                {
                    playerAttack.scytheAttack();
                } else
                {
                    playerAttack.basicSwordAttack();
                }
            }
        } else
        {
            attackCooldownTimer -= Time.deltaTime;
        }
    }
}
