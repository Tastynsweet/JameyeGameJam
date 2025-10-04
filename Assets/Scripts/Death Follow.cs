using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DeathFollow : MonoBehaviour
{
    private GameObject Target;
    private float distanceToPlayer;
    [SerializeField] private float minDistance = 1.0f;
    [SerializeField] private float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("Player");
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
            distanceToPlayer = Vector2.Distance(transform.position, Target.transform.position);
            if (distanceToPlayer >= minDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);
            }
        }
    }
}
