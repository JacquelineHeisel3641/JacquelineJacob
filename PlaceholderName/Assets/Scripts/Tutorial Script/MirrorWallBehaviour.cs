using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorWallBehaviour : MonoBehaviour
{
    public GameObject mirrorWall;
    void Update()
    {
        Target2Destoryed();
    }

    void Target2Destoryed()
    {
        if (TutorialDoorBehaviour.targetsDestoryed == 2)
        {
            mirrorWall.SetActive(false);
            
        }

    }
}
