using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //public GameObject camera;
    //Camera cr;
    float movementX;
    float movementZ;
    Rigidbody rb;
    public float speed;
    public GameObject RollingSound;
    [SerializeField] GameObject RespawnPanel;
    Vector3 StartPos;
    public VariableJoystick Joystick;
    bool isRespawend = false;
    public CollisionHandler CollisionHandler;
    public float JumpSpeed=5;

    void Start()
    {
        CollisionHandler.isControllsEnabled = true;
        rb = transform.GetComponent<Rigidbody>();
        StartPos = rb.transform.position;
        rb.drag = 1;
        RollingSound.SetActive(false);
        RespawnPanel.SetActive(false);

    }
    private void Update()
    {
        PlayRollingSound();
        KEyBoardPlayerJump();


    }
    void FixedUpdate()
    {
        if (CollisionHandler.isControllsEnabled == true)
        {

            keyboardMovement();
            JoyStickMovement();

        }


    }

    void KEyBoardPlayerJump()
    {
        if (Input.GetKeyDown("space"))
        {
            if (CollisionHandler.isInAir == false)
            {
                rb.AddForce(Vector3.up * JumpSpeed);
            }

        }
    }
    void keyboardMovement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * speed);
        }
       
    }
    void JoyStickMovement()
    {
        movementX = Joystick.Horizontal;
        Vector3 direction = new Vector3(movementX, 0f, 0f);
        rb.AddForce(direction * speed);
    }
    public void JoystickOnJumpPressed()
    {
        if (CollisionHandler.isInAir == false)
        {
            rb.AddForce(Vector3.up * JumpSpeed);
        }
    }
    

   
    public void PlayRollingSound()
    {
        if (CollisionHandler.isInAir == false)
        {

            if (rb.velocity.z >= 0.9 || rb.velocity.z <= -0.9 || rb.velocity.x >= 0.9 || rb.velocity.x <= -0.9)
            {
                RollingSound.SetActive(true);
            }
            else
            {
                RollingSound.SetActive(false);
            }


        }
        else
        {
            RollingSound.SetActive(false);
        }


    }
    public void OnRespawnBtnClicked()
    {
        CollisionHandler.isControllsEnabled = true;
        isRespawend = true;
        transform.parent.parent = null;
        rb.transform.position = StartPos;
        gameObject.SetActive(true);
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
        rb.Sleep();
        if (isRespawend == true)
        {
            rb.drag = 1;
        }
        RespawnPanel.SetActive(false);
        
        
        
    }
    
    
}
