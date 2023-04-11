/*****************************************************************************
// File Name :         ZombieBehavior.cs
// Author :            Jacob Bateman
// Creation Date :     April 10, 2023
//
// Brief Description : Handles behavior associated with zombie movement, which
// player is being followed, and calling a function to deal damage.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehavior : MonoBehaviour
{
    [SerializeField] private int damageDealt;
    private int playersAssignedCounter = 0;

    [SerializeField] private float speed;
    private float followDecider;

    private bool followingPlayer1;

    private bool player1Destroyed = false;
    private bool player2Destroyed = false;

    public GameObject player1;
    public GameObject player2;

    public GameObject enemyController;

    Vector3 playerPos;

    /// <summary>
    /// Decides which player the enemy will follow initially. Assigns a reference
    /// variable to access the EnemyController.
    /// </summary>
    private void Start()
    {
        //Decides which player the enemy will initially follow.
        followDecider = Random.Range(0, 2);

        if(followDecider >= 0 && followDecider < 1)
        {
            followingPlayer1 = true;
        }
        else
        {
            followingPlayer1 = false;
        }

        AssignPlayers();

        //Reference for EnemyController.
        enemyController = GameObject.Find("EnemyController");
    }

    /// <summary>
    /// Handles this enemy's movement.
    /// </summary>
    private void Update()
    {
        //Sets booleans to tell whether a player has been destroyed.
        player1Destroyed = enemyController.GetComponent<EnemyController>().
            player1Destroyed;
        player2Destroyed = enemyController.GetComponent<EnemyController>().
            player2Destroyed;

        //Detects whether a player has been destroyed.
        if (player1Destroyed)
        {
            followingPlayer1 = false;
        }
        else if(player2Destroyed)
        {
            followingPlayer1 = true;
        }

        //Moves the enemy depending on which player it is following.
        if (followingPlayer1)
        {
            Vector3 playerPos = player1.transform.position;

            transform.position = Vector3.MoveTowards(transform.position, playerPos,
                speed * Time.deltaTime);
        }
        else
        {
            Vector3 playerPos = player2.transform.position;

            transform.position = Vector3.MoveTowards(transform.position, playerPos,
                speed * Time.deltaTime);
        }
    }

    /// <summary>
    /// Assigns reference to players 1 and 2 by finding an object with their 
    /// respective tags.
    /// </summary>
    private void AssignPlayers()
    {
        player1 = GameObject.FindWithTag("Player1");
        player2 = GameObject.FindWithTag("Player2");
    }

    /// <summary>
    /// Calls function to have a player take damage on collision with this enemy.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player1") || collision.gameObject.
            CompareTag("Player2"))
        {
            collision.gameObject.GetComponent<PlayerDamage>().TakeDamage
                (damageDealt);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player1"))
        {
            followingPlayer1 = true;
        }
        else if(collision.gameObject.CompareTag("Player2"))
        {
            followingPlayer1 = false;
        }
        else if(collision.gameObject.CompareTag("Wall"))
        {

        }
    }*/
}
