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
        PlayerPrefs.SetInt("saveTilt", (useTilt ? 1 : 0));
        useTilt = (PlayerPrefs.GetInt("saveTilt") != 0);
    }


}
