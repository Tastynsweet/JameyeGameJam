using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RangedEnemyFollow : MonoBehaviour
{
    private GameObject Target;
    private SpriteRenderer spriteRenderer;
    private float distanceToPlayer;
    [SerializeField] private float minDistance = 5.0f;
    [SerializeField] private float speed = 5.0f;

    private bool isStunned = false;
    private float remainingStunTime = 0f;
    private Vector3 knockbackVector = Vector3.zero;

    private float rangedAttackCooldown = 3f;
    private float rangedAttackTime = 0f;
    public GameObject fireball;

    void Start()
    {
        Target = GameObject.Find("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (isStunned)
        {
            if (remainingStunTime <= 0f) // enemy is no longer stunned
            {
                isStunned = false;
            }
            else // enemy is stunned, take knockback and countdown stun time
            {
                remainingStunTime -= Time.deltaTime;
                transform.position = transform.position + Time.deltaTime * knockbackVector;
            }
        }
        else
        {
            followPlayer();
            if (rangedAttackTime <= 0)
            {
                shootProjectile();
                rangedAttackTime = rangedAttackCooldown;
            } else
            {
                rangedAttackTime -= Time.deltaTime;
            }
        }
    }

    // moves this enemy directly towards the player
    private void followPlayer()
    {
        if (Target != null)
        {
            Vector3 movementVector = Target.transform.position - transform.position;
            if (movementVector.x > 0)
            {
                spriteRenderer.flipX = true;
            }
            if (movementVector.x < 0)
            {
                spriteRenderer.flipX = false;
            }

            distanceToPlayer = Vector2.Distance(transform.position, Target.transform.position);
            if (distanceToPlayer >= minDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);
            }
        }
    }

    public void takeKnockback(Vector3 knockback, float stunTime)
    {
        isStunned = true;
        remainingStunTime = stunTime;
        knockbackVector = knockback;
    }

    private void shootProjectile()
    {
        Vector3 movementVector = Target.transform.position - transform.position;
        GameObject projectile = Instantiate(fireball, transform.position, Quaternion.identity);
        FireballMovement fireballMovement = projectile.GetComponent<FireballMovement>();
        fireballMovement.setDirection(movementVector.normalized);
    }
}
