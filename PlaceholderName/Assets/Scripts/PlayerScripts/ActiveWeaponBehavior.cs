/*****************************************************************************
// File Name :         ActiveWeaponBehavior.cs
// Author :            Jacob Bateman
// Creation Date :     April 6, 2023
//
// Brief Description : Sets the active bullet prefab for the player to instantiate.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActiveWeaponBehavior : MonoBehaviour
{
    InputActionAsset inputAsset;
    InputActionMap inputMap;

    public GameObject[] bulletPrefabArray = new GameObject[10];
    private GameObject[] carriedWeapons = new GameObject[10];

    public int activeBulletPrefab = 0;

    public GameObject bulletPrefab;

    [SerializeField] private GameObject basicBullet;
    [SerializeField] private GameObject reflectorBullet;
    [SerializeField] private GameObject bazookaBullet;

    public GameObject gun;

    InputAction switchWeapons;

    public Sprite basicPistol;
    public Sprite reflectorFlector;
    public Sprite breadBazooka;

    /// <summary>
    /// Assigns bullet prefabs to their array.
    /// </summary>
    private void Awake()
    {
        //Sets up references to the input map.
        inputAsset = this.GetComponent<PlayerInput>().actions;
        inputMap = inputAsset.FindActionMap("PlayerActions");

        //Sets a way to access the SwitchWeapons action.
        switchWeapons = inputMap.FindAction("SwitchWeapons");

        //Populates the bulletPrefabArray with all bullet prefabs in the game.
        bulletPrefabArray[0] = basicBullet;
        bulletPrefabArray[1] = reflectorBullet;
        bulletPrefabArray[2] = bazookaBullet;

        bulletPrefab = bulletPrefabArray[0];

        switchWeapons.performed += context => SwitchWeapons();
    }

    /// <summary>
    /// Initial setup to make sure there is no null reference exception.
    /// </summary>
    private void Start()
    {
        //Sets active weapon to whatever is in the first slot.
        bulletPrefab = bulletPrefabArray[0];

        gun.GetComponent<SpriteRenderer>().sprite = basicPistol;
    }

    /// <summary>
    /// Switches active bullet prefab when SwitchWeapons action is taken.
    /// </summary>
    private void SwitchWeapons()
    {
        //Cycles through weapons depending on the currently active bullet prefab.
        switch(activeBulletPrefab)
        {
            case 0:
                //Increments to next weapon.
                activeBulletPrefab++;
                RangedWeaponAssigner();
                gun.GetComponent<SpriteRenderer>().sprite = reflectorFlector;
                break;
            case 1:
                //Increments to next weapon.
                activeBulletPrefab++;
                RangedWeaponAssigner();
                gun.GetComponent<SpriteRenderer>().sprite = breadBazooka;
                break;
            case 2:
                //Resets active weapon to first slot.
                activeBulletPrefab = 0;
                RangedWeaponAssigner();
                gun.GetComponent<SpriteRenderer>().sprite = basicPistol;
                break;   
        }
    }

    /// <summary>
    /// Sets bulletPrefab to new bullet prefab.
    /// </summary>
    private void RangedWeaponAssigner()
    {
        bulletPrefab = bulletPrefabArray[activeBulletPrefab];
    }
}
