using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Scipt para manejar el salir de las casas
// Autor: Pedro Sotelo Arce 
// Last Modified: 28/05/2024

public class GetOut : MonoBehaviour
{

    public static GetOut instance;
    //Al colisionar con el objeto que tenga este script se cambia la escena
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CambiarEscena();
        }
    }

    void CambiarEscena()
    {
        SceneManager.LoadScene(3);
    }

    // Use this function to set the player's position when the scene is loaded
    //private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //{
      //  if (scene.buildIndex == 3) // Check if it's the right scene
        //{
          //  float playerPosX = PlayerPrefs.GetFloat("PlayerPosX");
            // float playerPosY = PlayerPrefs.GetFloat("PlayerPosY");
            // int lastHouseID = PlayerPrefs.GetInt("LastHouseID");


            // Ajustamos la posicion del jugador
            // playerPosY -= 1.0f;

            // Find the player and set their position
            // GameObject player = GameObject.FindGameObjectWithTag("Player");
            // if (player != null)
            // {
               // player.transform.position = new Vector3(playerPosX, playerPosY, player.transform.position.z);
            //}
       // }
    // }

    //void OnEnable()
    //{
      //  SceneManager.sceneLoaded += OnSceneLoaded;
    //}

    //void OnDisable()
    //{
      //  SceneManager.sceneLoaded -= OnSceneLoaded;
    //}
}
