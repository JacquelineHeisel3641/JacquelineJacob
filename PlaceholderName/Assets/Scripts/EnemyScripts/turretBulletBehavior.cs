using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretBulletBehavior : MonoBehaviour
{
    [SerializeField] private int damage;

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
