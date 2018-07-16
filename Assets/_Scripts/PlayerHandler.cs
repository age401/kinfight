using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour {

    // Movement Levers
    [SerializeField] float defSpeed = 10;
    [SerializeField] float defJumpSpeed = 8;
    [SerializeField] float defGravity = 1;
    // Movement
    private Vector3 moveDirection = Vector3.zero;

    // Components
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= defSpeed;
            if (Input.GetButton("Jump"))
                moveDirection.y = defJumpSpeed;

        }
        else
        {
            moveDirection.y -= defGravity * Time.deltaTime;
        }

        controller.Move(moveDirection * Time.deltaTime);

    }
}
