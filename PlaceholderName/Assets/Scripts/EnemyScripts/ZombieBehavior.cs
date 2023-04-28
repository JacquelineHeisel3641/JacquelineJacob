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
    //[SerializeField] private float rotateSpeed;
    private float followDecider;
    private float distanceToP1;

    private bool followingPlayer1;
    private bool canAttack = true;

    public bool player1Destroyed = false;
    public bool player2Destroyed = false;

    public GameObject player1;
    public GameObject player2;

    public GameObject enemyController;
    public GameObject gameController;
    public GameObject doorController;

    public GameObject slashAnimator;

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

        StartCoroutine("AssignPlayers");

        //Reference for EnemyController.
        enemyController = GameObject.Find("EnemyController");

        //Reference for the DoorController.
        doorController = GameObject.Find("Door Controller");

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


        Vector3 playerPos = Vector3.zero;
        //Executes code based off the value of followingPlayer1.
        if(followingPlayer1)
        {
            //Moves the enemy toward player1.
            playerPos = player1.transform.position;
        }
        else if(followingPlayer1 == false)
        {
            //Moves the enemy toward player2.
            playerPos = player2.transform.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, playerPos,
            speed * Time.deltaTime);

        float offset = 0f;
        Vector2 dir = (transform.position - playerPos);
        dir.Normalize();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
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
    private IEnumerator AssignPlayers()
    {
        for (; ; )
        {
            player1 = GameObject.FindWithTag("Player1");
            player2 = GameObject.FindWithTag("Player2");

            yield return new WaitForSeconds(0.25f);
        }
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
            if (canAttack == true)
            {
                collision.gameObject.GetComponent<PlayerDamage>().TakeDamage
                    (damageDealt);

                canAttack = false;

                slashAnimator.SetActive(true);

                StartCoroutine("AttackCooldown");
            }
        }
    }

    private IEnumerator AttackCooldown()
    {
        for(int i = 3; i > 0; i--)
        {
            yield return new WaitForSeconds(1f);
        }

        canAttack = true;
    }

    private void OnDestroy()
    {
        doorController.GetComponent<DoorBehaviour>().enemyKillCounter++;
    }
}
