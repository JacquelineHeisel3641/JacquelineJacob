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

    private bool leadPlayerAssigned = false;

    /// <summary>
    /// Makes camera follow the lead player by accessing the lead player's position 
    /// through the leadPlayer GameObject.
    /// </summary>
    void Update()
    {
        if (leadPlayerAssigned)
        {
            // Makes camera follow the lead player by accessing the lead player's position 
            // through the leadPlayer GameObject.
            gameObject.transform.position = new Vector3(leadPlayer.transform.
                position.x, leadPlayer.transform.position.y, 
                leadPlayer.transform.position.z - 10);
        }
    }

    /// <summary>
    /// Assigns the lead player.
    /// </summary>
    /// <param name="player"></param>
    public void LeadPlayerAssigner(GameObject player)
    {
        //Triggers if leadPlayer is not assigned.
        if (leadPlayerAssigned == false)
        {
            leadPlayer = player;

            leadPlayerAssigned = true;
        }
    }
}
