using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Scipt para manejar el inicio de las votaciones
// Autor: Pedro Sotelo Arce 
// Last Modified: 28/05/2024
public class ComenzarVotacion : MonoBehaviour
{   
        // Si el jugador colisiona con el objeto que tenga este script
    // Se llama la funcion CambiarEscenaV
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(CambiarEscenaV());
        }
    }

    // Cambiar escena a la #10 (Escena de Votacion)
    private IEnumerator CambiarEscenaV()
    {
        AsyncOperation asyncLoad = null;
        try
        {
            asyncLoad = SceneManager.LoadSceneAsync(10);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to load scene: " + e.Message);
            yield break;
        }

        while (!asyncLoad.isDone)
        {
            // Optionally, you can display a loading screen or progress bar here
            yield return null;
        }
    }
}
