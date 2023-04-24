/*****************************************************************************
// File Name :         CameraMovement.cs
// Author :            Jacqueline Heisel
// Creation Date :     March 14, 2023
//
// Brief Description : This script moves the camera so the
// player is always on screen - this is outdated, and soley here for reference
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    //lets it know what to keep on screen
    public GameObject leadPlayer;

    void Update()
    {

        //set the position, moves an object (camera) to the position of
        //another object (player) from its current poisiton, over a time period
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(leadPlayer.transform.position.x,
            leadPlayer.transform.position.y, -10), Time.deltaTime);
    }
}
