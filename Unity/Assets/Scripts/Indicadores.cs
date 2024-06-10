using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script para manejar el uso de indicadores
// Autor: Pedro Sotelo Arce 
// Last Modified: 29/05/2024
public class Indicadores : MonoBehaviour
{
    public GameObject flecha;
    public bool proximidad;

    void Update()
    {
        if (proximidad)
        {
            HideInteractionPopupF();
        }
        else if (!proximidad)
        {
            ShowInteractionPopupF();
        }
    }

    // Trigger ENTER
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            proximidad = true;
        }
    }

     // Manejo de proximidad EXIT
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            proximidad = false;
        }
    }


    public void ShowInteractionPopupF()
    {
        if (flecha != null)
        {
            flecha.SetActive(true);
        }
    }

    // Esconder el popup
    public void HideInteractionPopupF()
    {
        if (flecha != null)
        {
            flecha.SetActive(false);
        }
    }


}
