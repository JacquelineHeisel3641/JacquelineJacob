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

    private bool followingPlayer1;

    private Transform laserSpawnPos;

    private void Start()
    {
        //Decides which player the enemy will initially follow.
        followDecider = Random.Range(0, 2);

        AssignPlayers();

        if (followDecider >= 0 && followDecider < 1)
        {
            followingPlayer1 = true;
        }
        else
        {
            followingPlayer1 = false;
        }
    }

    private void FixedUpdate()
    {
        if (followingPlayer1)
        {
            Vector3 vectorToTarget = player1.transform.position - transform.position;

            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg /*- rotationModifier*/;

            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }
        else
        {
            Vector3 vectorToTarget = player2.transform.position - transform.position;

            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg /*- rotationModifier*/;

            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }

        laserSpawnPos = laserSpawn.transform;

        InvokeRepeating("FireBullets", 0f, 0.5f);
    }

    private void FireBullets()
    {
        //Bullet spawns at the location of the bulletSpawn GameObject, which is a
        //child of the player. The direction it travels is determined by the
        //rotation of the player.
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
