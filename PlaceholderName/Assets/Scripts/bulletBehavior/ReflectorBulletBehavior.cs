/*****************************************************************************
// File Name :         ReflectorBulletBehavior.cs
// Author :            Jacob Bateman
// Creation Date :     April 6, 2023
//
// Brief Description : Handles functions related to the reflector's bullet behavior.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorBulletBehavior : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] public float speed = 100f;

    [SerializeField]private int wallCollisions = 0;

    private float rotationSpeed = 500f;

    Vector2 moveVelocity;

    /// <summary>
    /// Rotates the bullet in the direction it is travelling.
    /// </summary>
    private void Update()
    {
        moveVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;

        //Gets the direction the game object is travelling in.
        Quaternion directionTravelling = Quaternion.LookRotation(Vector3.forward,
            -moveVelocity);

        //Rotates the game object.
        transform.rotation = Quaternion.RotateTowards(transform.rotation,
            directionTravelling, rotationSpeed);
    }

    /// <summary>
    /// Destroys bullet on third collision with a wall.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroys bullet if certain collision requirements have been met.
        if(collision.gameObject.CompareTag("Wall") || collision.gameObject.
            CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            if(wallCollisions == 2)
            {
                Destroy(gameObject);
            }
            else
            {
                wallCollisions++;
            }
        }

        //Does damage and destroys bullet.
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.
            CompareTag("Turret"))
        {
            collision.gameObject.GetComponent<DamageEnemyScript>().TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
