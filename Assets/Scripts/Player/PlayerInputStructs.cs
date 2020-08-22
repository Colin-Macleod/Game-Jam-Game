using UnityEngine;

namespace Player
{
    public class PlayerInputStructs
    {
        public struct MovementInput
        {
            public float moveX;
            public float moveZ;
        }

        public struct OtherInput
        {
            public bool interactConstant;
            public bool interactInstant;
            public bool shoot;
        }
    }
}