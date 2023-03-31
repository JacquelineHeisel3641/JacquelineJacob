using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls controls;

    private float angle;
    [SerializeReference] private float playerSpeed = 5f;

    Vector2 movement;
    Vector2 rotation;

    private GameObject bullet;
    [SerializeField] private GameObject bulletSpawn;

    private Rigidbody2D rb2D;

    /// <summary>
    /// Activates player actions.
    /// </summary>
    private void Awake()
    {
        //References the player controls.
        controls = new PlayerControls();

        rb2D = gameObject.GetComponent<Rigidbody2D>();

        //Sets up movement.
        controls.PlayerActions.Movement.performed += context => movement = context.
            ReadValue<Vector2>();
        controls.PlayerActions.Movement.canceled += context => movement = 
            Vector2.zero;

        //Sets up rotation.
        controls.PlayerActions.Rotate.performed += context => rotation =
            context.ReadValue<Vector2>();
        controls.PlayerActions.Rotate.canceled += context => rotation = 
            Vector2.zero;

        controls.PlayerActions.Rotate.performed += context => RotatePlayer();

        controls.PlayerActions.Shoot.performed += context => Shoot();
    }

    /// <summary>
    /// Executes movement and rotation when receiving player input.
    /// </summary>
    private void FixedUpdate()
    {
        //Moves the player.
        /*Vector2 movementVelocity = new Vector2(movement.x, movement.y) * 5 *
            Time.deltaTime;
        transform.Translate(movementVelocity, Space.World);*/

        //Moves player using values read in through the Move function when receiving
        //Move action input.
        Vector2 movementVelocity = new Vector2(movement.x, movement.y) * 400f *
            Time.deltaTime;
        rb2D.velocity = movementVelocity;

        Debug.Log(rotation);

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    /// <summary>
    /// Fires bullet when the Shoot action is performed.
    /// </summary>
    private void Shoot()
    {
        //Bullet spawns at the location of the bulletSpawn GameObject, which is a
        //child of the player. The direction it travels is determined by the
        //rotation of the player.
        Instantiate(bullet, bulletSpawn.transform.position, transform.rotation);
    }

    private void RotatePlayer()
    {
        angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
    }

    public void SetBulletPrefab()
    {
        
    }

    private void OnEnable()
    {
        controls.PlayerActions.Enable();
    }

    private void OnDisable()
    {
        controls.PlayerActions.Disable();
    }
}
