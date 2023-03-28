using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeaponBehavior : MonoBehaviour
{
    PlayerControls controls;

    private RangedWeaponData[] carriedWeapons = new RangedWeaponData[2];

    private int equippedWeapon = 0;

    [SerializeField] private RangedWeaponData rangedWeapon;

    private void Awake()
    {
        controls = new PlayerControls();

        carriedWeapons[0] = Resources.Load<RangedWeaponData>("BasicPistolData");
        carriedWeapons[1] = Resources.Load<RangedWeaponData>("TestGunData");

        //controls.PlayerActions.SwitchWeapons.performed += context => equippedWeapon = context.ReadValue<bool>();
    }

    private void Start()
    {
        rangedWeapon = carriedWeapons[0];

        StartCoroutine(DebugWeaponDataPrint());
    }

    private void SwitchWeapons()
    {
        if(equippedWeapon == 0)
        {
            equippedWeapon = 1;
            rangedWeapon = carriedWeapons[equippedWeapon];
        }
        else
        {
            equippedWeapon = 0;
            rangedWeapon = carriedWeapons[equippedWeapon];
        }
    }

    private IEnumerator DebugWeaponDataPrint()
    {
        for (; ; )
        {
            print(rangedWeapon.BaseAmmoCount);
            print(equippedWeapon);

            yield return new WaitForSeconds(3f);
        }
    }

    private void OnEnable()
    {
        controls.PlayerActions.SwitchWeapons.Enable();
    }

    private void OnDisable()
    {
        controls.PlayerActions.SwitchWeapons.Disable();
    }
}
