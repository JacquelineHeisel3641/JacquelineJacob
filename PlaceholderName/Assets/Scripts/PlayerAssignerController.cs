/*****************************************************************************
// File Name :         PlayerAssignerController.cs
// Author :            Jacob Bateman
// Creation Date :     April 11, 2023
//
// Brief Description : Assigns boolean to determine whether the player is player 2.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAssignerController : MonoBehaviour
{
    public bool isPlayer2 = false;

    public bool player1Dead = true;
    public bool player2Dead = true;

    /// <summary>
    /// Sets isPlayer2 to true once player 1 has spawned in.
    /// </summary>
    public void AssignBoolean()
    {
        if(isPlayer2 == false)
        {
            isPlayer2 = true;
            player1Dead = false;
        }
        else
        {
            player2Dead = false;
        }
    }

    public void Player1DiedAssigner()
    {
        GameObject player2 = GameObject.FindGameObjectWithTag("Player2");

        if(player2 != null)
        {

            player2.GetComponent<PlayerMovement>
                ().isPlayer2 = false;
            GameObject.FindGameObjectWithTag("Player2").tag = "Player1";

            player1Dead = true;
            isPlayer2 = false;
        }
    }

    public void Player2DiedAssigner()
    {
        player2Dead = true;
    }
}
