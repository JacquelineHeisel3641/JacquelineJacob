using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls controls;

    private float rotationControl;

    Vector2 movement;
    Vector2 rotation;

    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletSpawn;

    /// <summary>
    /// Activates player actions.
    /// </summary>
    private void Awake()
    {
        //References the player controls.
        controls = new PlayerControls();

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

        controls.PlayerActions.Shoot.performed += context => Shoot();
    }

    /// <summary>
    /// Executes movement and rotation when receiving player input.
    /// </summary>
    private void FixedUpdate()
    {
        //Moves the player.
        Vector2 movementVelocity = new Vector2(movement.x, movement.y) * 5 *
            Time.deltaTime;
        transform.Translate(movementVelocity, Space.World);

        //Debug.Log(rotation.x);

        /*if(rotation.x >= 1.5f)
        {
            //Debug.Log("1");

            rotationControl = rotation.y;
        }
        else
        {
            //Debug.Log("2");

            rotationControl = rotation.x;
        }*/

        Debug.Log(rotationControl);

        rotationControl = rotation.x + rotation.y;

        //Rotates the player.
        Vector3 rotationVelocity = new Vector3(0, 0, -rotationControl) * 350f * 
            Time.deltaTime;
        transform.Rotate(rotationVelocity, Space.Self);
    }

    private void Shoot()
    {
        Instantiate(bullet, bulletSpawn.transform.position, transform.rotation);
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