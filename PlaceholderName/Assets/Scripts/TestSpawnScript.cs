using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawnScript : MonoBehaviour
{
    public GameObject zombie;

    private void Start()
    {
        StartCoroutine("Countdown");
    }

    private void Spawn()
    {


        Instantiate(zombie, transform.position, Quaternion.identity);
    }

    private IEnumerator Countdown()
    {
        for(int i = 3; i > 0; i--)
        {
            yield return new WaitForSeconds(1f);
        }

        Spawn();
    }
}
