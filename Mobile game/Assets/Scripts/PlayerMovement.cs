using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public GameObject player;
    public Rigidbody rb;
    public float smooth = 0.4f;
    public float newRotation;
    public float sensitivity = 6;
    private Vector3 currentAcceleration, initialAcceleration;
    public bool getJump;



    public static void Main(string[] args)
    {
        Buttons.GetJump();
    }


    // Start is called before the first frame update
    void Start()
    {
        initialAcceleration = Input.acceleration;
        currentAcceleration = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //GetJump();
        Jump();

    }


    void Tilt()
    {

        currentAcceleration = Vector3.Lerp(currentAcceleration, Input.acceleration - initialAcceleration, Time.deltaTime / smooth);

        newRotation = Mathf.Clamp(currentAcceleration.x * sensitivity, -1, 1);

        transform.Rotate(0, 0, -newRotation);
    }

    void Jump()
    {
        
    }
        
}



