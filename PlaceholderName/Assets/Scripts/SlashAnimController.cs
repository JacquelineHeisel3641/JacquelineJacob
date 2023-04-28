using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAnimController : MonoBehaviour
{
    public Animator slash;

    public GameObject parent;

    private void Start()
    {
        slash.Play("Slash", 0);

        transform.rotation = parent.transform.rotation;
    }

    public void DisableAnimation()
    {
        gameObject.SetActive(false);
    }
}
