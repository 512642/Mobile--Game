using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public bool jumped = false; 

    public void Jumping(bool jumped)
    {       
        jumped = true;

        if(jumped == true)
        {
            print("pressed");
        }     
    }


    public void ChangeToGameScene()
    {
        SceneManager.LoadScene("Level_1");
    }


}
