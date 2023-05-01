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

    private void Start()
    {
        health = gameObject.GetComponent<PlayerDamage>().health;
    }

    private void Update()
    {
        health = gameObject.GetComponent<PlayerDamage>().health;

        health = health / 100;

        healthBar.transform.localScale = new Vector3(health, 1, 1);
    }
}
