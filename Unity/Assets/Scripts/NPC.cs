using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script para el manejo de los NPCs
// Autor: Pedro Sotelo Arce 
// Last Modified: 28/05/2024
public class NPC : MonoBehaviour
{
    public int npcID; // Identificador del NPC (asignador en el Unity Inspector)
    public GameObject panelDialogo; // GameObject del panel del dialogo (la imagen)
    public Text Texto; // Texto del NPC
    public string[] dialogo; // Lista de dialogos
    private int index; // Indice del texto
    public GameObject boton; // Boton de continuar

    // PopUps
    public GameObject interactionPopup;

    // Velocidad para imprimir texto
    public float velocidadEscribir;

    // Verificar si el jugador se encuentra cerca
    public bool proximidad;

    // Verificar si el diálogo está en progreso
    private bool dialogoEnProgreso = false;

    // Al iniciar que cualquier popup se desactive
    void Start()
    {
        if (interactionPopup != null)
        {
            interactionPopup.SetActive(false);
        }
    }

    // Si se cumplen dos condiciones
    // Que el jugador este cerca Y que el panel este apagado
    // Se llama la funcion ShowInteractionPopUp
    // Si no, se esconde llamando HideInteractionPopUp
    void Update()
    {
        if (proximidad && !panelDialogo.activeInHierarchy && !dialogoEnProgreso)
        {
            ShowInteractionPopup();
        }
        else
        {
            HideInteractionPopup();
        }

        // Si estas cerca y presionas X
        // Corre la interacción, mientras que el NPC tenga
        // Dialogo asignado, y se escribe su dialogo
        if (Input.GetKeyDown(KeyCode.X) && proximidad && !dialogoEnProgreso)
        {
            if (panelDialogo == null || Texto == null || boton == null)
            {
                Debug.LogError("One or more UI elements are not assigned in the Inspector.");
                return;
            }
            if (panelDialogo.activeInHierarchy)
            {
                zeroTexto();
            }
            else
            {
                panelDialogo.SetActive(true);
                if (dialogo.Length > 0) // Comprobar si hay diálogos disponibles
                {
                    StartCoroutine(Escribiendo());
                }
                // Mark this NPC as interacted
                GameManager.instance.MarkNpcAsInteracted(npcID);
            }
        }

        if (dialogo.Length > 0 && Texto.text == dialogo[index])
        {
            boton.SetActive(true);
        }
    }

    // Funcion para limpiar el panel de texto, y que se pueda
    // Volver a escribir en el
    public void zeroTexto()
    {
        if (Texto == null) return;
        Texto.text = " ";
        index = 0;
        if (panelDialogo != null)
        {
            panelDialogo.SetActive(false);
        }
        dialogoEnProgreso = false;
    }

    // Mostrar el popup
    public void ShowInteractionPopup()
    {
        if (interactionPopup != null)
        {
            interactionPopup.SetActive(true);
        }
    }

    // Esconder el popup
    public void HideInteractionPopup()
    {
        if (interactionPopup != null)
        {
            interactionPopup.SetActive(false);
        }
    }

    // Corutina para manejar que los NPCs te puedan llamar por tu nombre
    // Y que este sea agregado al dialogo al escribir {playerName}
    // En sus dialogos, ademas de desplegar visualmente la escritura
    IEnumerator Escribiendo()
    {
        dialogoEnProgreso = true;
        if (Texto == null) yield break;
        Texto.text = ""; // Ensure text is reset before writing
        string currentDialog = dialogo[index];
        if (currentDialog.Contains("{playerName}"))
        {
            currentDialog = currentDialog.Replace("{playerName}", NameHandler.playerName);
        }
        foreach (char letter in currentDialog.ToCharArray())
        {
            Texto.text += letter;
            yield return new WaitForSeconds(velocidadEscribir);
        }
        dialogoEnProgreso = false;
    }

    // Al terminarse una linea de dialogo, si hay mas
    // Se activa el boton de "Continuar"
    // Si se activa, se comienza a escribir la siguiente linea de dialogo
    public void siguienteLinea()
    {
        if (Texto == null || boton == null) return;
        boton.SetActive(false);
        if (index < dialogo.Length - 1)
        {
            index++;
            Texto.text = "";
            StartCoroutine(Escribiendo());
        }
        else
        {
            zeroTexto();
        }
    }

    // Manejo de proximidad ENTER
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
            StopAllCoroutines();
            ResetDialog();
        }
    }

    // Reset the dialogue
    private void ResetDialog()
    {
        index = 0;
        if (Texto != null)
        {
            Texto.text = "";
        }
        if (panelDialogo != null)
        {
            panelDialogo.SetActive(false);
        }
        if (boton != null)
        {
            boton.SetActive(false);
        }
        dialogoEnProgreso = false;
    }
}
