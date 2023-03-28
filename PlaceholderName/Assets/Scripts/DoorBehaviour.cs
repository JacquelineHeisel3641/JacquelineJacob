using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class DoorBehaviour : MonoBehaviour
{
    public bool door1Unlocked;
    public GameObject door1TileMap;

    // 
    public InputAction doorOpen;
    private InputAction player;

   /// <summary>
   /// 
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

    void UnlockDoor()
    {
        door1TileMap.SetActive(false);
    }


}
