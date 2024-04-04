using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ActivePlataform : MonoBehaviour
{
    [SerializeField] private GameObject Plataform;
    [SerializeField] private BoxCollider2D PlataformCollider;
    [SerializeField] private float disableDuration = 1f;
    public Rigidbody2D playerRb;
    private bool isCoroutineExecuting = false;
    public PlayerController PlayerController;

    private void Start()
    {
        PlataformCollider.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space) && !isCoroutineExecuting && PlayerController.IsGrounded())
        {
            // Plataform.SetActive(false);
            PlataformCollider.enabled = false;
            StartCoroutine(ReactivatePlataform());
        }
        if (playerRb.velocity.y > 0.1f)
        {
            // Plataform.SetActive(false);
            PlataformCollider.enabled = false;
        }
        else if (playerRb.velocity.y < -0.1f && !isCoroutineExecuting)
        {
            // Plataform.SetActive(true);
            PlataformCollider.enabled = true;
        }
    }
    IEnumerator ReactivatePlataform()
    {
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(disableDuration);
        // Plataform.SetActive(true);
        PlataformCollider.enabled = true;
        isCoroutineExecuting = false;
    }
}