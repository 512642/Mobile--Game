using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public GameObject player;  
    public GameObject jumpButton;
    public Buttons buttonScript;
    public Rigidbody rb;
    public float smooth = 0.4f;
    public float newRotation;
    public float sensitivity = 6;
    private Vector3 currentAcceleration, initialAcceleration;
    public float jumpPower = 0;
    public bool getJumped;    
    public bool hasJumped;





    // Start is called before the first frame update
    void Start()
    {
        initialAcceleration = Input.acceleration;
        currentAcceleration = Vector3.zero;
       
       
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        GetButtonScript();
    }


    void Tilt()
    {

        currentAcceleration = Vector3.Lerp(currentAcceleration, Input.acceleration - initialAcceleration, Time.deltaTime / smooth);

        newRotation = Mathf.Clamp(currentAcceleration.x * sensitivity, -1, 1);

        transform.Rotate(0, 0, -newRotation);
    }

    void Jump()
    {

        if (getJumped == true)
        {
            print("i can jump");
            jumpPower = 20;
            rb.AddForce(0, jumpPower * Time.deltaTime, 0);
        }
        else
        {
            getJumped = false;
        }



    }

    void GetButtonScript()
    {
        
        buttonScript = jumpButton.GetComponent<Buttons>();
        getJumped = buttonScript.jumped;

    }
        
}



