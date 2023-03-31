using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    private RangedWeaponData currentGunData;

    [SerializeField] private float bulletSpeed = 5f;

    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb2D.AddForce(Vector2.up * bulletSpeed);
    }


}
