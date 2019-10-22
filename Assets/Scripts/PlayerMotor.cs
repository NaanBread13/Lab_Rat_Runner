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
    private float prePauseSpeed;
    public int life = 3;
    public Transform PlayerTransform;
    public Transform PlayerTransform_2;
    public float preSpeed=0;
    public int preLife=0;
    private float waitTime = 1.0f;
    private float timer = 0.0f;
    private int timeTri = 0;

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
        GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2Motor>().setSpeed(speed - 5.0f);
        if (PlayerTransform.position.z - PlayerTransform_2.position.z < 0)
        {
            controller.Move(-Vector3.forward * (PlayerTransform.position.z - PlayerTransform_2.position.z));
        }
        if (PlayerTransform.position.z - PlayerTransform_2.position.z > -0)
        {
            controller.Move(-Vector3.forward * (PlayerTransform.position.z - PlayerTransform_2.position.z));
        }


        if (timeTri ==1)
        {
            timer += Time.deltaTime;

            if (timer > waitTime)
            {

                speed = preSpeed;

                life = preLife;
                timer = timer - waitTime - waitTime;
                timeTri = 0;
            }
        }

    
        if (life <= 0)
        {
            DeathSequence();
        }
       
        if (isDead)
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
        moveVector.y = verticalVelocity;

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
            life -= 1;
            (hit.gameObject.GetComponent(typeof(Collider)) as Collider).isTrigger = true;
            hit.gameObject.tag = "trash";
            string ScriptName = "MoveUp";
            System.Type MyScriptType = System.Type.GetType(ScriptName + ",Assembly-CSharp");
            Debug.Log(124134134141);
            hit.gameObject.AddComponent(MyScriptType);
            if (life == 0)
            {
                DeathSequence();
            }
        }

        if (hit.gameObject.tag == "boost")
        {
            //preLife = life;
            //life = 999999;
            settimmer();
            (hit.gameObject.GetComponent(typeof(Collider)) as Collider).isTrigger = true;
            hit.gameObject.tag = "trash";
            string ScriptName = "MoveUp";
            System.Type MyScriptType = System.Type.GetType(ScriptName + ",Assembly-CSharp");
            hit.gameObject.AddComponent(MyScriptType);
            
            //preSpeed = speed;
            //speed = 30.0f;
            
            //timeTri = 1;
            
        }

    }

    public void settimmer()
    {
        if (timeTri != 1)
        {
            preLife = life;
            life = 999999;
            preSpeed = speed;
            speed = 30.0f;
            timeTri = 1;
        }
        

        
    }
    public void setLife(int a)
    {
        if (a == 0)
        {
            life -= 1;
        }
        else if (a==1)
        {
            life += 1;
        }
            
    }
    private void DeathSequence()
    {
        
        isDead = true;
        GetComponent<Score>().OnDeath();
    }
    public float getSpeed()
    {
        return speed;
    }
    public void pasuse(int a = 0)
    {
        if (a == 0)
        {
            prePauseSpeed = speed;
            speed = 0;
        }
        else
        {
            speed = prePauseSpeed;
        }
    }
}
