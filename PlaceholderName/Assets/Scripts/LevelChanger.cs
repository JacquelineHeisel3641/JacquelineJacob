/*****************************************************************************
// File Name :         LevelChanger.cs
// Author :            Jacob Bateman
// Creation Date :     April 16, 2023
//
// Brief Description : Meant to handle changing of scenes for alpha playtest.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    /// <summary>
    /// Sends player to the win screen upon contact with exit trigger.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player1"))
        {
            SceneManager.LoadScene("WinScreen");
        }
    }

    /// <summary>
    /// Loads the main menu.
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
