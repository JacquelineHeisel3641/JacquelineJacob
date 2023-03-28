using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangedWeaponData", menuName = "Ranged Weapon Data")]

public class RangedWeaponData : ScriptableObject
{
    [SerializeField] private float baseDamage = 5f;

    [SerializeField] private int baseAmmoCount = 10;
    [SerializeField] private int weaponID;

    [SerializeField] private string dataFileName;

    public float BaseDamage { get => baseDamage; set => baseDamage = value; }

    public int BaseAmmoCount { get => baseAmmoCount; set => baseAmmoCount = value; }
    public int WeaponID { get => weaponID; set => weaponID = value; }
    public string DataFileName { get => dataFileName; set => dataFileName = value; }

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
}
