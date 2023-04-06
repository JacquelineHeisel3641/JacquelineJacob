using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
   // public AudioClip newGame;
    //public AudioClip click;

    //public Text soundStatus;
    //  public Text musicStatus;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
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
        SceneManager.LoadScene("Instructions");
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
        SceneManager.LoadScene("HighScores");
    }
    public void Back()
    {

        Vector3 camPos = Camera.main.transform.position;
        //if (AudioController.soundEffectsOn)
        //{
        //    // Play sound effect 
        //    AudioSource.PlayClipAtPoint(click, camPos);
        //}
        SceneManager.LoadScene("MainMenu");
    }


}

