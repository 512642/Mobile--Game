using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public GameObject respawn;
    public GameObject player;  
    public GameObject jumpButton;
    public Buttons buttonScript;
    public Rigidbody rb;
    public float smooth = 0.1f;
    public float newXRotation;
    public float newZRotation;
    public float sensitivity = 6;
    private Vector3 currentAcceleration, initialAcceleration;
    public float jumpPower = 0;
    public bool getJumped = false;
    public float xSpeed;
    public float speed;
    public FloatingJoystick floatingJoystick;
    public PlayerSettings playerSettingsScript;
    public bool tiltChosen;
    public float maxSpeed = 20;
    public int livesRemaining = 3;
    public bool lifeLeft;
    public bool takeLife;
    public GameObject gameOverText;
    public Text livesCounter;
    public GameObject retryButton;



    // Start is called before the first frame update
    void Start()
    {
        retryButton.SetActive(false);
        gameOverText.SetActive(false);
        initialAcceleration = Input.acceleration;
        currentAcceleration = Vector3.zero;       
    }

    // Update is called once per frame
    void Update()
    {
        HoldMethods();
    }
    //caps the speed at maxSpeed
    public void SetMaxSpeed()
    {
         rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }
    void HoldMethods()
    {
        LivesDisplay();
        JoyStickMovement();
        //Tilt();
        SetMaxSpeed();        
        CheckLivesLeft();
    }

    public void TiltVairables()
    {
        float XDriection;
        float YDirection;

 
    }



    public void RetryLevel()
    {
        player.SetActive(true);
        gameOverText.SetActive(false);
        retryButton.SetActive(false);
        livesRemaining = 3;
        CheckLivesLeft();
    }






   




    
    //places a joystick where the user clicks to move the ball
    public void JoyStickMovement()
    {
        speed = 20;
        Vector3 direction = Vector3.forward * floatingJoystick.Horizontal + Vector3.left * floatingJoystick.Vertical;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }


    public void Respawn()
    {
        takeLife = false;
        if (player.transform.position.y < 1)
        {
            player.transform.position = respawn.transform.position;
            livesRemaining--;

        }
    }
    

    public void LivesDisplay()
    {
        livesCounter.text = "Lives left: " + livesRemaining;
    }

    public void CheckLivesLeft()
    {
        if(livesRemaining > 0)
        {
            Respawn();
            
        }
        else
        {
            player.SetActive(false);
            gameOverText.SetActive(true);
            retryButton.SetActive(true);

        }
    }

    public void Jump(bool getJumped)
    {
        getJumped = true;
        

        if (getJumped == true)
        {
            rb.AddForce(0, jumpPower, 0);
            
        }
     }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "respawn")
        {
            livesRemaining--;
            player.transform.position = respawn.transform.position;
        }

    }




}


    /*access the accelerometer to control the ball
    public void Tilt()
    {
        currentAcceleration = Vector3.Lerp(currentAcceleration, Input.acceleration - initialAcceleration, Time.deltaTime / smooth);

        newZRotation = Mathf.Clamp(currentAcceleration.z * sensitivity, -1, 1);
        newXRotation = Mathf.Clamp(currentAcceleration.x * sensitivity, -1, 1);

        transform.Rotate(0, 0, -newZRotation);
        transform.Rotate(0, -newXRotation, 0 );
        }
        */