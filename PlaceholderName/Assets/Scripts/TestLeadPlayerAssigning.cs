/*****************************************************************************
// File Name :         TestLeadPlayerAssigning.cs
// Author :            Jacob Bateman
// Creation Date :     April 6, 2023
//
// Brief Description : Assigns the lead player and sets the camera to follow them.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLeadPlayerAssigning : MonoBehaviour
{
    public GameObject leadPlayer;
    public GameObject player1;
    public GameObject player2;

    private bool leadPlayerAssigned = false;

    [SerializeField] private float cameraScale = 3;

    private Vector3 player1Pos;
    private Vector3 player2Pos;

    /// <summary>
    /// Makes camera follow the lead player by accessing the lead player's position 
    /// through the leadPlayer GameObject.
    /// </summary>
    void Update()
    {
        if (player2 == null)
        {
            if (leadPlayer != null)
            {
                // Makes camera follow the lead player by accessing the lead player's
                // position through the leadPlayer GameObject.
                gameObject.transform.position = new Vector3(leadPlayer.transform.
                    position.x, leadPlayer.transform.position.y,
                    leadPlayer.transform.position.z - 10);
            }
        }
        else
        {
            player1Pos = player1.transform.position;
            player2Pos = player2.transform.position;

            transform.position = new Vector3((player1Pos.x + player2Pos.y) / 2, 
                (player1Pos.y + player2Pos.y) / 2, -5);
        }

        if(player2 != null)
        {
            if (Vector3.Distance(player1Pos, player2Pos) > 5)
            {
                if(Vector3.Distance(player1Pos, player2Pos) - 3 > 5)
                {
                    GetComponent<Camera>().orthographicSize = Vector3.Distance
                        (player1Pos, player2Pos) - 3f;
                }
                else
                {
                    GetComponent<Camera>().orthographicSize = 5f;
                }
            }
            else
            {
                GetComponent<Camera>().orthographicSize = 5f;
            }
        }
    }

    /// <summary>
    /// Assigns the lead player.
    /// </summary>
    /// <param name="player"> Takes a player as input. </param>
    /// <param name="deathCall"> Boolean to determine whether it is being called on 
    /// player death. </param>
    public void LeadPlayerAssigner(GameObject player, bool deathCall)
    {
        //Triggers if leadPlayer is not assigned.
        if (leadPlayerAssigned == false)
        {
            leadPlayer = player;

            player1 = player;

            leadPlayerAssigned = true;
        }
        else if (leadPlayerAssigned == true && !deathCall)
        {
            player2 = player;
        }
        else if (deathCall)
        {
            leadPlayer = player;

            player1 = player;
        }
    }
}
