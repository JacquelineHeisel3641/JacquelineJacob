/*****************************************************************************
// File Name :         StartBehaviour.cs
// Author :            Jacqueline Heisel
// Creation Date :     April 27, 2023
//
// Brief Description : Gets rid of the press anwhere to start button
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartBehaviour : MonoBehaviour
{
    public InputAction startGame;
    public GameObject startButton;


    /// <summary>
    /// button on controler reference
    /// </summary>
    /// <param name="obj"></param>
    private void StartGame_started(InputAction.CallbackContext obj)
    {
        Destroy(startButton);

    }
    private void StartGame_canceled(InputAction.CallbackContext obj)
    {
        //not used yet  
    }
    private void Start()
    {
        //equivalent of get key down
        startGame.started += StartGame_started;

        //equivalent of get key up 
        startGame.canceled += StartGame_canceled;

        startGame.Enable();
    }
 
}
