/*****************************************************************************
// File Name :         InstructionsController.cs
// Author :            Jacqueline Heisel
// Creation Date :     April 12, 2023
//
// Brief Description : This script makes the instructions appear on scren 
// when needed
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class InstructionsController : MonoBehaviour
{
    public Text instructionsText;

    public InputAction doorOpen;
    private InputAction player;

    // Start is called before the first frame update
    void Start()
    {
        //equivalent of get key down
        doorOpen.started += DoorOpen_started;

        
        doorOpen.Enable();

        instructionsText.text = "Left stick = move, Right stick = Rotate, " +
            "X = open door ";
    }
    private void DoorOpen_started(InputAction.CallbackContext obj)
    {
        

    }
    // Update is called once per frame
    void Update()
    {
        if (DoorBehaviour.door1Unlocked)
        {
            instructionsText.text = "Right trigger = shoot, Y = switch weaspons" +
                " Use the squares as" +
                " target practice";
        }
        else if (DoorBehaviour.door2Unlocked)
        {
            instructionsText.text = "Press a to release the zombies " +
                "when you're ready";
        }
        else if (DoorBehaviour.door3Unlocked)
        {
            instructionsText.text = "Solve this maze and use the button in the " +
                "corner to move onto the area when you're ready";
        }
    }
}
