using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAssignerController : MonoBehaviour
{
    public bool isPlayer2 = false;

    public void AssignBoolean()
    {
        if(isPlayer2 == false)
        {
            isPlayer2 = true;
        }
    }
}
