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
        jumpPlayer();
    }

    void movePlayer()
    {
        if (controller.isGrounded)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
            moveDirection = new Vector3(-moveVertical, 0.0f, moveHorizontal);
            if (moveDirection.magnitude > 0.1)
                transform.rotation = Quaternion.LookRotation(moveDirection);
            moveDirection *= defSpeed;
        }

        // ANIMATOR LOCOMOTION SETUP
        anim.SetFloat("vSpeed", moveVertical);
        anim.SetFloat("hSpeed", moveHorizontal);
        
        // MOVEMENT
        controller.Move(moveDirection * Time.deltaTime);
    }

    void jumpPlayer()
    {
        if (controller.isGrounded)
        {
            if (Input.GetButton("Jump"))
                moveDirection.y = defJumpSpeed;
        }
        else
        {
            moveDirection.y -= defGravity;
        }
    }
}
