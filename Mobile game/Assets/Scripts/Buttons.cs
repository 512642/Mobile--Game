using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject player;
    GameObject retry;
    public PlayerMovement playerMovementScript;

    bool jumped = false; 

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

    public void RestartLevel()
    {
        int playerLivesLeft = playerMovementScript.livesRemaining;
        playerLivesLeft = 3;
    }

}
