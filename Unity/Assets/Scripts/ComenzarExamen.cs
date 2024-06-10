using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Scipt para manejar el ingreso al examen
// Autor: Pedro Sotelo Arce 
// Last Modified: 28/05/2024
public class ComenzarExamen : MonoBehaviour
{
    // Definimos Variables para controlar si el jugador esta en zona de interaccion
    public bool proximidad;
    // Variable para controlar el PopUp al no poder ingresar el examen
    public GameObject popupHolder;
    public Text popupText; // Objeto de tipo Texto 
    public float popupDuration = 2f; // Duracion del popup

    public GameObject interactionPopup; //PopUp Interaccion
    public GameObject flecha; // Flecha

    // Siempre va a estar checando, si el jugador presiona "X"
    // Y esta cerca del objeto interactuable, se llama la funcion
    // TryStartExam
    void Update()
    {

        if (proximidad && !popupHolder.activeInHierarchy)
        {
            ShowInteractionPopup();
        }
        else
        {
            HideInteractionPopup();
        }
        
        if (Input.GetKeyDown(KeyCode.X) && proximidad)
        {
            TryStartExam();
        }
    }
    

    // Funcion para comprobar si el jugador ha hablado con los 3 candidatos
    // De no ser asi, se despliega un PopUp, y no inicia el examen
    // Si hablo con los 3 candidatos, que inicie el examen y se quite el popup
    private void TryStartExam()
    {
        if (GameManager.instance.CheckIfAllNpcsInteracted())
        {
            GameManager.instance.HidePopup(); // Notify the GameManager to hide the popup
            EscenaExamen();
        }
        else
        {
            ShowPopup("Tienes que interactuar con todos los candidatos antes de comenzar el examen!");
        }
    }

    // Funcion para cambio de escena a la del examen
    // En Build - build settings pueden ver el numero de cada escena
    private void EscenaExamen()
    {
        SceneManager.LoadScene(8);
    }

    // Funcion para mostrar el popup
    private void ShowPopup(string message)
    {
        popupText.text = message;
        popupHolder.gameObject.SetActive(true);
        popupText.gameObject.SetActive(true);
        StartCoroutine(HidePopupAfterDelay(popupDuration));
    }

    // Co-rutina para esconder el popup despues de x tiempo
    private IEnumerator HidePopupAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        popupText.gameObject.SetActive(false);
        popupHolder.gameObject.SetActive(false);
    }

    // Manejo de la proximidad al entrar en el collider del inicio de examen
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            proximidad = true;
        }
    }

    // Manejo de la proximidad - si el jugador se aleja, deja de estar true
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            proximidad = false;
        }
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
}
