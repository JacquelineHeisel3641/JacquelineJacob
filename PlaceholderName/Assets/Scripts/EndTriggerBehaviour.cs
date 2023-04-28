/*****************************************************************************
// File Name :         EndTriggerBehaviour.cs
// Author :            Jacqueline Heisel
// Creation Date :     April 27, 2023
//
// Brief Description : This script recognizes when the player has triggered 
// the end of the tutorial
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTriggerBehaviour : MonoBehaviour
{
    /// <summary>
    /// looks for the player running into the door trigger
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Executes if the collision is the door trigger.
        if (collision.gameObject.name == "EndTrigger")
        {
            SceneManager.LoadScene("Level 1");
        }

    }
}
