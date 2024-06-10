using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scipt para manejar el fondo que esta en loop
// Autor: Pedro Sotelo Arce 
// Last Modified: 28/05/2024
public class EndlessBG : MonoBehaviour
{   
    // Float de velocidad
    public float speed;

    // Inicializamos un Renderer
    [SerializeField] private Renderer bgRenderer;

    // Hacemos que se actualice y se mueva
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
