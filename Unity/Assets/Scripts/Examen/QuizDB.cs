using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Scipt para el manejo de la "Database" del quiz
// Autor: Pedro Sotelo Arce 
// Last Modified: 28/05/2024

public class QuizDB : MonoBehaviour
{   
    // Inicializamos variables
    [SerializeField] private List<Question> _questionList = null;
    private List<Question> _backup = null;
    private int currentIndex = 0; // ID de la pregunta actual

    // Hacemos un backup en Awake
    private void Awake()
    {
        _backup = _questionList.ToList();
    }
    // Mostrar la sigueiente pregunta
    public Question GetNext(bool remove = true)
    {
        if (_questionList.Count == 0 || currentIndex >= _questionList.Count)
        {
            RestoreBackup();
        }

        Question q = _questionList[currentIndex];

        if (remove)
        {
            _questionList.RemoveAt(currentIndex);
        }
        else
        {
            currentIndex++;
        }

        return q;
    }
    // Restablecer el backup
    private void RestoreBackup()
    {
        _questionList = _backup.ToList();
        currentIndex = 0;
    }
    // Verificr si todavia existen preguntas
    public bool HasQuestions()
    {
        return currentIndex < _questionList.Count;
    }
}
