using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangedWeaponData", menuName = "Ranged Weapon Data")]

//IGNORE THIS SCRIPT.

public class RangedWeaponData : ScriptableObject
{
    [SerializeField] private float baseDamage = 5f;
    [SerializeField] private float bulletSpeedMod = 2f;
    [SerializeField] private float fireRate = 1f;

    [SerializeField] private int baseAmmoCount = 10;
    [SerializeField] private int weaponID;

    [SerializeField] private string dataFileName;
    [SerializeField] private string bulletPrefabName = "DefaultBullet";

    public float BaseDamage { get => baseDamage; set => baseDamage = value; }

    public int BaseAmmoCount { get => baseAmmoCount; set => baseAmmoCount = value; }
    public int WeaponID { get => weaponID; set => weaponID = value; }

    public string DataFileName { get => dataFileName; set => dataFileName = value; }
    public string BulletPrefabName { get => bulletPrefabName; set => 
            bulletPrefabName = value; }

    public RangedWeaponData()
    {

    }

    public RangedWeaponData(float baseDamage, int weaponID)
    {
        BaseDamage = baseDamage;
    }

    public RangedWeaponData(float baseDamage, int baseAmmoCount, int weaponID)
    {
        BaseDamage = baseDamage;
        BaseAmmoCount = baseAmmoCount;
        WeaponID = weaponID;
    }

    public RangedWeaponData(float baseDamage, int baseAmmoCount, int weaponID, 
        string bulletPrefabName)
    {
        BaseDamage = baseDamage;
        BaseAmmoCount = baseAmmoCount;
        WeaponID = weaponID;
        BulletPrefabName = bulletPrefabName;
    }
}
