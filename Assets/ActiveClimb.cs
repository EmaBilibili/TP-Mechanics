using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveClimb : MonoBehaviour
{
    public LedgeClimbing ledgeClimbing;
    public PlayerController playerController;

    private void Update()
    {
        if (playerController.isJumping && Input.GetKey(KeyCode.E))
        {
            ledgeClimbing.gameObject.SetActive(true);
        }
        else
        {
            ledgeClimbing.gameObject.SetActive(false);
        }
    }
}
