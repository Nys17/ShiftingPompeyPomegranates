using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // player movement speed

    // Update is called once per frame
    void Update()
    {
        // get input from the WASD keys
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // calculate the movement direction based on input
        Vector3 movement = new Vector3(0f, 0f, 0f);
        if (Input.GetKey(KeyCode.W))
        {
            movement += new Vector3(0f, 0f, 1f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += new Vector3(0f, 0f, -1f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement += new Vector3(-1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += new Vector3(1f, 0f, 0f);
        }
        movement = movement.normalized;

        // move the player based on the movement direction and speed
        transform.position += movement * speed * Time.deltaTime;

    }
}