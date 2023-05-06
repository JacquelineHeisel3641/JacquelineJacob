/*****************************************************************************
// File Name :         HealthBar.cs
// Author :            Jacob Bateman
// Creation Date :     April 30, 2023
//
// Brief Description : Controls the behavior of the health bar.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private float health;

    public GameObject healthBar;

    private GameObject bar;

    private void Start()
    {
        health = gameObject.GetComponent<PlayerDamage>().health;

        StartCoroutine("FindHealthbar");
    }

    private void Update()
    {
        Vector3 healthBarPos = new Vector3(transform.position.x - 0.35f, 
            transform.position.y - 0.7f, 0);

        healthBar.transform.position = healthBarPos;

        health = gameObject.GetComponent<PlayerDamage>().health;

        health = health / 100;

        bar.transform.localScale = new Vector3(health, 0.1612771f, 1);
    }

    /// <summary>
    /// Finds healthBar that spawns with player and sets reference to it.
    /// </summary>
    /// <returns></returns>
    private IEnumerator FindHealthbar()
    {
        //Delays so that healthBar can spawn before checking for it.
        for (int i = 1; i > 0; i--)
        {
            yield return new WaitForSeconds(0.1f);
        }

        if (gameObject.CompareTag("Player1"))
        {
            healthBar = GameObject.FindGameObjectWithTag("P1Healthbar");

            bar = healthBar.GetComponent<BarStore>().bar;
        }
        else
        {
            healthBar = GameObject.FindGameObjectWithTag("P2Healthbar");

            bar = healthBar.GetComponent<BarStore>().bar;
        }
    }

    /// <summary>
    /// Destroys healthBar when the player dies.
    /// </summary>
    private void OnDestroy()
    {
        Destroy(healthBar);
    }
}
