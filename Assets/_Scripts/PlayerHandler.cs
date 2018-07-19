using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour {

    // Movement Levers
    public float defSpeed = 10;
    public float defJumpSpeed = 8;
    public float defGravity = 1;
    // Movement
    private float moveHorizontal;
    private float moveVertical;
    private Vector3 faceDirection = Vector3.zero;
    private Vector3 moveDirection = Vector3.zero;

    // Components
    CharacterController controller;
    Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        movePlayer();
        if (controller.isGrounded)
        {
            if (Input.GetButton("Jump"))
                moveDirection.y = defJumpSpeed;
        }
        else
        {
            moveDirection.y -= defGravity * Time.deltaTime;
        }
    }

    void movePlayer()
    {
        if (controller.isGrounded)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
            moveDirection = new Vector3(moveHorizontal, 0, moveVertical);
            if (moveDirection.magnitude > 0.01f)
            {
                this.transform.forward = moveDirection;
            }
        }

        controller.Move(moveDirection * defSpeed * Time.deltaTime);
    }
}
