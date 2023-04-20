/*****************************************************************************
// File Name :         PlayerMovement.cs
// Author :            Jacob Bateman
// Creation Date :     April 6, 2023
//
// Brief Description : Handles player movement, bullet instantiating, and player 
// rotation.
*****************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    InputActionAsset inputAsset;
    InputActionMap inputMap;

    private string roomEntering;
    private string roomExiting;

    private float angle;
    [SerializeReference] private float playerSpeed = 300f;
    [SerializeField] private float bulletSpeed = 100f;
    [SerializeField] private float dodgeSpeed;

    public bool isPlayer2 = false;
    public bool isDashing = false;
    private bool finishedDashing = false;

    Vector2 movement;
    Vector2 rotation;

    Transform bulletSpawnPos;

    private GameObject bullet;
    [SerializeField] private GameObject bulletSpawn;
    private GameObject currPlayer;
    public GameObject reticle;
    private GameObject gameController;

    public GameObject mainCamera;

    private Rigidbody2D rb2D;

    private InputAction inputMovement;
    private InputAction inputRotate;
    private InputAction shoot;
    private InputAction dodge;

    public string RoomEntering { get => roomEntering; set => roomEntering = value; }
    public string RoomExiting { get => roomExiting; set => roomExiting = value; }

    /// <summary>
    /// Activates player actions.
    /// </summary>
    private void Awake()
    {
        //References the player controls.
        inputAsset = this.GetComponent<PlayerInput>().actions;
        inputMap = inputAsset.FindActionMap("PlayerActions");

        //NO FindAction() LINES ABOVE THIS POINT

        //Assigns variables to reference action from the input map.
        inputMovement = inputMap.FindAction("Movement");
        inputRotate = inputMap.FindAction("Rotate");
        shoot = inputMap.FindAction("Shoot");
        dodge = inputMap.FindAction("Dodge");

        //Used to assign variables to access the reticle.
        //currPlayer = gameObject;
        //reticle = currPlayer.transform.Find("TestReticle").gameObject;

        rb2D = gameObject.GetComponent<Rigidbody2D>();

        //Sets up movement.
        inputMovement.performed += context => movement = context.ReadValue
            <Vector2>();
        inputMovement.canceled += context => movement = Vector2.zero;

        //Sets up rotation.
        inputRotate.performed += context => rotation = context.ReadValue<Vector2>();

        inputRotate.performed += context => RotatePlayer();

        //Executes function responsible for spawning bullets.
        shoot.performed += context => Shoot();

        //Executes function responsible for dodging.
        dodge.performed += context => StartCoroutine("Dodge");

        //Sets a variable to access the main camera.
        mainCamera = GameObject.Find("Main Camera");
    }

    /// <summary>
    /// Increases playerSpeed and lets the player dash forward.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Dodge()
    {
        //Limits the distance the player can dodge by limiting the time the
        //speed boost is in effect.
        for(int i = 1; i > 0; i--, finishedDashing = true)
        {
            if (isDashing == false)
            {
                isDashing = true;

                playerSpeed += dodgeSpeed;

                yield return new WaitForSeconds(0.2f);
            }
        }

        //Executes once the dodge has run its course. Reverts playerSpeed and stops
        //the coroutine, also enables the dodge action, which is disabled while the
        //dodge is being performed.
        if(isDashing == true && finishedDashing == true)
        {
            playerSpeed -= dodgeSpeed;

            isDashing = false;
            finishedDashing = false;

            dodge.Enable();

            StopCoroutine("Dodge");
        }
    }

    /// <summary>
    /// Sets up important variables and assigns the player's tag.
    /// </summary>
    private void Start()
    {
        //If this is the first player spawned, assigns lead player status to them,
        //otherwise does nothing.
        mainCamera.GetComponent<TestLeadPlayerAssigning>().LeadPlayerAssigner
            (gameObject);

        gameController = GameObject.Find("GameController");

        AssignPlayerTags();
    }

    /// <summary>
    /// Executes movement and rotation when receiving player input.
    /// </summary>
    private void FixedUpdate()
    {
        //Gets a value to use as velocity by taking movement input from the player.
        Vector2 movementVelocity = new Vector2(movement.x, movement.y) * playerSpeed 
            * Time.deltaTime;
        //Moves the player by altering their velocity.
        rb2D.velocity = movementVelocity;

        //Gets the active bullet prefab every frame to make sure it is up to date.
        bullet = GetComponent<ActiveWeaponBehavior>().bulletPrefab;
        bulletSpawnPos = bulletSpawn.transform;

        if(isDashing)
        {
            dodge.Disable();
        }
    }

    /// <summary>
    /// Fires bullet when the Shoot action is performed.
    /// </summary>
    private void Shoot()
    {
        //Bullet spawns at the location of the bulletSpawn GameObject, which is a
        //child of the player. The direction it travels is determined by the
        //rotation of the player.
        var spawnedBullet = Instantiate(bullet, bulletSpawn.transform.position, 
            bulletSpawnPos.rotation); 
        spawnedBullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPos.up 
            * bulletSpeed;

    }

    /// <summary>
    /// Assigns tags to differentiate players 1 and 2 upon being instantiated.
    /// </summary>
    private void AssignPlayerTags()
    {
        if(gameController.GetComponent
                <PlayerAssignerController>().isPlayer2)
        {
            gameObject.tag = "Player2";
        }
        else
        {
            gameObject.tag = "Player1";

            gameController.GetComponent<PlayerAssignerController>()
                .AssignBoolean();

        }
    }

    /// <summary>
    /// Rotates the player.
    /// </summary>
    public void RotatePlayer()
    {
        //Gets the distance the player needs to rotate.
        angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        //Rotates the player by the amount specified by angle - 90 degrees.
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    private void OnBecameInvisible()
    {
        if(gameObject.CompareTag("Player2"))
        {
            StartCoroutine("InvisibleTeleportTimer");
        }
    }

    private IEnumerator InvisibleTeleportTimer()
    {
        for(int i = 5; i > 0; i--)
        {
            yield return new WaitForSeconds(1f);
        }

        Vector3 spawnPos = GameObject.Find("SpawnPoint").transform.position;
        spawnPos.z += 10;

        transform.position = spawnPos;

        StopCoroutine("InvisibleTeleportTimer");
    }

    /// <summary>
    /// Enables and disables the input map.
    /// </summary>
    private void OnEnable()
    {
        inputMap.Enable();
    }

    private void OnDisable()
    {
        inputMap.Disable();
    }
}
