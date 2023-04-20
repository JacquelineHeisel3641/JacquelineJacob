/*****************************************************************************
// File Name :         DamageEnemyScript.cs
// Author :            Jacob Bateman
// Creation Date :     April 10, 2023
//
// Brief Description : Takes damage from the colliding bullet and lowers the 
// enemy's health with it.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemyScript : MonoBehaviour
{
    [SerializeField] private int health;

    public bool turretDead = false;

    /// <summary>
    /// Decreases enemy health and destroys the enemy health
    /// </summary>
    /// <param name="damageTaken"> Passed in from the weapon being used. Is equal to 
    /// the damage value of the value. </param>
    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;

        if (health <= 0)
        {
            if (gameObject.CompareTag("Turret"))
            {
                gameObject.GetComponent<TurretBehavior>().CancelInvoke(
                    "FireBullets");

                turretDead = true;

                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
