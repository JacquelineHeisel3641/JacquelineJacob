using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    InputActionAsset inputAsset;
    InputActionMap inputMap;

    private float angle;
    [SerializeReference] private float playerSpeed = 300f;
    [SerializeField] private float bulletSpeed = 100f;

    Vector2 movement;
    Vector2 rotation;

    Transform bulletSpawnPos;

    private GameObject bullet;
    [SerializeField] private GameObject bulletSpawn;
    private GameObject currPlayer;
    private GameObject reticle;

    public GameObject mainCamera;

    private Rigidbody2D rb2D;

    private InputAction inputMovement;
    private InputAction inputRotate;
    private InputAction shoot;

    /// <summary>
    /// Activates player actions.
    /// </summary>
    private void Awake()
    {
        //References the player controls.
        inputAsset = this.GetComponent<PlayerInput>().actions;
        inputMap = inputAsset.FindActionMap("PlayerActions");

        //NO FindAction() LINES ABOVE THIS POINT

        inputMovement = inputMap.FindAction("Movement");
        inputRotate = inputMap.FindAction("Rotate");
        shoot = inputMap.FindAction("Shoot");

        currPlayer = gameObject;
        reticle = currPlayer.transform.Find("TestReticle").gameObject;

        rb2D = gameObject.GetComponent<Rigidbody2D>();

        //Sets up movement.
        inputMovement.performed += context => movement = context.ReadValue
            <Vector2>();
        inputMovement.canceled += context => movement = Vector2.zero;

        //Sets up rotation.


        inputRotate.performed += context => rotation = context.ReadValue<Vector2>();
        //inputRotate.canceled += context => rotation = Vector2.zero;

        inputRotate.performed += context => RotatePlayer();

        //Executes function responsible for spawning bullets.
        shoot.performed += context => Shoot();

        mainCamera = GameObject.Find("Main Camera");

    }

    private void Start()
    {
        mainCamera.GetComponent<TestLeadPlayerAssigning>().LeadPlayerAssigner
            (gameObject);
    }

    /// <summary>
    /// Executes movement and rotation when receiving player input.
    /// </summary>
    private void FixedUpdate()
    {
        Vector2 movementVelocity = new Vector2(movement.x, movement.y) * playerSpeed 
            * Time.deltaTime;
        rb2D.velocity = movementVelocity;

        bullet = GetComponent<ActiveWeaponBehavior>().bulletPrefab;
        bulletSpawnPos = bulletSpawn.transform;
    }

    /// <summary>
    /// Fires bullet when the Shoot action is performed.
    /// </summary>
    private void Shoot()
    {
        //Bullet spawns at the location of the bulletSpawn GameObject, which is a
        //child of the player. The direction it travels is determined by the
        //rotation of the player.

        //FIND A VIDEO THAT ACTUALLY WORKS
        //Instantiate(bullet, bulletSpawn.transform.position, transform.rotation)
        //.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5f);

        var spawnedBullet = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawnPos.rotation);
        spawnedBullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPos.up * bulletSpeed;

    }

    public void RotatePlayer()
    {
        angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    public void SetBulletPrefab()
    {
        
    }

    private void OnEnable()
    {
        inputMap.Enable();
    }

    private void OnDisable()
    {
        inputMap.Disable();
    }
}
