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
using UnityEngine.TextCore;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] public int health;

    public GameObject enemyController;
    public AudioClip hit;

    //public GameObject healthText;

    /// <summary>
    /// Sets a reference to EnemyController.
    /// </summary>
    private void Start()
    {
        enemyController = GameObject.Find("EnemyController");
    }

    /// <summary>
    /// Sets the health text below the player equal to their current health value.
    /// </summary>
    private void Update()
    {
        //healthText.GetComponent<TMPro.TextMeshProUGUI>().text = "Health: " + health;
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

            //playing a damage sound
            Vector3 camPos = Camera.main.transform.position;
            if (AudioController.soundEffectsOn)
            {
                // Play sound effect 

                AudioSource.PlayClipAtPoint(hit, camPos);
            }

            //Executes if a player is dead.
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
