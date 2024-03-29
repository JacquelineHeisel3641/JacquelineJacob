/*****************************************************************************
// File Name :         TutorialDoorBehaviour.cs
// Author :            Jacqueline Heisel
// Creation Date :     April 26, 2023
//
// Brief Description : This script opens and closes doors based on the
// conditions of each room in the tutorial
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class TutorialDoorBehaviour : MonoBehaviour
{
    // bools to check which doors has been opened
    public static bool door1Unlocked;
    public static bool door2Unlocked;
    public static bool door3Unlocked;
    public static bool door4Unlocked;
    public static bool door5Unlocked;
    public static bool door6Unlocked;

    //game objects to assign sections of the tile map to certain doors
    public GameObject door1TileMap;
    public GameObject door2TileMap;
    public GameObject door3TileMap;
    public GameObject door4TileMap;
    public GameObject door5TileMap;
    public GameObject door6TileMap;

    public static int targetsDestoryed; 



    // 
    public InputAction doorOpen;
    private InputAction player;

    /// <summary>
    /// Checking for user input
    /// </summary>
    void Start()
    {

         targetsDestoryed = 0 ;


       //equivalent of get key down
       doorOpen.started += DoorOpen_started;

        //equivalent of get key up 
        doorOpen.canceled += DoorOpen_canceled;

        doorOpen.Enable();
        door1Unlocked = false;

        // door1Unlocked = false;
        door2Unlocked = false;
        door3Unlocked = false;
        door4Unlocked = false;
        door5Unlocked = false;
        door6Unlocked = false;
    }

    private void DoorOpen_canceled(InputAction.CallbackContext obj)
    {
        //not used yet  
    }

    /// <summary>
    /// Unlocking the door when the player presses space
    /// </summary>
    /// <param name="obj"></param>
    private void DoorOpen_started(InputAction.CallbackContext obj)
    {
        if(door1Unlocked && door2Unlocked)
        {
            door3Unlocked = true;
        }
        


    }

    private void Update()
    {
        UnlockDoor();
        CheckTargets();
    }



    /// <summary>
    /// Checking to see which door to unlock based on how many doors the
    /// player has already opened
    /// </summary>
    void UnlockDoor()
    {
        if (door1Unlocked && door2Unlocked && door3Unlocked
           && door4Unlocked && door5Unlocked && door6Unlocked != true)
        {
            door6TileMap.SetActive(false);
            door6Unlocked = true;

        }
        else if (door1Unlocked && door2Unlocked && door3Unlocked
          && door4Unlocked && door5Unlocked != true)
        {
            door5TileMap.SetActive(false);
            door5Unlocked = true;
        }
        else if (door1Unlocked && door2Unlocked && door3Unlocked
            && door4Unlocked != true)
        {
            door4TileMap.SetActive(false);
            door4Unlocked = true;
        }
        else if (door1Unlocked && door2Unlocked && door3Unlocked)
        {
            door3TileMap.SetActive(false);
            door3Unlocked = true;
        }
        else if (door1Unlocked && door2Unlocked)
        {
            door2TileMap.SetActive(false);
            Debug.Log("door 2 is unlocked");
        }
        else if (door1Unlocked)
        {
            door1TileMap.SetActive(false);

        }
         else
        {
            // this is a classic debug log
            Debug.Log("Congradulations! You Broke it. So now you have to fix it.");
        }
    }


   

    void CheckTargets()
    {
        if (targetsDestoryed == 3)
        {
            door2Unlocked = true;

            Debug.Log(targetsDestoryed + "but in door behaviour this time");
        }
        
    }



}
