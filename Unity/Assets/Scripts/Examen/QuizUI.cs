using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// Scipt para el manejo de la UI del Quiz
// Autor: Pedro Sotelo Arce 
// Last Modified: 28/05/2024
public class QuizUI : MonoBehaviour
{   
    // Inicializamos elementos del UI del examen
    [SerializeField] private Text _pregunta = null;
    [SerializeField] private List<BotonOpciones> _botonLista = null;
    [SerializeField] private Slider _confidenceSlider = null;
    [SerializeField] private Text _confidenceText = null;
    [SerializeField] private GameObject _panels = null;

    // Construccion para las preguntas y los botones
    public void Constructor(Question q, Action<BotonOpciones> callback)
    {
        _pregunta.text = q.text;

        for (int n = 0 ; n < _botonLista.Count; n++)
        {
            _botonLista[n].Constructor(q.options[n], callback);
        }

        _confidenceSlider.value = 0;
    }

    // Deshabilitar UI
    public void DisableUI()
    {
        _pregunta.gameObject.SetActive(false);
        foreach (var button in _botonLista)
        {
            button.gameObject.SetActive(false);
        }
        _confidenceSlider.gameObject.SetActive(false);
        _confidenceText.gameObject.SetActive(false);
        _panels.gameObject.SetActive(false);
        
    }

    // Obtener el nivel de confianza con el slider
    public float GetConfidenceLevel()
    {
        return _confidenceSlider.value;
    }
}
