using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPractice : MonoBehaviour
{
    public GameObject tutorialSpawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "TestPlayer 1(Clone)" )
        {

            tutorialSpawner.SetActive(true);

        }
    }
}
