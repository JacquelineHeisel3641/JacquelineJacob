using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2 : MonoBehaviour
{
    public GameObject[] spawners = new GameObject[2];

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            for (int i = spawners.Length; i > 0; i--)
            {
                spawners[i - 1].SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            for (int i = spawners.Length; i > 0; i--)
            {
                spawners[i - 1].SetActive(false);
            }
        }
    }
}
