using System;
using UnityEngine;

public class PlayerControlller : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5.0f;
    public float gravity = -9.81f;

    private float verticalVelocity;

    [Header("Camera")]
    public Camera playerCamera;
    public Transform cameraTransform;

    [Header("Animation")]
    public Animator animator;
    public Transform modelTransform;

    private CharacterController controller;
    private PlayerInputActions controls;
    private Vector2 moveInput;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        controls = new PlayerInputActions();

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    private void OnEnable() { controls.Player.Enable(); }
    private void OnDisable() { controls.Player.Disable(); }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        //Move based on camera position
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();

        Vector3 move = (camForward * moveInput.y + camRight * moveInput.x);
        if (move.sqrMagnitude > 1f) move.Normalize();

        //Rotate based on movement direction
        if (move.sqrMagnitude > 0.0001f)
        {
            Quaternion targerRotation = Quaternion.LookRotation(move, Vector3.up);
            modelTransform.rotation = targerRotation;
        }

        //gravity

        if (controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

         //move in direction
         Vector3 velocity = move * moveSpeed + Vector3.up * verticalVelocity;

        controller.Move(velocity * Time.deltaTime);



        //Update animation
        Vector3 horizontalVelocity = new Vector3(velocity.x, 0, velocity.z);
        animator.SetFloat("speed", horizontalVelocity.magnitude);
    }
}
