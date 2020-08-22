using System;
using UnityEngine;

namespace Player
{
    public class PlayerInputManager : MonoBehaviour
    {
        private PlayerInputStructs.MovementInput _movementInput;

        public PlayerInputStructs.MovementInput MovementInput
        {
            get { return _movementInput; }
        }
        
        private PlayerInputStructs.OtherInput _otherInput;

        public PlayerInputStructs.OtherInput OtherInput
        {
            get { return _otherInput; }
        }

        private void Update()
        {
            UpdateMovementInput();
            UpdateOtherInput();
        }


        private void UpdateMovementInput()
        {
            PlayerInputStructs.MovementInput moveInput;
            
            
            moveInput.moveX = Input.GetAxisRaw("Horizontal"); //Forward/back
            moveInput.moveZ = Input.GetAxisRaw("Vertical"); //Left/Right


            _movementInput = moveInput;
        }

        private void UpdateOtherInput()
        {
            PlayerInputStructs.OtherInput otherInput;

            otherInput.interactConstant = Input.GetKey(KeyCode.E);
            otherInput.interactInstant = Input.GetKeyDown(KeyCode.E);
            otherInput.shoot = Input.GetKeyDown(KeyCode.Mouse0);

            _otherInput = otherInput;
        }
    }
}