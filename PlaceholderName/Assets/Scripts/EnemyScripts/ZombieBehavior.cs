using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehavior : MonoBehaviour
{
    [SerializeField] private int damageDealt;
    private int playersAssignedCounter = 0;

    [SerializeField] private float speed;
    private float followDecider;

    private bool followingPlayer1;

    public GameObject player1;
    public GameObject player2;

    Vector3 playerPos;

    private void Start()
    {
        followDecider = Random.Range(0.01f, 0.02f);

        if(followDecider == 0.01f)
        {
            followingPlayer1 = true;
        }
        else
        {
            followingPlayer1 = false;
        }
    }

    private void Update()
    {
        if (followingPlayer1)
        {
            Vector3 playerPos = player1.transform.position;
        }
        else
        {
            Vector3 playerPos = player2.transform.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, playerPos, 
            speed * Time.deltaTime);
    }

    private void AssignPlayers()
    {
        player1 = GameObject.FindWithTag("Player1");
        player2 = GameObject.FindWithTag("Player2");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player1"))
        {
            followingPlayer1 = true;
        }
        else if(collision.gameObject.CompareTag("Player2"))
        {
            followingPlayer1 = false;
        }
    }
}
