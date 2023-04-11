using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public GameObject dialogue1;
    public GameObject dialogue2;
    public GameObject dialogue3;
    public GameObject dialogue4;

    private GameObject[] startDialogue = new GameObject[4];

    private void Start()
    {
        startDialogue[0] = dialogue1;
        startDialogue[1] = dialogue2;
        startDialogue[2] = dialogue3;
        startDialogue[3] = dialogue4;

        StartCoroutine("DialogueTimer");
    }

    private IEnumerator DialogueTimer()
    {
        for (int dialogueCounter = 0; dialogueCounter <= 4; dialogueCounter++)
        {
            startDialogue[dialogueCounter].SetActive(true);

            for (int i = 5; i > 0; i--)
            {
                yield return new WaitForSeconds(1f);
            }

            startDialogue[dialogueCounter].SetActive(false);
        }
    }
}
