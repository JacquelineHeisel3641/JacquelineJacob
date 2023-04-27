/*****************************************************************************
// File Name :         TargetBehaviour.cs
// Author :            Jacqueline Heisel
// Creation Date :     April 12, 2023
//
// Brief Description : This script controls the targets in the tutorial
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
  

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {
            Vector3 camPos = Camera.main.transform.position;
            if (AudioController.soundEffectsOn)
            {
                // Play sound effect 
                //  AudioSource.PlayClipAtPoint(Munch, camPos);
            }


            Debug.Log("target hit");

            Destroy(this.gameObject);


        }
    }
}

