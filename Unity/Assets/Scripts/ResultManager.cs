using UnityEngine;
using UnityEngine.UI;

// Scipt para el manejo de los Resultados
// Autor: Pedro Sotelo Arce 
// Last Modified: 28/05/2024
public class ResultManager : MonoBehaviour
{   
    // Texto de los resultados
    public Text resultText;

    void Start()
    {
        // Desplegar el voteMessage, que contiene ahora el string
        // De los resultados del candidato por el que votaste
        resultText.text = ElectionManager.voteMessage;
    }
}
