using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private InputActionReference jumpButton; // Reference to your XR controller
    [SerializeField] private float jumpHeight = 3f; // Adjust this value to control jump height
    [SerializeField] private CharacterController cc;
    [SerializeField] private LayerMask groundLayers;

    private Vector3 movement;
    private float gravity;

    private void Start()
    {
        gravity = Physics.gravity.y;
    }

    private void Update()
    {
        bool _isGrounded = IsGrounded();
        if (jumpButton.action.WasPressedThisFrame() && _isGrounded)
        {
            Jump();
        }

        movement.y += gravity * Time.deltaTime;
        cc.Move(movement * Time.deltaTime);
    }

    private void Jump()
    {
        movement.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, 0.2f, groundLayers);
    }
}
