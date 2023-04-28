/*****************************************************************************
// File Name :         WinScreenBehaviour.cs
// Author :            Jacob Bateman
// Creation Date :     April 27, 2023
//
// Brief Description : Handles functions related to the win screen.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenBehavior : MonoBehaviour
{
    /// <summary>
    /// Sends the player to the main menu.
    /// </summary>
    public void ToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
