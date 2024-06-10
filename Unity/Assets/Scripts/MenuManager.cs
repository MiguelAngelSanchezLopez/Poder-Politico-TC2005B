using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Scipt para controlar los botones 
// Autor: Pedro Sotelo Arce 
// Last Modified: 28/05/2024
public class MenuManager : MonoBehaviour
{   
    // Cargar la escena 12 al interactuar
    // (Escena de Ingresar Nombre)
    public void startGame()
    {
        SceneManager.LoadScene(12);
    }

    // Descartado por ahora
    // NO EN USO
    public void settings()
    {
        SceneManager.LoadScene(4);
    }

    // Regresar al menu principal
    public void backButton()
    {
        SceneManager.LoadScene(0);
    }

    // Cargar el juego
    // (Escena #3)
    public void playGame()
    {
        SceneManager.LoadScene(3);
    }
}
