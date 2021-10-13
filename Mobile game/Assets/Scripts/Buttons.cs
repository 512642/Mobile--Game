using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public bool pressedButton;
    public bool jumped;    

    public void GetJump(bool Jumped)
    {


        if(pressedButton == true)
        {
            jumped = true;
            print("pressed");
        } 
        if(jumped == true)
        {
            jumped = false;
            pressedButton = false;
        }

    }

    public void pressed()
    {
        pressedButton = true;
    }
}
