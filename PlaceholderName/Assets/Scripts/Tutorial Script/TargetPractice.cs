/*****************************************************************************
// File Name :         TargetPractice.cs
// Author :            Jacqueline Heisel
// Creation Date :     April 27, 2023
//
// Brief Description : This script spawns the enemies in the tutorial level
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPractice : MonoBehaviour
{
    public GameObject tutorialSpawner;

    /// <summary>
    /// Sees if the player is close enough to spawn enemies
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "TestPlayer 1(Clone)" )
        {

            tutorialSpawner.SetActive(true);

        }
    }
}
