/*****************************************************************************
// File Name :         DoorBehaviour.cs
// Author :            Jacqueline Heisel
// Creation Date :     April 22, 2023
//
// Brief Description : This script controls the pause menu. 
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuBehaviour : MonoBehaviour
{
    public InputAction openPause;
    public  GameObject pauseMenu;
    // finding the player controls/ is the variable 


    /// <summary>
    /// Sets up the start button as the button being used 
    /// </summary>
    private void Start()
    {
        //equivalent of get key down
        openPause.started += OpenPause_started;

        //equivalent of get key up 
        openPause.canceled += OpenPause_canceled;

        openPause.Enable();
    }

   
    /// <summary>
    /// looks for the start button being pressed and acts when it does
    /// </summary>
    /// <param name="obj"></param>
    private void OpenPause_started(InputAction.CallbackContext obj)
    {

        OpenPauseMenu();


    }

    /// <summary>
    /// Looks for when the start button isn't pressed, does nothing
    /// </summary>
    /// <param name="obj"></param>
    private void OpenPause_canceled(InputAction.CallbackContext obj)
    {
        //not used yet  
    }

   
    /// <summary>
    /// Opens the pause menu 
    /// </summary>
    void OpenPauseMenu()
    {
        //opening the menu 
          pauseMenu.SetActive(true);

        // actually pausing the game 
          Time.timeScale = 0f;
        
       
    }

}
