using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//IGNORE THIS SCRIPT.

public class BulletData : ScriptableObject
{
    [SerializeField] private float bulletSpeed = 2.5f;

    [SerializeField] private PhysicsMaterial2D bulletMaterial;

    public float BulletSpeed { get => bulletSpeed; set => bulletSpeed = value; }

    public PhysicsMaterial2D BulletMaterial { get => bulletMaterial; set => 
            bulletMaterial = value; }

    private BulletData()
    {

    }

    private BulletData(float bulletSpeed)
    {
        BulletSpeed = bulletSpeed;
    }

    private BulletData(float bulletSpeed, PhysicsMaterial2D bulletMaterial)
    {
        BulletSpeed = bulletSpeed;
        BulletMaterial = bulletMaterial;
    }
}
