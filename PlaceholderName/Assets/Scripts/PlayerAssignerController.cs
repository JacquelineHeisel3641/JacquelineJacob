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
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerAssignerController : MonoBehaviour
{
    public bool isPlayer2 = false;

    public bool player1Dead = true;
    public bool player2Dead = true;

    public GameObject player1;
    public GameObject player2;

    public GameObject mainCamera;

    public PlayerInputManager playerInputController;

    /// <summary>
    /// Disables join by button press once both players have joined.
    /// </summary>
    private void Update()
    {
        if(player1 && player2 != null)
        {
            //Changes join behavior to manual joining.
            playerInputController.GetComponent<PlayerInputManager>().joinBehavior = 
                PlayerJoinBehavior.JoinPlayersManually;
        }

        if (player1 == null && player2 == null && gameObject.GetComponent
            <GameController>().gameStarted == true)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    /// <summary>
    /// Sets isPlayer2 to true once player 1 has spawned in.
    /// </summary>
    public void AssignBoolean(GameObject player)
    {
        if(isPlayer2 == false)
        {
            isPlayer2 = true;
            //player1Dead = false;

            player1 = player;
        }
        else
        {
            //player2Dead = false;

            player2 = player;
        }
    }

    /// <summary>
    /// Handles functions that execute when player 1 dies.
    /// </summary>
    public void Player1DiedAssigner()
    {
        player2.tag = "Player1";

        GameObject switchHealthbar = GameObject.FindGameObjectWithTag
            ("P2Healthbar");

        switchHealthbar.tag = "P1Healthbar";

        //Sets player 1 to the lead player.
        mainCamera.GetComponent<TestLeadPlayerAssigning>().
            LeadPlayerAssigner(player2, true);
    }
}
