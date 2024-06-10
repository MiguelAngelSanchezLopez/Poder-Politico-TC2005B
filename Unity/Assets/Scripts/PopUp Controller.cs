using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Scipt para el manejo de los PopUps
// Autor: Pedro Sotelo Arce 
// Last Modified: 28/05/2024
public class PopUpController : MonoBehaviour
{
    public GameObject popupText; // GameObject q contenga el popup
    public float displayDuration = 3.0f; // Duracion del display

    // Se llama la corutina

    private void Start()
    {
        if (popupText != null)
        {
            StartCoroutine(ShowPopupText());
        }
    }

    // Definimos la corutina para activar el popup por cierto tiempo
    // Se activa, espera unos segundos, y se desactiva
    private IEnumerator ShowPopupText()
    {
        popupText.gameObject.SetActive(true); 
        yield return new WaitForSeconds(displayDuration);
        popupText.gameObject.SetActive(false);
    }
}
