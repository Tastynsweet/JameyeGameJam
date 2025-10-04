using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float attackCooldown = 0.5f;

    public SpriteRenderer spriteRenderer;
    public PlayerAttack playerAttack;
    private float attackCooldownTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
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
                playerAttack.basicSwordAttack();
            }
        } else
        {
            attackCooldownTimer -= Time.deltaTime;
        }
    }
}
