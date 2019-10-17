using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Motor : MonoBehaviour
{
    private CharacterController controller2;
    private float speed = 5.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 10.0f;
    private Vector3 moveVector;
    private float animationDuration = 0.5f;
    private bool isDead = false;
    private float startTime;


    // Start is called before the first frame update
    void Start()
    {
        controller2 = GetComponent<CharacterController>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (isDead)
        {
            return;
        }
        if (Time.time - startTime < animationDuration)
        {
            controller2.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
        moveVector = Vector3.zero;

        if (controller2.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        // Left and Right
        moveVector.x = Input.GetAxisRaw("Horizontal1") * speed;
        // Up
        moveVector.y = verticalVelocity;

        // Forwards
        moveVector.z = speed;

        controller2.Move(moveVector * Time.deltaTime);
    }

    public void setSpeed(float modifier)
    {
        speed = 5.0f + modifier;
    }

    // Called wvery time player hits something
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {

            (hit.gameObject.GetComponent(typeof(Collider)) as Collider).isTrigger = true;
            hit.gameObject.tag = "trash";
            string ScriptName = "MoveUp";
            System.Type MyScriptType = System.Type.GetType(ScriptName + ",Assembly-CSharp");
            hit.gameObject.AddComponent(MyScriptType);

            GameObject go = GameObject.Find("Player");
            PlayerMotor other = (PlayerMotor)go.GetComponent(typeof(PlayerMotor));
            other.setLife(0);

        }
    }



    private void DeathSequence()
    {
        isDead = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Score>().OnDeath();
    }
}

