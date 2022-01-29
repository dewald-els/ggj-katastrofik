using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rigidBody;

    private Vector2 moveDirection;

    void Update()
    {
        // Process Inputs
        ProcessInputs();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Physics Calcs
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        // Normalized - Prevents "speed boost" when moving at diagonal axis.
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rigidBody.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
