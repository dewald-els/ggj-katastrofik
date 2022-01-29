using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeEnergyMove : MonoBehaviour
{

    public Transform player;
    private Rigidbody2D rb;

    private Vector2 movement;

    public float moveSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Source: https://www.youtube.com/watch?v=4Wh22ynlLyk
        Vector3 direction = player.position - transform.position;
        // Convert to degrees 
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    void FixedUpdate() 
    {
        Move(movement);
    }

    void Move(Vector2 direction)
    {
        Vector2 newPosition = (Vector2)transform.position + (direction * moveSpeed * Time.deltaTime); 
        rb.MovePosition(newPosition);
    }
}
