using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    enum GravityAxis
    {
        x = 0,
        y = 1
    }

    [SerializeField] private CharacterController controller;
    [SerializeField] private Vector3 playerVelocity;
    [SerializeField] private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] public float gravityValue = -9.81f;
    private bool playerVelocityChanged = true;
    private bool isCollided;
    public int gravityAxis = (int)GravityAxis.y;
    public int gravityDirection = -1;


    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        if (playerVelocityChanged || !isCollided)
        {
            groundedPlayer = controller.isGrounded;
        }

        if (groundedPlayer && playerVelocity.y <= 0)
        {
            playerVelocityChanged = false;
            playerVelocity.y = 0f;
        }

        if (playerVelocity.y > 0)
        {
            playerVelocityChanged = true;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        isCollided = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isCollided = false;
    }

}
