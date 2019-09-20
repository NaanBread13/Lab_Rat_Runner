using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 5.0f;
    private float verticalVelocity = 0.0f;
    public float jumpForce = 20.0f;
    public float gravity = 110.0f;
    private Vector3 moveVector;
    private float animationDuration = 0.5f;
    private bool isDead = false;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            return;
        }
        if (Time.time - startTime <animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        if(controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.W))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        // Left and Right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        // Up
        //moveVector.y = verticalVelocity;

        // Forwards
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
    }
    
    public void setSpeed(float modifier)
    {
        speed = 5.0f + modifier;
    }

    // Called wvery time player hits something
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Enemy")
        {
            DeathSequence();
        }
    }

    private void DeathSequence()
    {
        
        //isDead = false;
        //GetComponent<Score>().OnDeath();
    }
}
