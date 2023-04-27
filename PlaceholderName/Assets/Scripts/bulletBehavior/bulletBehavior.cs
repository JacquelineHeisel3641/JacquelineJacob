/*****************************************************************************
// File Name :         bulletBehavior.cs
// Author :            Jacob Bateman
// Creation Date :     April 6, 2023
//
// Brief Description : Contains parameters for the basic pistol's functionality.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] public float speed = 100f;

    /// <summary>
    /// On collision with an enemy, Destroys itself and triggers damage function 
    /// on enemy.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Executes if the collision is an enemy.
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.
            CompareTag("Turret"))
        {
            collision.gameObject.GetComponent<DamageEnemyScript>().TakeDamage
                (damage);

            Destroy(gameObject);
        }
        //Executes if the collision is a wall.
        else if(collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
