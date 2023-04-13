/*****************************************************************************
// File Name :         PlayerAssignerController.cs
// Author :            Jacob Bateman
// Creation Date :     April 11, 2023
//
// Brief Description : Assigns boolean to determine whether the player is player 2.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAssignerController : MonoBehaviour
{
    public bool isPlayer2 = false;

    /// <summary>
    /// Sets isPlayer2 to true once player 1 has spawned in.
    /// </summary>
    public void AssignBoolean()
    {
        if(isPlayer2 == false)
        {
            isPlayer2 = true;
        }
    }
}
