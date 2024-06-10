using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Net.Http;
using System.Threading.Tasks;

// Script para manejar el nombre que el jugador ingresa
// Autor: Pedro Sotelo Arce 
// Last Modified: 28/05/2024
public class NameHandler : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public Button submitButton;
    public static string playerName;
    public Text errorMessage;
    public static int idUsuarioFinal;
    public string linkAPI = "https://votingapi2024.azurewebsites.net";

    private List<string> invalidNames = new List<string> { "puta", "pendejo", "imbecil", "tonto", "perra", "bitch", "put4", "p3ndejo", "joto", "maricon" };

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        submitButton.onClick.AddListener(() => StartCoroutine(SaveName()));
    }

    public void ComenzarJuego()
    {
        SceneManager.LoadScene(3);
    }

    private IEnumerator SaveName()
    {
        playerName = nameInputField.text;

        // Check if the name is in the invalid names list
        if (IsNameInvalid(playerName))
        {
            errorMessage.gameObject.SetActive(true);
            errorMessage.text = "Nombre no permitido";
            Debug.Log("Nombre no permitido: " + playerName);
        }
        else
        {
            errorMessage.text = "";
            Debug.Log("El nombre del jugador es: " + playerName);

            // Verificar el nombre en la base de datos
            yield return StartCoroutine(VerificarEnBD(playerName));

            if (idUsuarioFinal > 0)
            {
                ComenzarJuego();
            }
            else
            {
                errorMessage.gameObject.SetActive(true);
                errorMessage.text = "Nombre no encontrado en la base de datos";
                Debug.Log("Nombre no encontrado en la base de datos: " + playerName);
            }
        }
    }

    bool IsNameInvalid(string name)
    {
        foreach (string invalidName in invalidNames)
        {
            if (name.ToLower() == invalidName.ToLower())
            {
                return true;
            }
        }
        return false;
    }

    IEnumerator VerificarEnBD(string playerName)
    {
        string url = $"{linkAPI}/checkName?nombre={playerName}";
        Debug.Log(url);
        WWW hs_post = new WWW(url);
        yield return hs_post;

        if (hs_post.error != null)
        {
            idUsuarioFinal = -1; // Indicar que no se encontró
            Debug.LogError("Error al verificar el nombre: " + hs_post.error);
        }
        else
        {
            if (int.TryParse(hs_post.text, out int idUsuario))
            {
                idUsuarioFinal = idUsuario;
                Debug.Log("ID de usuario encontrado: " + idUsuarioFinal);
            }
            else
            {
                idUsuarioFinal = -1; // Indicar que no se encontró
                Debug.Log("Nombre no encontrado en la base de datos.");
            }
        }
    }
}