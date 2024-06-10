using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Scipt para manejar el Juego y progreso
// Este Script NO se destruye cuando cambias de escena, se mantiene
// Autor: Pedro Sotelo Arce 
// Last Modified: 28/05/2024
public class GameManager : MonoBehaviour
{
    // Definimos un instancia para poder llamarlo desde otros scripts
    public static GameManager instance;
    // Hacemos un Hash para almacenar los NPCs con los que YA se ha interactuado
    private HashSet<int> interactedNpcs = new HashSet<int>();

    // IDs de los NPCs con los que si tienes que hablar
    // IDs de los 3 candidatos
    // Asignados en cada candidato en el inspector
    public int[] requiredNpcs = { 1, 2, 3 }; 

    // Texto que despliega el contador 
    public Text npcInteractionCounterText; 
    public Image counterHolder;

    // Mensaje cuando se cumpla la condicion
    public string finalMessage = "Dirigete a presentar el examen a la casa azul!"; // The final message to display

    // Que NO se destruya este archivo
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Marcar un NPC si ya hablaste con el
    public void MarkNpcAsInteracted(int npcID)
{
    if (npcID == 5) return; // Ignorar el NPC con ID 4

    if (!interactedNpcs.Contains(npcID))
    {
        interactedNpcs.Add(npcID);
        UpdateNpcInteractionCounter();
        CheckIfAllNpcsInteracted();
    }
}

    // Revisar si ya hablaste con todos los NPCs requeridos
    public bool CheckIfAllNpcsInteracted()
    {
        foreach (int id in requiredNpcs)
        {
            if (!interactedNpcs.Contains(id))
            {
                return false;
            }
        }
        return true;
    }

    // Actualizar el contador de interacciones restantes
    private void UpdateNpcInteractionCounter()
    {
        if (npcInteractionCounterText != null)
        {
            int count = 0;
            foreach (int id in requiredNpcs)
            {
                if (interactedNpcs.Contains(id))
                {
                    count++;
                }
            }

            if (count == requiredNpcs.Length)
            {
                npcInteractionCounterText.text = finalMessage; // Display the final message
            }
            else
            {
                npcInteractionCounterText.text = "Habla con los candidatos!: " + count + "/" + requiredNpcs.Length;
            }

            npcInteractionCounterText.gameObject.SetActive(count > 0); // Show counter only if at least one required NPC is interacted
            counterHolder.gameObject.SetActive(count > 0);
        }
    }

    // Esconder el PopUp del contador
    public void HidePopup()
    {
        if (counterHolder != null)
        {
            counterHolder.gameObject.SetActive(false);
            npcInteractionCounterText.gameObject.SetActive(false);
        }
    }
}
