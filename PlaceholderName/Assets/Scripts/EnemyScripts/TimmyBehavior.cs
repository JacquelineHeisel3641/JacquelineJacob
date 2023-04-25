/*****************************************************************************
// File Name :         TimmyBehavior.cs
// Author :            Jacob Bateman
// Creation Date :     April 19, 2023
//
// Brief Description : Handles behavior associated with Timmy movement, which
// player is being followed, and calling a function to deal damage.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimmyBehavior : MonoBehaviour
{
    [SerializeField] private int damageDealt;
    private int playersAssignedCounter = 0;

    [SerializeField] private float speed;
    private float followDecider;
    private float distanceToP1;

    private bool followingPlayer1;

    public bool player1Destroyed = false;
    public bool player2Destroyed = false;

    public GameObject player1;
    public GameObject player2;

    public GameObject enemyController;
    public GameObject gameController;

    Vector3 playerPos;

    /// <summary>
    /// Decides which player the enemy will follow initially. Assigns a reference
    /// variable to access the EnemyController.
    /// </summary>
    private void Start()
    {
        //Decides which player the enemy will initially follow.
        followDecider = Random.Range(0, 2);

        gameController = GameObject.Find("GameController");

        AssignPlayers();

        //Reference for EnemyController.
        enemyController = GameObject.Find("EnemyController");

        if (player1 != null)
        {
            //Calculates the distance between the enemy and player 1.
            distanceToP1 = Vector3.Distance(player1.transform.position,
                gameObject.transform.position);
        }

        //Executes if player2 is active.
        if (player2 != null)
        {
            //Calculates distance between player2 and the enemy.
            float distanceToP2 = Vector3.Distance(player2.transform.position,
                gameObject.transform.position);
        }

        StartCoroutine("FollowDecider");
    }

    /// <summary>
    /// Handles this enemy's movement.
    /// </summary>
    private void Update()
    {
        if (player1 != null)
        {
            //Calculates the distance between the enemy and player 1.
            distanceToP1 = Vector3.Distance(player1.transform.position,
                gameObject.transform.position);
        }



        //Executes code based off the value of followingPlayer1.
        if (followingPlayer1)
        {
            //Moves the enemy toward player1.
            Vector3 playerPos = player1.transform.position;

            transform.position = Vector3.MoveTowards(transform.position, playerPos,
                speed * Time.deltaTime);
        }
        else if (followingPlayer1 == false)
        {
            //Moves the enemy toward player2.
            Vector3 playerPos = player2.transform.position;

            transform.position = Vector3.MoveTowards(transform.position, playerPos,
                speed * Time.deltaTime);
        }
    }

    private IEnumerator FollowDecider()
    {
        for (; ; )
        {
            //Executes if player2 is active.
            if (player2 != null)
            {
                //Calculates distance between player2 and the enemy.
                float distanceToP2 = Vector3.Distance(player2.transform.position,
                    gameObject.transform.position);

                //Determines which player is closest, then moves toward them.
                if (distanceToP1 > distanceToP2)
                {
                    followingPlayer1 = true;
                }
                else if (distanceToP2 > distanceToP1)
                {
                    followingPlayer1 = false;
                }
            }
            //Executes if at least player1 is active.
            else if (player1 != null)
            {
                followingPlayer1 = true;
            }

            yield return new WaitForSeconds(1f);
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
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.
            CompareTag("Player2"))
        {
            collision.gameObject.GetComponent<PlayerDamage>().TakeDamage
                (damageDealt);
        }
    }
}
