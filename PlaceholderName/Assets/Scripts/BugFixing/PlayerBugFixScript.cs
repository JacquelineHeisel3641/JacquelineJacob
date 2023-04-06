using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBugFixScript : MonoBehaviour
{
    PlayerControls controls;

    Rigidbody2D rb2D;

    Vector2 movement;
    Vector2 rotation;

    private float angle;

    private Vector3 savedRotation;

    private void Awake()
    {
        controls = new PlayerControls();

        rb2D = gameObject.GetComponent<Rigidbody2D>();

        //Sets up rotation.
        controls.PlayerActions.Rotate.performed += context => rotation =
            context.ReadValue<Vector2>();
        controls.PlayerActions.Rotate.canceled += context => rotation =
            Vector2.zero;

        controls.PlayerActions.Rotate.performed += context => Rotation();
    }

    private void FixedUpdate()
    {
        rb2D.velocity = movement;

        angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    public void PlayerMovement(InputAction.CallbackContext context) => movement 
        = context.ReadValue<Vector2>();

    public void Rotation()
    {

    }
}
