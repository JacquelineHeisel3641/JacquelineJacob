/*****************************************************************************
// File Name :         MusicController.cs
// Author :            Jacqueline Heisel
// Creation Date :     April 19, 2023
//
// Brief Description : Controlls the msuic - its pretty self explanatory
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static bool musicOn = true;
    AudioSource musicController;
    // Start is called before the first frame update
    void Start()
    {
        musicController = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
        MusicSettings();
    }

    /// <summary>
    /// mutes music if button pressed 
    /// </summary>
    void MusicSettings()
    {
        if (musicOn != true)
        {
            musicController.mute = true;
           
        }
        else
        {
            musicController.mute = false;
        }
    }
}
