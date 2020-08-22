using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player;


public class WheelChair : MonoBehaviour
{
    [Header("Dependencies")] 
    public PlayerInputManager PlayerInputManager;
    public PlayerLogic PlayerLogic;


    public Rigidbody Rigidbody;
    public float acceloration = 1;
    public float brake = 3;
    public float maxSpeed = 2;
    public float rotationSpeed = 4;
    private float velocity;

    public float divideSpeedBy = 10;

    public Transform player;

    private bool interactCurState = false;
    private bool interactPrevState = false;

    private void Awake()
    {
        if (PlayerInputManager == null)
            PlayerInputManager = FindObjectOfType<PlayerInputManager>();
    }

    public void Move(PlayerInputStructs.MovementInput movementInput)
    {
        if (movementInput.moveZ == 1)
        {
            if (velocity < 0)
            {
                velocity = Mathf.Clamp(velocity + brake, -maxSpeed, maxSpeed);
            }
            else
            {
                velocity = Mathf.Clamp(velocity + acceloration, -maxSpeed, maxSpeed);
            }
        }
        if (movementInput.moveZ == -1)
        {
            if (velocity > 0)
            {
                velocity = Mathf.Clamp(velocity - brake, -maxSpeed, maxSpeed);
            }
            else
            {
                velocity = Mathf.Clamp(velocity - acceloration, -maxSpeed, maxSpeed);
            }
        }
        if (movementInput.moveZ == 0)
        {
            if (velocity > 0)
            {
                velocity = Mathf.Clamp(velocity - brake, 0, maxSpeed);
            }
            else
            {
                velocity = Mathf.Clamp(velocity + brake, -maxSpeed, 0);
            }
        }

        
        if (movementInput.moveX == 1)
            Rigidbody.MoveRotation(Rigidbody.rotation * Quaternion.Euler(0, rotationSpeed, 0));
        
        if (movementInput.moveX == -1)
            Rigidbody.MoveRotation(Rigidbody.rotation * Quaternion.Euler(0, -rotationSpeed, 0));

        
        Vector3 moveDelta = (transform.forward * velocity / divideSpeedBy);
        
        Rigidbody.MovePosition(Rigidbody.transform.position + moveDelta);

        
    }

    private void Update()
    {
        if(PlayerInputManager.OtherInput.interactInstant)
        {
            interactCurState = true;
        }
    }

    private void FixedUpdate()
    {
        if(interactCurState == true && interactPrevState == true)
        {
            interactCurState = false;
        }
        interactPrevState = interactCurState;
    }

    void OnTriggerStay(Collider other)
    {
        
        if (interactCurState && !PlayerLogic.holdingWheelChair)
        {
            print("Grab wheel chair");
            PlayerLogic.GrabWheelChair();
            interactCurState = false;

        }
        if (interactCurState && PlayerLogic.holdingWheelChair)
        {
            print("Release wheel chair");
            PlayerLogic.ReleaseWheelChair();
            interactCurState = false;

        }
        interactPrevState = false;

    }


    void GrabPlayer()
    {
        //player.transform.parent = this.transform; 
    }
}
