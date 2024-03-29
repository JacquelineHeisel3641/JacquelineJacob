/*****************************************************************************
// File Name :         Room3.cs
// Author :            Jacob Bateman
// Creation Date :     April 12, 2023
//
// Brief Description : Handles activation and deactivation of turrets and enemy 
// spawn points in the room this script handles.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1 : MonoBehaviour
{
    public GameObject[] spawners = new GameObject[2];

    /// <summary>
    /// Activates all turrets and spawn points in the room the player is entering.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            for (int i = spawners.Length; i > 0; i--)
            {
                spawners[i - 1].SetActive(true);
            }
        }
    }

    /// <summary>
    /// Deactivates all turrets and spawn points in the room the player is entering.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            for (int i = spawners.Length; i > 0; i--)
            {
                spawners[i - 1].SetActive(false);
            }
        }
    }
}
