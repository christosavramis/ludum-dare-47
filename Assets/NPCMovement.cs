using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;    

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        // Input
        movement.x = -1;
        movement.y = 0;
    }

    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
