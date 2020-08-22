using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerLogic : MonoBehaviour
    {
        [Header("Dependencies")] 
        public PlayerControl PlayerControl;
        public PlayerInputManager PlayerInputManager;
        public WheelChair WheelChair;


        public bool holdingWheelChair = false;

        private Transform previusTransform;
        //public CamControl CamControl;

        private void Awake()
        {
            WheelChair = FindObjectOfType<WheelChair>();
        }

        private void Update()
        {
            if (holdingWheelChair && PlayerInputManager.OtherInput.interactInstant)
                ReleaseWheelChair();
        }


        private void FixedUpdate()
        {
            if(holdingWheelChair)
                WheelChair.Move(PlayerInputManager.MovementInput);
            else
                PlayerControl.MovePlayer(PlayerInputManager.MovementInput);

            //print($"input {PlayerInputManager.MovementInput.moveX}, {PlayerInputManager.MovementInput.moveZ} ");
        }


        public void GrabWheelChair()
        {
            //previusTransform = this.transform.parent;
            holdingWheelChair = true;
            //this.transform.parent = WheelChair.Rigidbody.transform;
        }

        public void ReleaseWheelChair()
        {
            //this.transform.parent = previusTransform;
            holdingWheelChair = false;
        }

        public void Move(Vector3 move)
        {
            PlayerControl.rb.MovePosition(PlayerControl.rb.position + move);
        }
    }
}