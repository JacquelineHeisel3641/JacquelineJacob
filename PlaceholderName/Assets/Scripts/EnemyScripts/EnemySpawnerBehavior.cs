/*****************************************************************************
// File Name :         EnemySpawnBehavior.cs
// Author :            Jacob Bateman
// Creation Date :     April 12, 2023
//
// Brief Description : Spawns enemies based off values passed in by the 
// GameController.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehavior : MonoBehaviour
{
    private float secondsToWait;

    private int amountToSpawn;

    public GameObject zombie;

    //Points of enemy spawn to facilitate higher spawning amounts.
    public GameObject spawnLoc1;
    public GameObject spawnLoc2;
    public GameObject spawnLoc3;
    public GameObject spawnLoc4;

    private Vector3 spawnPos1;
    private Vector3 spawnPos2;
    private Vector3 spawnPos3;
    private Vector3 spawnPos4;

    public GameObject gameController;

    /// <summary>
    /// Gets location of spawnLoc game objects and assigns them to variables. 
    /// Starts coroutines for spawn functionality.
    /// </summary>
    private void Start()
    {
        //Gets the physical locations of the spawnLoc game objects and assigns
        //them to Vector3 spawnPos variables.
        spawnPos1 = spawnLoc1.transform.position;
        spawnPos2 = spawnLoc2.transform.position;
        spawnPos3 = spawnLoc3.transform.position;
        spawnPos4 = spawnLoc4.transform.position;

        gameController = GameObject.Find("GameController");

        StartCoroutine("EnemySpawns");
    }

    private void Update()
    {
        secondsToWait = gameController.GetComponent<GameController>().SecondsToWait;
        amountToSpawn = gameController.GetComponent<GameController>().AmountToSpawn;
    }

    /// <summary>
    /// Spawns enemies on spawn points this script is attached to.
    /// </summary>
    /// <returns></returns>
    private IEnumerator EnemySpawns()
    {


        for (; ; )
        {
            //Controls how many enemies are spawning at a time based off of
            //amountToSpawn.
            switch(amountToSpawn)
            {
                case 1:
                    Instantiate(zombie, spawnPos1, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(zombie, spawnPos1, Quaternion.identity);
                    Instantiate(zombie, spawnPos2, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(zombie, spawnPos1, Quaternion.identity);
                    Instantiate(zombie, spawnPos2, Quaternion.identity);
                    Instantiate(zombie, spawnPos3, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(zombie, spawnPos1, Quaternion.identity);
                    Instantiate(zombie, spawnPos2, Quaternion.identity);
                    Instantiate(zombie, spawnPos3, Quaternion.identity);
                    Instantiate(zombie, spawnPos4, Quaternion.identity);
                    break;
            }

            yield return new WaitForSeconds(secondsToWait);
        }
    }


}
