using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSpawnerBehaviour : MonoBehaviour
{
    public GameObject zombie;

    //Points of enemy spawn to facilitate higher spawning amounts.
    public GameObject spawnLoc1;
    public GameObject spawnLoc2;
    public GameObject spawnLoc3;
    public GameObject spawnLoc4;

    private Vector3 spawnPos1;
    private Vector3 spawnPos2;
    private Vector3 spawnPos3;
    private Vector3 spawnPos4;

    public bool zombieSpawned;



    private void Start()
    {
        //Gets the physical locations of the spawnLoc game objects and assigns
        //them to Vector3 spawnPos variables.
        spawnPos1 = spawnLoc1.transform.position;
        spawnPos2 = spawnLoc2.transform.position;
        spawnPos3 = spawnLoc3.transform.position;
        spawnPos4 = spawnLoc4.transform.position;
        zombieSpawned = false;

}

    // Update is called once per frame
    void Update()
    {
        if (TutorialDoorBehaviour.door2Unlocked && zombieSpawned != true)
        {
            Instantiate(zombie, spawnPos1, Quaternion.identity);
            Instantiate(zombie, spawnPos2, Quaternion.identity);
            Instantiate(zombie, spawnPos3, Quaternion.identity);
            Instantiate(zombie, spawnPos4, Quaternion.identity);

            zombieSpawned = true;
        }
    }
}
