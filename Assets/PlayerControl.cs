using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public GameObject cam;

    public Rigidbody rb;

    public float moveSpeed = 5;
    public float airSpeed = 5;

    private float moveX;
    private float moveZ;
    public Vector3 moveDir;

    public float fallSpeed = 1;
    public float jumpForce = 1;
    public bool grounded;
    public bool isJumping = false;

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
        /*if (!this.GetComponent<PlayerStats>().died)
        {
            HandleInput();
        }*/

        HandleInput();

        Vector3 camForward = cam.transform.forward;
        Vector3 camRight = cam.transform.right;
        camForward = new Vector3(camForward.x, 0, camForward.z);

        moveDir = (camForward * moveZ) + (camRight * moveX);
        moveDir.Normalize();

        //MovePlayer(); 

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

        Vector3 cross = Vector3.Cross(groundNormal, moveDir);
        cross = Quaternion.AngleAxis(-90, groundNormal) * cross;
        moveDir = cross;
        Debug.DrawRay(this.transform.position, moveDir * 5, Color.green);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void HandleInput()
    {
        moveX = Input.GetAxisRaw("Horizontal"); //Forward/back
        moveZ = Input.GetAxisRaw("Vertical"); //Left/Right

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            isJumping = true;
        }
    }

    void MovePlayer()
    {


        //transform.Translate(moveDir * moveSpeed * Time.deltaTime);
        if (grounded)
        {

            if (isJumping)
            {
                rb.AddForce((Vector3.up + moveDir * 0.5f) * jumpForce, ForceMode.Impulse);
                isJumping = false;
            }

            rb.MovePosition(this.transform.position + (moveDir * (moveSpeed / 10)));

        }
        else if (!isJumping)
        {
            //if you're not jumping and you're not on the ground then you're just falling
            rb.MovePosition(this.transform.position + (moveDir * (airSpeed / 10)));

            Vector3 gravity = -9.81f * gravityScale * Vector3.up;
            rb.AddForce(gravity, ForceMode.Acceleration);
        }

    }

    public void GunSway()
    {

    }


}
