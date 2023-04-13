/*****************************************************************************
// File Name :         DoorBehaviour.cs
// Author :            Jacqueline Heisel
// Creation Date :     April 6, 2023
//
// Brief Description : This script opens and closes doors based on the
// player clicking space
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static int amountOfEnemies = 0;

    public bool player1Destroyed = false;
    public bool player2Destroyed = false;

    public bool room1Entered;
    public bool room2Entered;
    public bool room3Entered;
    public bool room4Entered;
    public bool room5Entered;
    public bool room6Entered;
    public bool room7Entered;
    public bool room8Entered;
    public bool room9Entered;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //when enemy is instatiated, add 1 to enemy count 

        //if(/* player enters area */)
        //{
        //    // Instantiate enemy
        //    amountOfEnemies += 1;
        //}

        
    }

    public void SetPlayerToDestroyed(bool isPlayer2)
    {
        if(isPlayer2)
        {
            player2Destroyed = true;
        }
        else
        {
            player1Destroyed = true;
        }
    }
}
