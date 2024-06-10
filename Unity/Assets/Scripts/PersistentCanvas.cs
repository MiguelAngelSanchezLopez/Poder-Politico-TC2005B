using UnityEngine;

// Scipt para el manejo un canvas que NO se destruya
// Autor: Pedro Sotelo Arce 
// Last Modified: 28/05/2024
public class PersistentCanvas : MonoBehaviour
{
    // Hacemos que este objeto no se destruya cuando cargue una escena
    // Esto se usa para que el contador de interaccion, no se destruya y se
    // pueda actualizar aun cuando cambias de escena
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
