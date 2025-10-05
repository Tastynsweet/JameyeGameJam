using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DeathFollow : MonoBehaviour
{
    private GameObject Target;
    private SpriteRenderer spriteRenderer;
    private float distanceToPlayer;
    [SerializeField] private float minDistance = 1.0f;
    [SerializeField] private float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
         FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (Target != null)
        {
            Vector3 follow = Target.transform.position + new Vector3(0,1,0);

            distanceToPlayer = Vector2.Distance(transform.position, follow);
            if (distanceToPlayer >= minDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, follow, speed * Time.deltaTime);

                Vector3 movementVector = follow - transform.position;
                if (movementVector.x > 0)
                {
                    spriteRenderer.flipX = false;
                }
                if (movementVector.x < 0)
                {
                    spriteRenderer.flipX = true;
                }
            }
        }
    }
}
