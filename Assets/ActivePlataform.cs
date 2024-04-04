using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlataform : MonoBehaviour
{
    [SerializeField] private GameObject Plataform;
    [SerializeField] private float disableDuration = 1f; // Duración en segundos para desactivar la plataforma

    private bool isCoroutineExecuting = false;

    private void Update()
    {
        // Verificar si se presionan ambas teclas simultáneamente
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space) && !isCoroutineExecuting)
        {
            // Desactivar la plataforma
            Plataform.SetActive(false);
            // Iniciar la corrutina para reactivar la plataforma después de disableDuration segundos
            StartCoroutine(ReactivatePlataform());
        }
    }

    // Corrutina para reactivar la plataforma después de un período de tiempo
    IEnumerator ReactivatePlataform()
    {
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(disableDuration);
        // Reactivar la plataforma después de disableDuration segundos
        Plataform.SetActive(true);
        isCoroutineExecuting = false;
    }
}