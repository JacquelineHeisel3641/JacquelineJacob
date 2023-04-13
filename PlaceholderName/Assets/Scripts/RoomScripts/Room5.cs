/*****************************************************************************
// File Name :         Room5.cs
// Author :            Jacob Bateman
// Creation Date :     April 13, 2023
//
// Brief Description : Handles activation and deactivation of turrets and enemy 
// spawn points in the room this script handles.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room5 : MonoBehaviour
{
    public GameObject[] spawners = new GameObject[4];

    public GameObject[] turrets = new GameObject[7];

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

            for (int i = turrets.Length; i > 0; i--)
            {
                turrets[i - 1].SetActive(true);
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

            for (int i = turrets.Length; i > 0; i--)
            {
                turrets[i - 1].SetActive(true);
            }
        }
    }
}
