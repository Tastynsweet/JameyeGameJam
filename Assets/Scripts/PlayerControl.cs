using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;

    public PlayerAttack playerAttack;

    // Start is called before the first frame update
    void Start()
    {
        
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

        transform.Translate(Time.deltaTime * speed * movementDirection);
    }

    private void updateAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playerAttack.basicSwordAttack();
        }
    }

    private void FixedUpdate()
    {
        updateMovement();
    }
}
