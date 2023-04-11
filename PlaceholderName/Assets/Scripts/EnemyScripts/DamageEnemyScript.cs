using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemyScript : MonoBehaviour
{
    [SerializeField] private int health;

    /// <summary>
    /// Decreases enemy health and destroys the enemy health
    /// </summary>
    /// <param name="damageTaken"> Passed in from the weapon being used. Is equal to the damage value of the value. </param>
    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
