using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : FightBehaviour
{
    
    public float rotationSpeed = 1f;
    private Vector3 rotation =  Vector3.zero;
    
    public Rigidbody rb;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StartStrike(ArmSelect.left);
        }

        if (Input.GetMouseButton(1))
        {
            StartStrike(ArmSelect.right);
        }
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }
    
    //Dépalce le joueur
    void PlayerMovement()
    {
        rotation += new Vector3(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);
        
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        rb.rotation = Quaternion.Euler(rotation);
        Vector3 moveDir = transform.TransformDirection(movement);
        
        rb.MovePosition(rb.position + moveDir * (entityData.speed * Time.fixedDeltaTime));
    }
}