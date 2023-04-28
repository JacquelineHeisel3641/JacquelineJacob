/*****************************************************************************
// File Name :         AudioController.cs
// Author :            Jacqueline Heisel
// Creation Date :     April 26, 2023
//
// Brief Description : Controls whether or not sound effects and music are playing.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public static bool soundEffectsOn = true;
    //public static bool musicOn = true;
    public Text soundStatus;
    public Text musicStatus;

    /// <summary>
    /// Sets text to display whether the related option is on or off.
    /// </summary>
    void Start()
    {
        if (MusicController.musicOn)
        {

            musicStatus.text = "ON";
        }
        else if (!MusicController.musicOn)
        {

            musicStatus.text = "OFF";
        }
        if (soundEffectsOn)
        {

            soundStatus.text = "ON";
        }
        else if (!soundEffectsOn)
        {

            soundStatus.text = "OFF";
        }
    }

   
    /// <summary>
    /// Turns sound effects on and off.
    /// </summary>
    public void SoundEffects()
    {
        if (soundEffectsOn)
        {
            soundEffectsOn = false;
            soundStatus.text = "OFF";
        }
        else if (!soundEffectsOn)
        {
            soundEffectsOn = true;
            soundStatus.text = "ON";
        }

    }

    /// <summary>
    /// Turns music on and off.
    /// </summary>
    public void Music()
    {
        if (MusicController.musicOn)
        {
            MusicController.musicOn = false;
            musicStatus.text = "OFF";
        }
        else if (!MusicController.musicOn)
        {
            MusicController.musicOn = true;
            musicStatus.text = "ON";
        }

    }
}
