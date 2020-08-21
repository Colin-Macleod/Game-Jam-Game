using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public Transform cam;


    private float mouseX;
    private float mouseY;

    [SerializeField]
    public float sensitivity = 5.0f;
    [SerializeField]
    public float smoothing = 2.0f;

    public Vector2 smoothVelocity;

    public Vector2 mouseLook;

    public float minAngle;
    public float maxAngle;

    public GameObject character;
    public GameObject player;
    //public GameObject weapon;

    private Animator gunAnim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Cursor.lockState = CursorLockMode.Locked;
        //gunAnim = weapon.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (player.GetComponent<PlayerStats>().died || player.GetComponent<PlayerStats>().paused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
            HandleInput();
            MoveCamera();
        }*/

        HandleInput();
        MoveCamera();

        WeaponSway();
    }

    void fixedUpdate()
    {
        //MoveCamera();
    }

    void HandleInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        Vector2 mouseDelta = new Vector2(mouseX, mouseY);
        Vector2 mouseSmooth = new Vector2(sensitivity * smoothing, sensitivity * smoothing);
        mouseDelta = Vector2.Scale(mouseDelta, mouseSmooth);

        smoothVelocity.x = Mathf.Lerp(smoothVelocity.x, mouseDelta.x, 1f / smoothing);
        smoothVelocity.y = Mathf.Lerp(smoothVelocity.y, mouseDelta.y, 1f / smoothing);

        mouseLook += smoothVelocity;
        mouseLook.y = Mathf.Clamp(mouseLook.y, minAngle, maxAngle);

    }

    void MoveCamera()
    {
        cam.transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }

    public void WeaponSway()
    {
        
        //Rotate weapon in direction of camera movement
        //weapon.transform.rotation = Quaternion.Euler()
    }
}
