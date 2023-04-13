/*****************************************************************************
// File Name :         TurretBehavior.cs
// Author :            Jacob Bateman
// Creation Date :     April 12, 2023
//
// Brief Description : Decides which player the turret will target, then fires 
// bullets.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public GameObject turretLaser;
    public GameObject laserSpawn;

    [SerializeField] private float speed;
    [SerializeField] private float rotationModifier;
    private float followDecider;
    [SerializeField] private float laserSpeed;
    [SerializeField] private float fireRate;

    private bool followingPlayer1;

    private Transform laserSpawnPos;

    /// <summary>
    /// Decides which player the turret will target, invokes the command to fire 
    /// bullets.
    /// </summary>
    private void Start()
    {
        //Decides which player the enemy will initially follow.
        followDecider = Random.Range(0, 2);

        AssignPlayers();

        //Decides which player will be targeted.
        if (followDecider >= 0 && followDecider < 1)
        {
            followingPlayer1 = true;
        }
        else
        {
            followingPlayer1 = false;
        }

        InvokeRepeating("FireBullets", 0f, fireRate);
    }

    /// <summary>
    /// Rotates the turret based off of the location of the player it is targeting.
    /// </summary>
    private void FixedUpdate()
    {
        if (followingPlayer1)
        {
            //Gets a position to target.
            Vector3 vectorToTarget = player1.transform.position - transform.position;

            //Calculates the angle to rotate.
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;

            //Rotates.
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }
        else
        {
            //Gets a position to target.
            Vector3 vectorToTarget = player2.transform.position - transform.position;

            //Calculates the angle to rotate.
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;

            //Rotates.
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }

        laserSpawnPos = laserSpawn.transform;
    }

    /// <summary>
    /// Fires bullets.
    /// </summary>
    private void FireBullets()
    {
        //Bullet spawns at the location of the laserSpawn GameObject, which is a
        //child of the turret. The direction it travels is determined by the
        //rotation of the turret.
        var spawnedBullet = Instantiate(turretLaser, laserSpawn.transform.position,
            laserSpawnPos.rotation);
        spawnedBullet.GetComponent<Rigidbody2D>().velocity = laserSpawnPos.up
            * laserSpeed;
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
}
