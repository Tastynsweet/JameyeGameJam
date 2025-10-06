using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private Vector3 direction = new Vector3(0,0,0);

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        float x = transform.position.x;
        float y = transform.position.y;
        if (x > 70 || x < -70)
        {
            Destroy(gameObject);
        }

        if (y > 35 || y < -64)
        {
            Destroy(gameObject);
        }
    }

    public void setDirection(Vector3 newDirection)
    {
        direction = newDirection;
    }
}
