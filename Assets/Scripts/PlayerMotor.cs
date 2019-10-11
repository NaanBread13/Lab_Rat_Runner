using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
*/
public class PlayerMotor : MonoBehaviour
{

    // These variables contain the variables
    private CharacterController controller;
    public float speed = 5.0f;
    private float verticalVelocity = 0.0f;
    public float jumpForce = 20.0f;
    public float gravity = 110.0f;
    private Vector3 moveVector;
    private float animationDuration = 0.5f;
    private bool isDead = false;
    private float startTime;
    private float prePauseSpeed;
    public int life = 3;
    public Transform PlayerTransform;
    public Transform PlayerTransform_2;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        startTime = Time.time;
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerTransform_2 = GameObject.FindGameObjectWithTag("Player2").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // If either player falls down off the platform, they die.
        if (PlayerTransform.position.y < -10 ^ (PlayerTransform_2.position.y < -10))
        {
            DeathSequence();
        }
        // Lives goes to 0 then game over.
        if (life == 0)
        {
            DeathSequence();
        }
        //This is true if the Death Sequence method is called, which makes sure the player is dead
        if (isDead)
        {
            return;
        }
        // 
        if (Time.time - startTime <animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
        //If the player is grounded, the vertical velocity is dependent on the gravity by time 
        // When the player clicks W the vertical velocity = the jumpforce
        // If the player isn't grounded 
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
        moveVector.y = verticalVelocity;

        // Forwards is equal to speed, since the player themselves cant' move forwards
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
    }
    
    // This method sets the speed depending on the modifier  so initially it is just 5 but as the difficulty of the game increases the speed increases.
    public void setSpeed(float modifier)
    {
        speed = 5.0f + modifier;
    }

    // Called every time player hits an enemy object. If they do hit a enemy object, the object disappears and then the player loses a life.
    // Like the previous methods if the l
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Enemy")
        {
            life -= 1;
            (hit.gameObject.GetComponent(typeof(Collider)) as Collider).isTrigger = true;
            hit.gameObject.tag = "trash";
            string ScriptName = "MoveUp";
            System.Type MyScriptType = System.Type.GetType(ScriptName + ",Assembly-CSharp");
            hit.gameObject.AddComponent(MyScriptType);
            if (life == 0)
            {
                DeathSequence();
            }
            
        }
    }

    // This method changes the life for the player depending on integer passed in. 
    public void setLife(int boolIndex)
    {
        if (boolIndex == 0)
        {
            life -= 1;
        }
        else if (boolIndex == 1)
        {
            life += 1;
        }
    }

    // This method sets the boolean isDead to true and calls the OnDeath method from the Score script. (OnDeath method, saves the current scorea and toggles the death Menu On)
    private void DeathSequence()
    {   
        isDead = true;
        GetComponent<Score>().OnDeath();
    }

    // Returns speed
    public float getSpeed()
    {
        return speed;
    }

}
