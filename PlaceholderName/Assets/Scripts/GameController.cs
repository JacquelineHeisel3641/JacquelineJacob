/*****************************************************************************
// File Name :         GameController.cs
// Author :            Jacob Bateman
// Creation Date :     April 12, 2023
//
// Brief Description : Keeps track of how long the game has been going. Scales
// enemy spawn rate and amount based on the time. Also disables and enables spawners
// for the rooms the player is in.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]private float secondsToWait = 10f;
    [SerializeField] private float secondsDecreaser = 0.5f;

    [SerializeField]private int timeActive = 0;
    [SerializeField]private int amountToSpawn = 1;
    private int threshold = 30;

    private bool increaseAmountSpawning = false;
    private bool startChecking = false;

    public GameObject leadPlayer;

    private GameObject[] room1Spawners;
    private GameObject[] room2Spawners;

    public GameObject[][] allSpawners;

    public float SecondsToWait { get => secondsToWait; set => secondsToWait = value; }
    public int AmountToSpawn { get => amountToSpawn; set => amountToSpawn = value; }

    /// <summary>
    /// Starts GameTimer, which scales enemy spawns with how long the game has been 
    /// going.
    /// </summary>
    private void Start()
    {
        StartCoroutine("GameTimer");

        /*GameObject[] room1Spawners = GameObject.FindGameObjectsWithTag
            ("Room1Spawner");

        GameObject[] room2Spawners = GameObject.FindGameObjectsWithTag
            ("Room2Spawner");*/
    }

    /// <summary>
    /// Times how long the game has been going for in seconds and scales the 
    /// difficulty accordingly. Difficulty is scaled by increasing the number of 
    /// enemies spawned, and the amount spawned.
    /// </summary>
    /// <returns></returns>
    private IEnumerator GameTimer()
    {
        //Runs until the game ends.
        for (; ; )
        {
            timeActive++;

            //When this condition is met, enemy spawn rate will increase. Every
            //other time this condition is met, the amount of enemies that spawn
            //will be increased up to 4.
            if (threshold == timeActive)
            {
                //Sets a new previousThreshold so that scaling will repeat.
                threshold += 30;

                //Changes amount of time in-between spawns.
                if (SecondsToWait > 1f)
                {
                    SecondsToWait -= secondsDecreaser;
                }

                //Increases the amount of enemies spawning. Caps at 4;
                if (increaseAmountSpawning && AmountToSpawn < 4)
                {
                    AmountToSpawn++;

                    increaseAmountSpawning = false;
                }
                else
                {
                    increaseAmountSpawning = true;
                }
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
