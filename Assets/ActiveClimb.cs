using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ActiveClimb : MonoBehaviour
{
    public LedgeClimbing ledgeClimbing;
    public PlayerController playerController;
    public BoxCollider2D GripCollider;

    private void Start()
    {
        GripCollider.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (playerController.isJumping && Input.GetKey(KeyCode.E))
        {
            // ledgeClimbing.gameObject.SetActive(true);
            GripCollider.enabled = true;
        }
        else
        {
            // ledgeClimbing.gameObject.SetActive(false);
            GripCollider.enabled = false;
        }
    }
}
