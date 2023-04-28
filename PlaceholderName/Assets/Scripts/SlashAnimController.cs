/*****************************************************************************
// File Name :         SlashAnimController.cs
// Author :            Jacob Bateman
// Creation Date :     April 26, 2023
//
// Brief Description : Plays the slash animation whenever an enemy attacks.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAnimController : MonoBehaviour
{
    public Animator slash;

    public GameObject parent;

    /// <summary>
    /// Plays the slash animation with the rotation of its parent object.
    /// </summary>
    private void Start()
    {
        slash.Play("Slash", 0);

        transform.rotation = parent.transform.rotation;
    }

    /// <summary>
    /// Disables the animation once it has played, triggered by a key frame.
    /// </summary>
    public void DisableAnimation()
    {
        gameObject.SetActive(false);
    }
}
