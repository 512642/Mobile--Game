using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject respawn;
    public GameObject player;  
    public GameObject jumpButton;
    public Buttons buttonScript;
    public Rigidbody rb;
    public float smooth = 0.4f;
    public float newRotation;
    public float sensitivity = 6;
    private Vector3 currentAcceleration, initialAcceleration;
    public float jumpPower = 0;
    public bool getJumped = false;
    public float xSpeed;
    public float speed;
    public VariableJoystick variableJoystick;






    // Start is called before the first frame update
    void Start()
    {
        initialAcceleration = Input.acceleration;
        currentAcceleration = Vector3.zero;       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        JoyStickMovement();
        KeyBoardMovement();
        Respawn();
    }


    void Tilt()
    {

        currentAcceleration = Vector3.Lerp(currentAcceleration, Input.acceleration - initialAcceleration, Time.deltaTime / smooth);

        newRotation = Mathf.Clamp(currentAcceleration.x * sensitivity, -1, 1);

        transform.Rotate(0, 0, -newRotation);
    }

    void JoyStickMovement()
    {
        speed = 30;
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

   void KeyBoardMovement()
    {


        if (Input.GetKey("a"))
        {
            transform.position += new Vector3(0, 0, -xSpeed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            transform.position += new Vector3(0, 0, xSpeed * Time.deltaTime);
        }
        if (Input.GetKey("w"))
        {
            transform.position += new Vector3(-xSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            transform.position += new Vector3(xSpeed * Time.deltaTime, 0, 0);
        }
    }

    public void Respawn()
    {
        if (player.transform.position.y < 1)
        {
            player.transform.position = respawn.transform.position;
        }
    }

    public void Jump(bool getJumped)
    {
        getJumped = true;
        

        if (getJumped == true)
        {
            rb.AddForce(transform.up * jumpPower);
            
        }
     }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "respawn")
        {
            player.transform.position = respawn.transform.position;
        }
    }

}