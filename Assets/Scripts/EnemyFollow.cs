using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private GameObject Target;
    private float Dis;
    [SerializeField] private float distance = 1.0f;
    [SerializeField] private float speed = 5.0f;

    void Start()
    {
        Target = GameObject.Find("Player");
    }
    void Update()
    {
        if (Target == null) return;

        Dis = Vector2.Distance(transform.position, Target.transform.position);

        if (Dis >= distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);
        }
    }
}
