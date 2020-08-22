using UnityEngine;

namespace Player
{
    public class PlayerControl : MonoBehaviour
    {

        [Header("Dependencies")] 
        
        
        
        public GameObject cam;

        public Rigidbody rb;

        public float moveSpeed = .2F;
        public float airSpeed = 1;


        public Vector3 moveDir;

        public float fallSpeed = 1;
        public float jumpForce = 1;
        public bool grounded;

        public float gravityScale = 1;

        private Vector3 groundNormal;

        public GameObject weapon;

        private Vector3 jumpV = Vector3.zero;



        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {


            //Use cross product to find vector orthagonal to moveDir and groundNormal. Rotate that vector 90* about groundNormal to get a vector parralel to arbitrary slopes. 
            //Determine if player is on the ground
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, Vector3.down, out hit, 0.3f))
            {
                grounded = true;
                groundNormal = hit.normal;
                Debug.DrawRay(this.transform.position, groundNormal * 5, Color.green);
            }
            else
            {
                grounded = false;
            }

            
        }

        private void FixedUpdate()
        {
            
        }

        

        public void MovePlayer(PlayerInputStructs.MovementInput moveInput)
        {
            //print($"input in moveplayer {moveInput.moveX}, {moveInput.moveZ} ");
            Vector3 camForward = cam.transform.forward;
            Vector3 camRight = cam.transform.right;
            camForward = new Vector3(camForward.x, 0, camForward.z);
            //print($"camForward {camForward.x}, {camForward.y}, {camForward.z}");

            moveDir = (camForward * moveInput.moveZ) + (camRight * moveInput.moveX);
            //print($"moveDir {moveDir.x}, {moveDir.y}, {moveDir.z}");

            moveDir.Normalize();

            Vector3 cross = Vector3.Cross(groundNormal, moveDir);
            cross = Quaternion.AngleAxis(-90, groundNormal) * cross;
            moveDir = cross;
            Debug.DrawRay(this.transform.position, moveDir * 5, Color.green);


            Vector3 printMoveDir = (moveDir * moveSpeed);
            

            //print($"move DIR {printMoveDir.x}, {printMoveDir.z}");

            rb.MovePosition(this.transform.position + (moveDir * moveSpeed));

            

        }



    }
}
