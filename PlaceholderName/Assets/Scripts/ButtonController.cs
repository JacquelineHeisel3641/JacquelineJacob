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
using UnityEngine.UIElements;


public class ButtonController : MonoBehaviour
{
    public GameObject instructionPage;
    private bool instructionsOpen = false;
    public AudioClip click;
    public AudioClip newGame;
    public GameObject pauseMenu;

    /// <summary>
    /// not functional yet, but will eventually play sound effects
    /// </summary>
    public void PlaySound()
    {
        Vector3 camPos = Camera.main.transform.position;
        if (AudioController.soundEffectsOn)
        {
            // Play sound effect 
            AudioSource.PlayClipAtPoint(click, camPos);
        }
    }

    /// <summary>
    /// Quits the game when clicked
    /// </summary>
    public void QuitButton()
    {

        Vector3 camPos = Camera.main.transform.position;
        if (AudioController.soundEffectsOn)
        {
            // Play sound effect 
            AudioSource.PlayClipAtPoint(click, camPos);
        }
        // SceneManager.LoadScene("Quit Screen");
        Application.Quit();
        Debug.Log("bye bye");
    }

    /// <summary>
    /// Takes to an instructions page
    /// </summary>
    public void Help()
    {
        Vector3 camPos = Camera.main.transform.position;

        if(instructionsOpen != true)
        {
            instructionPage.SetActive(true);
            instructionsOpen = true;
        }


        if (AudioController.soundEffectsOn)
        {
            // Play sound effect 
            AudioSource.PlayClipAtPoint(click, camPos);
        }
        // SceneManager.LoadScene("Instructions");
        Debug.Log("sound please");
    }

    /// <summary>
    /// Goes to the next scene - tutorial
    /// </summary>
    public void NewGame()
    {

        // find camera position 
        Vector3 camPos = Camera.main.transform.position;

        if (AudioController.soundEffectsOn)
        {
            AudioSource.PlayClipAtPoint(newGame, camPos);
        }
        SceneManager.LoadScene("Tutorial Level");
    }

    /// <summary>
    /// goes to the level 1 scene
    /// </summary>
    public void Level1()
    {

        // find camera position 
        Vector3 camPos = Camera.main.transform.position;

        if (AudioController.soundEffectsOn)
        {
            AudioSource.PlayClipAtPoint(click, camPos);
        }

        Time.timeScale = 1f;

        SceneManager.LoadScene("Level 1");
    }

    /// <summary>
    /// not functional yet - will go to the settings page
    /// </summary>
    public void ArachnophileMode()
    {

        Vector3 camPos = Camera.main.transform.position;
        if (AudioController.soundEffectsOn)
        {
            // Play sound effect 
            AudioSource.PlayClipAtPoint(click, camPos);
        }

        SceneManager.LoadScene("ArachnophileMode");
    }
    public void Settings()
    {

        Vector3 camPos = Camera.main.transform.position;
        if (AudioController.soundEffectsOn)
        {
            // Play sound effect 

            AudioSource.PlayClipAtPoint(click, camPos);
        }
        // SceneManager.LoadScene("HighScores");
        SceneManager.LoadScene("Settings");
    }

    public void Back()
    {

        Vector3 camPos = Camera.main.transform.position;
        if (AudioController.soundEffectsOn)
        {
            // Play sound effect 
            AudioSource.PlayClipAtPoint(click, camPos);
        }

        Time.timeScale = 1f;

        // SceneManager.LoadScene("HighScores");
        SceneManager.LoadScene("Main Menu");

        //SceneManager.UnloadScene("Tutorial Level");
    }

    /// <summary>
    /// not functional yet - will go back to the previous scene
    /// </summary>
    public void CloseInstructions()
    {

        Vector3 camPos = Camera.main.transform.position;

        if (instructionsOpen)
        {
            instructionPage.SetActive(false);
            instructionsOpen = false;
            
        }
        if (AudioController.soundEffectsOn)
        {
            // Play sound effect 
            AudioSource.PlayClipAtPoint(click, camPos);
        }
        //opening the menu 
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        //  SceneManager.LoadScene("Main Menu");
    }

   


}

