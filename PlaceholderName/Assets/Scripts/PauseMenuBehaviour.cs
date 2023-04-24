using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuBehaviour : MonoBehaviour
{
    public InputAction openPause;
    public GameObject pauseMenu;
    // finding the player controls/ is the variable 


    /// <summary>
    /// making the player controls script availbale to use, does at the start 
    /// and never again 
    /// </summary>
    /*private void awake()
    {
        playercontrols = new playercontrols();
    }*/

    private void Start()
    {
        //equivalent of get key down
        openPause.started += OpenPause_started;

        //equivalent of get key up 
        openPause.canceled += OpenPause_canceled;

        openPause.Enable();
    }

   

    private void OpenPause_started(InputAction.CallbackContext obj)
    {

        OpenPauseMenu();


    }

    private void OpenPause_canceled(InputAction.CallbackContext obj)
    {
        //not used yet  
    }

    /* private void OnEnable()
     {
         playerControls.Enable();

         playerControls.PlayerActions.PauseMenu.performed += ctx => ;
     }*/

    /* private void OnDisable()
     {
         playerControls.Disable();
     }*/

    void OpenPauseMenu()
    {
        //opening the menu 
          pauseMenu.SetActive(true);

        // actually pausing the game 
          Time.timeScale = 0f;
        
       
    }
}
