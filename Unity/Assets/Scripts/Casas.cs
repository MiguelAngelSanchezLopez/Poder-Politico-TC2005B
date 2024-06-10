using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Scipt para manejar el ingreso a las casas
// Autor: Pedro Sotelo Arce 
// Last Modified: 28/05/2024
public class Casas : MonoBehaviour
{
    public int casaID;  // Identificador de la casa

    // Al un jugado colisionar con la casa, se llama la funcion "Cambiar Escena"
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Store the player's position
            PlayerPrefs.SetFloat("PlayerPosX", collision.transform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY", collision.transform.position.y);
            PlayerPrefs.SetInt("LastHouseID", casaID);

            CambiarEscena();
        }
    }

    // Dependiendo del ID de la casa (Asignado en el inspector de Unity)
    // Que te mande a una de las escenas diferentes, dependiendo de que casa es
    void CambiarEscena()
    {
        switch (casaID)
        {
            case 0:
                SceneManager.LoadScene(4);
                break;
            case 1:
                SceneManager.LoadScene(5);
                break;
            case 2:
                SceneManager.LoadScene(6);
                break;
            case 3:
                SceneManager.LoadScene(7);
                break;
            // Si no tienen ningun ID de los que estan arriba, mostrar un Error
            default:
                Debug.LogError("ID de casa inválido.");
                break;
        }
    }
}