/*****************************************************************************
// File Name :         DoorBehaciour.cs
// Author :            Jacqueline Heisel
// Creation Date :     April 6, 2023
//
// Brief Description : This script opens and closes doors based on the
// player clicking space
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class DoorBehaviour : MonoBehaviour
{
    // bools to check which doors has been opened
    public bool door1Unlocked;
    public bool door2Unlocked;
    public bool door3Unlocked;
    public bool door4Unlocked;
    public bool door5Unlocked;
    public bool door6Unlocked;

    //game objects to assign sections of the tile map to certain doors
    public GameObject door1TileMap;
    public GameObject door2TileMap;
    public GameObject door3TileMap;
    public GameObject door4TileMap;
    public GameObject door5TileMap;
    public GameObject door6TileMap;

    // 
    public InputAction doorOpen;
    private InputAction player;

   /// <summary>
   /// Checking for user input
   /// </summary>
    void Start()
    {
        //equivalent of get key down
        doorOpen.started += DoorOpen_started;

        //equivalent of get key up 
        doorOpen.canceled += DoorOpen_canceled;

        doorOpen.Enable();
        door1Unlocked = false;
    }

    private void DoorOpen_canceled(InputAction.CallbackContext obj)
    {
        
    }

    /// <summary>
    /// Unlocking the door when the player presses space
    /// </summary>
    /// <param name="obj"></param>
    private void DoorOpen_started(InputAction.CallbackContext obj)
    {
        UnlockDoor();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    door1Unlocked = true;

        //}
        //if (door1Unlocked)
        //{
        //    UnlockDoor();
        //}
    }

    /// <summary>
    /// Checking to see which door to unlock based on how many doors the
    /// player has already opened
    /// </summary>
    void UnlockDoor()
    {
        if(door1Unlocked != true)
        {
            door1TileMap.SetActive(false);
            door1Unlocked = true;
        }
        else if (door1Unlocked && door2Unlocked != true)
        {
            door2TileMap.SetActive(false);
            door2Unlocked = true;
        }
        else if (door1Unlocked && door2Unlocked && door3Unlocked != true)
        {
            door3TileMap.SetActive(false);
            door3Unlocked = true;
        }
        else if (door1Unlocked && door2Unlocked && door3Unlocked 
            && door4Unlocked != true)
        {
            door4TileMap.SetActive(false);
            door4Unlocked = true;
        }
        else if (door1Unlocked && door2Unlocked && door3Unlocked
            && door4Unlocked && door5Unlocked != true)
        {
            door5TileMap.SetActive(false);
            door5Unlocked = true;
        }
        else if (door1Unlocked && door2Unlocked && door3Unlocked
           && door4Unlocked && door5Unlocked && door6Unlocked != true)
        {
            door6TileMap.SetActive(false);
            door6Unlocked = true;
        }
        else
        {
            // this is a classic debug log
            Debug.Log("Congradulations! You Broke it. So now you have to fix it.");
        }
    }


}
