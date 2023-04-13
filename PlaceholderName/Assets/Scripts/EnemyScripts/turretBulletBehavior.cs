/*****************************************************************************
// File Name :         turretBulletBehavior.cs
// Author :            Jacob Bateman
// Creation Date :     April 12, 2023
//
// Brief Description : Handles destruction and damage of the turretBullet.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretBulletBehavior : MonoBehaviour
{
    [SerializeField] private int damage;

    /// <summary>
    /// On collision with a player, damages the player and destroys itself.
    /// On collision with a wall, destroys itself.
    /// On collision with an enemy, damages the enemy and destroys itself.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player1") || collision.gameObject.
            CompareTag("Player2"))
        {
            collision.gameObject.GetComponent<PlayerDamage>().TakeDamage(damage);

            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<DamageEnemyScript>().TakeDamage
                (damage);

            Destroy(gameObject);
        }
    }
}
