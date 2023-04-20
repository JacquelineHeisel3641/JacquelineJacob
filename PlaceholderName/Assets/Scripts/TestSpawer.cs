/*****************************************************************************
// File Name :         TestSpawer.cs
// Author :            Jacob Bateman
// Creation Date :     April 19, 2023
//
// Brief Description : Spawns in enemies for testing purposes.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawer : MonoBehaviour
{
    public GameObject testMob;

    /// <summary>
    /// Start coroutine to spawn enemy.
    /// </summary>
    void Start()
    {
        StartCoroutine("SpawnMob");
    }

    /// <summary>
    /// Spawns enemy after 3 seconds have passed.
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnMob()
    {
        for(int i = 3; i > 0; i--)
        {
            yield return new WaitForSeconds(1f);
        }

        Instantiate(testMob, gameObject.transform.position, Quaternion.identity);
    }
}
