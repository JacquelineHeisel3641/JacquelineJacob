/*****************************************************************************
// File Name :         ButtonController.cs
// Author :            Jacqueline Heisel
// Creation Date :     April 6, 2023
//
// Brief Description : Has the funtions for all buttons in the game
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
 
    public void PlaySound()
    {
        Vector3 camPos = Camera.main.transform.position;
        //if (AudioController.soundEffectsOn)
        //{
        //    // Play sound effect 
        //    AudioSource.PlayClipAtPoint(click, camPos);
        //}
    }

    public void QuitButton()
    {

        Vector3 camPos = Camera.main.transform.position;
        //if (AudioController.soundEffectsOn)
        //{
        //    // Play sound effect 
        //    AudioSource.PlayClipAtPoint(click, camPos);
        //}
        // SceneManager.LoadScene("Quit Screen");
        Application.Quit();
    }
    public void Help()
    {
        Vector3 camPos = Camera.main.transform.position;
        //if (AudioController.soundEffectsOn)
        //{
        //    // Play sound effect 
        //    AudioSource.PlayClipAtPoint(click, camPos);
        //}
       // SceneManager.LoadScene("Instructions");
        Debug.Log("sound please");
    }
    public void NewGame()
    {

        // find camera position 
        Vector3 camPos = Camera.main.transform.position;

        //if (AudioController.soundEffectsOn)
        //{
        //    AudioSource.PlayClipAtPoint(newGame, camPos);
        //}
        SceneManager.LoadScene("Tutorial Level");
    }
    public void Level1()
    {

        // find camera position 
        Vector3 camPos = Camera.main.transform.position;

        //if (AudioController.soundEffectsOn)
        //{
        //    AudioSource.PlayClipAtPoint(newGame, camPos);
        //}
        SceneManager.LoadScene("Level 1");
    }
    public void HighScores()
    {

        Vector3 camPos = Camera.main.transform.position;
        //if (AudioController.soundEffectsOn)
        //{
        //    // Play sound effect 
        //    AudioSource.PlayClipAtPoint(click, camPos);
        //}
       // SceneManager.LoadScene("HighScores");
    }
    public void Back()
    {

        Vector3 camPos = Camera.main.transform.position;
        //if (AudioController.soundEffectsOn)
        //{
        //    // Play sound effect 
        //    AudioSource.PlayClipAtPoint(click, camPos);
        //}
      //  SceneManager.LoadScene("Main Menu");
    }


}

