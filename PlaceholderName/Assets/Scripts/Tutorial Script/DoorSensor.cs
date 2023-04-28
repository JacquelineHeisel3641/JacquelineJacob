/*****************************************************************************
// File Name :         DoorSensor.cs
// Author :            Jacqueline Heisel
// Creation Date :     April 25, 2023
//
// Brief Description : This script recognizes when the player has triggered 
// the 1st door opening
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSensor : MonoBehaviour
{
  /// <summary>
  /// looks for the player running into the door trigger
  /// </summary>
  /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Executes if the collision is the door trigger.
        if (collision.gameObject.name == "Door1Trigger")
        {
            //unlocks the door
            TutorialDoorBehaviour.door1Unlocked = true;
        }

    }
}
