﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float speed = 12f;
    [SerializeField]
    private float gravity = -9.81f;
    [SerializeField]
    private float jumpHeight = 3f;

    [SerializeField]
    private Transform playerHead = null;
    [SerializeField]
    private CharacterController playerController = null;

    private Vector3 velocity;
    [SerializeField]
    private Transform groundCheck = null;
    [SerializeField]
    private float groundDistance = 0.4f;
    [SerializeField]
    private LayerMask groundMask = default;
    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        movePlayerInput();
        movePlayerGravity();
    }

    private void movePlayerInput()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = (playerHead.right * xInput) + (new Vector3(playerHead.forward.x, 0, playerHead.forward.z) * zInput);

        playerController.Move(moveDirection * speed * Time.deltaTime);
    }

    private void movePlayerGravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && (velocity.y < 0))
        {
            velocity.y = -2;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);
    }
}
