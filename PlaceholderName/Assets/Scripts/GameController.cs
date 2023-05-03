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
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    [SerializeField]private float secondsToWait = 10f;
    [SerializeField] private float secondsDecreaser = 0.5f;

    [SerializeField]private int timeActive = 0;
    [SerializeField]private int amountToSpawn = 0;
    private int threshold = 20;

    private bool increaseAmountSpawning = false;
    private bool startChecking = false;

    public bool gameStarted = false;

    public GameObject leadPlayer;
    public GameObject playerPrefab;

    public GameObject initialSpawnLoc;

    public GameObject respawnPlayer;
    public GameObject mainCamera;

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
        StartCoroutine("CheckForStart");
    }

    /// <summary>
    /// Sets lead player reference.
    /// </summary>
    private void Update()
    {
        leadPlayer = mainCamera.GetComponent<TestLeadPlayerAssigning>().leadPlayer;
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
                threshold += 20;

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

    /// <summary>
    /// Checks to see whether both players have spawned to make sure the game does 
    /// not start before player's are active.
    /// </summary>
    /// <returns></returns>
    private IEnumerator CheckForStart()
    {
        for (; ; )
        {
            if(GetComponent<PlayerAssignerController>().player1 != null && 
                GetComponent<PlayerAssignerController>().player2 != null)
            {
                break;
            }

            yield return new WaitForSeconds(1f);
        }

        StartCoroutine("GameTimer");

        gameStarted = true;

        AmountToSpawn = 1;
    }

    /// <summary>
    /// Respawns a dead player after a certain amount of time has passed.
    /// </summary>
    /// <returns></returns>
    private IEnumerator RespawnTimer()
    {
        for(int i = 10; i > 0; i--)
        {
            yield return new WaitForSeconds(1f);
        }

        //Instantiates player.
        GameObject currPlayer = Instantiate(respawnPlayer, transform.position, 
            Quaternion.identity);

        //Moves player to the position of the still alive player.
        currPlayer.transform.position = GameObject.FindGameObjectWithTag("Player1")
            .transform.position;
    }
}
