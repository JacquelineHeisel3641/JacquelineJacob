using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeaponBehavior : MonoBehaviour
{
    PlayerControls controls;

    private RangedWeaponData[] carriedWeapons = new RangedWeaponData[3];

    private GameObject[] bulletPrefabArray = new GameObject[10];
    private GameObject[] bulletPrefabNames = new GameObject[10];

    private int equippedWeapon = 0;

    public RangedWeaponData rangedWeapon;

    public GameObject bulletPrefab;

    [SerializeField] private GameObject basicBullet;

    private void Awake()
    {
        controls = new PlayerControls();

        carriedWeapons[0] = Resources.Load<RangedWeaponData>("BasicPistolData");
        carriedWeapons[1] = Resources.Load<RangedWeaponData>("TestGunData");
        carriedWeapons[2] = Resources.Load<RangedWeaponData>("TestGunData");

        bulletPrefabArray[0] = basicBullet;

        bulletPrefab = bulletPrefabArray[0];

        //controls.PlayerActions.SwitchWeapons.performed += context => SwitchWeapons();
    }

    private void Start()
    {
        rangedWeapon = carriedWeapons[0];

        //StartCoroutine(DebugWeaponDataPrint());
    }

    private void SwitchWeapons()
    {
        switch(equippedWeapon)
        {
            case 0:
                equippedWeapon++;
                RangedWeaponAssigner();
                break;
            case 1:
                equippedWeapon++;
                RangedWeaponAssigner();
                break;
            case 2:
                equippedWeapon = 0;
                RangedWeaponAssigner();
                break;   
        }
    }

    private void RangedWeaponAssigner()
    {
        rangedWeapon = carriedWeapons[equippedWeapon];

        bulletPrefab = bulletPrefabArray[0];
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
