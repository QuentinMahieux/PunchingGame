using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : FightBehaviour
{
    public float rotationSpeed = 1f;
    private Vector3 rotation =  Vector3.zero;
    
    public Rigidbody rb;
    
    public override void Start()
    {
        base.Start();
        FlokManager.instance.players.Add(this);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartStrike(ArmSelect.left);
        }

        if (Input.GetMouseButtonDown(1))
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
        //if(isPunching) return;
        
        rotation += new Vector3(0, Input.GetAxis("Mouse X") , 0);
        
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        //Quaternion.Euler(rotation);
        Vector3 moveDir = transform.TransformDirection(movement);
        
        rb.MoveRotation(Quaternion.Euler(rotation * rotationSpeed));
        rb.MovePosition(rb.position + moveDir * (entityData.speed * Time.fixedDeltaTime));
    }
    

    //Force de déplacement apres avoir frapper
    protected override IEnumerator PushForce(ArmBehaviour arm)
    {
        isPunching = true;
        rb.angularVelocity = Vector3.zero;
        rb.AddForce(transform.forward * arm.data.force, ForceMode.Impulse);
        yield return new WaitForSeconds(arm.data.timeForce);
        rb.angularVelocity = Vector3.zero;
        isPunching = false;
    }
}