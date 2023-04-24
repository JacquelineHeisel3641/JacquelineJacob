/*****************************************************************************
// File Name :         PlayerDamage.cs
// Author :            Jacob Bateman
// Creation Date :     April 11, 2023
//
// Brief Description : Handles the players' health and determines whether they 
// are dead.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private int health;

    public GameObject enemyController;

    /// <summary>
    /// Sets a reference to EnemyController.
    /// </summary>
    private void Start()
    {
        enemyController = GameObject.Find("EnemyController");
    }

    /// <summary>
    /// Takes the damage an enemy deals as input. Subtracts the damage taken from 
    /// health, then checks if the player is dead.
    /// </summary>
    /// <param name="damageTaken"> Integer that takes the damage an enemy 
    /// deals. </param>
    public void TakeDamage(int damageTaken)
    {
        //Makes sure that the player is not in their immunity phase from dodge.
        if (gameObject.GetComponent<PlayerMovement>().isDashing == false)
        {
            health -= damageTaken;

            //Executes if a player is dead.
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
