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

public class GameController : MonoBehaviour
{
    private float secondsToWait = 10f;
    [SerializeField] private float secondsDecreaser = 0.5f;

    private int timeActive = 0;
    private int amountToSpawn = 1;
    private int previousThreshold = 30;

    private bool increaseAmountSpawning = false;

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
            if (previousThreshold == timeActive / 2)
            {
                //Sets a new previousThreshold so that scaling will repeat.
                previousThreshold = timeActive;

                //Changes amount of time in-between spawns.
                if (SecondsToWait > 0.5f)
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

    /// <summary>
    /// Gets which room the player is entering then calls a function.
    /// </summary>
    /*public void WhichSpawnersToActive()
    {
        switch(leadPlayer.GetComponent<PlayerMovement>().RoomEntering)
        {
            case "Room1SpawnTrigger":
                ActivateSpawners(0);
                break;
            case "Room2SpawnTrigger":
                ActivateSpawners(1);
                break;
        }
    }

    /// <summary>
    /// Gets which room the player is exiting then calls a function.
    /// </summary>
    public void WhichSpawnersToDeactivate()
    {
        switch (leadPlayer.GetComponent<PlayerMovement>().RoomExiting)
        {
            case "Room1SpawnTrigger":
                DeactivateSpawners(0);
                break;
            case "Room2SpawnTrigger":
                DeactivateSpawners(1);
                break;
        }
    }

    /// <summary>
    /// Activates all spawners in the room the player is entering.
    /// </summary>
    /// <param name="posInArray"> Keeps track of which slot is being accessed in 
    /// array. </param>
    private void ActivateSpawners(int posInArray)
    {
        for(int i = allSpawners[posInArray].Length; i > 0; i--)
        {
            allSpawners[posInArray][i - 1].SetActive(true);
        }
    }

    /// <summary>
    /// Deactivates all spawners in the room the player is exiting.
    /// </summary>
    /// <param name="posInArray"> Keeps track of which slot is being accessed in 
    /// array. </param>
    private void DeactivateSpawners(int posInArray)
    {
        for(int i = allSpawners[posInArray].Length; i > 0; i--)
        {
            allSpawners[posInArray][i - 1].SetActive(false);
        }
    }*/


    /// <summary>
    /// Gets the lead player from TestLeadPlayerAssigning and sets leadPlayer to it.
    /// </summary>
    /// <param name="player"> The player passed in from TestLeadPlayerAssigning. 
    /// </param>
   /* public void LeadPlayerIs(GameObject player)
    {
        leadPlayer = player;
    }*/
}
