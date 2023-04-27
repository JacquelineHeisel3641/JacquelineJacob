using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSensor : MonoBehaviour
{
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Executes if the collision is an enemy.
        if (collision.gameObject.name == "Door1Trigger")
        {
            TutorialDoorBehaviour.door1Unlocked = true;
        }

    }
}
