using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    public GameObject TiltSelect;
    public PlayerMovement playerMovement;

    public bool useTilt;
           
    public void MovementChoice()
    {
        useTilt = !useTilt;
    }


}
