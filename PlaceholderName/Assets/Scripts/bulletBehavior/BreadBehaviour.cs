/*****************************************************************************
// File Name :         BreadBehavior.cs
// Author :            Jacqueline Heisel
// Creation Date :     4/11/2023
//
// Brief Description : Contains parameters for the bread bazooka functionality.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadBehaviour : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] public float speed = 50f;

    /// <summary>
    /// On collision with an enemy, Destroys itself and triggers damage function 
    /// on enemy.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Executes if the collision is an enemy.
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.
            CompareTag("Turret"))
        {
            collision.gameObject.GetComponent<DamageEnemyScript>().TakeDamage
                (damage);

            
        }
        //Executes if the collision is a wall.
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}

