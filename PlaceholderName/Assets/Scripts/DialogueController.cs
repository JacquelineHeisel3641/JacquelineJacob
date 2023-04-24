/*****************************************************************************
// File Name :         DialogueController.cs
// Author :            Jacob Bateman
// Creation Date :     April 11, 2023
//
// Brief Description : Handles dialogue for start and random interjections.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public GameObject dialogue1;
    public GameObject dialogue2;
    public GameObject dialogue3;
    public GameObject dialogue4;

    private GameObject mainCamera;

    public GameObject[] startDialogue = new GameObject[5];

    /// <summary>
    /// Adds dialogue GameObjects to array. Starts playing dialogue coroutine.
    /// </summary>
    private void Start()
    {
        /*startDialogue[0] = dialogue1;
        startDialogue[1] = dialogue2;
        startDialogue[2] = dialogue3;
        startDialogue[3] = dialogue4;*/

        mainCamera = GameObject.Find("Main Camera");

        StartCoroutine("DialogueTimer");
    }

    /// <summary>
    /// Plays start dialogue. Keeps each line of dialogue open for 5 seconds.
    /// </summary>
    /// <returns></returns>
    private IEnumerator DialogueTimer()
    {
        //Runs 4 times.
        for (int dialogueCounter = 0; dialogueCounter <= 4; dialogueCounter++)
        {
            //Sets next dialogue to active.
            startDialogue[dialogueCounter].SetActive(true);

            //Runs 5 times, once each second.
            for (int i = 5; i > 0; i--)
            {
                yield return new WaitForSeconds(1f);
            }

            //Disables current dialogue.
            startDialogue[dialogueCounter].SetActive(false);
        }

        mainCamera.GetComponent<AudioSource>().enabled = true;
    }
}
