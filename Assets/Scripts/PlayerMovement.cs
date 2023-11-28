using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    private float walkSpeed = 5f;
    private float runSpeed = 7f;

    private Vector3 moveDirection;
    private Vector3 moveDirectionZ;
    private Vector3 moveDirectionX;
    private Vector3 velocity;

    private float gravityValue = -9.81f;
    private float jumpHeight = 3f;

    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        moveDirectionZ = new Vector3(0, 0, moveZ);
        moveDirectionX = new Vector3(moveX, 0, 0);
        moveDirection = transform.TransformDirection(moveDirectionZ + moveDirectionX);

        if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            Walk();
        }

        else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }

        if (characterController.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
            if (moveDirection != Vector3.zero)
            {
                Idle();
            }
        }

        velocity.y += gravityValue * Time.deltaTime;
        moveDirection += velocity;
        characterController.Move(moveDirection * Time.deltaTime);

    }

    private void Walk() 
    {
        moveDirection *= walkSpeed;
    }
    private void Run() 
    { 
        moveDirection *= runSpeed;
    }
    private void Jump() 
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravityValue);
    }
    private void Idle() 
    { }
}
