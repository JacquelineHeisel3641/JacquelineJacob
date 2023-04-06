using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLeadPlayerAssigning : MonoBehaviour
{
    public GameObject leadPlayer;

    private bool leadPlayerAssigned = false;

    void Update()
    {
        if (leadPlayerAssigned)
        {
            gameObject.transform.position = new Vector3(leadPlayer.transform.
                position.x, leadPlayer.transform.position.y, 
                leadPlayer.transform.position.z - 10);
        }
    }

    public void LeadPlayerAssigner(GameObject player)
    {
        if (leadPlayerAssigned == false)
        {
            leadPlayer = player;

            leadPlayerAssigned = true;
        }
    }
}
