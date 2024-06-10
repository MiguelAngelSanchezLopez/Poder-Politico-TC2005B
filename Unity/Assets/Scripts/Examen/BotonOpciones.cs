using UnityEngine;
using UnityEngine.UI;
using System;

// Scipt para el manejo de los Botones de opcion en el examen
// Autor: Pedro Sotelo Arce 
// Last Modified: 28/05/2024

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class BotonOpciones : MonoBehaviour
{
    // Definimos variables para los visuales
    private Button _boton = null;
    private Image _imagen = null;
    private Text _texto = null;
    private Color _ogColor = Color.black;

    public Opcion Opcion { get; set; }

    // Buscamos todos los componentes
    private void Awake()
    {
        _boton = GetComponent<Button>();
        _imagen = GetComponent<Image>();
        _texto = transform.GetChild(0).GetComponent<Text>();

        _ogColor = _imagen.color;
    }   

    // Constructor de los botones, recibe la opcion y un callback
    public void Constructor(Opcion opcion, Action<BotonOpciones> callback)
    {
        _texto.text = opcion.text;
        _boton.onClick.RemoveAllListeners();
        _boton.enabled = true;
        _imagen.color = _ogColor;

        Opcion = opcion;

        _boton.onClick.AddListener(delegate{
            callback(this);
        });
    }

    // Cambiamos el color del boton
    public void SetColor(Color c)
    {
        _boton.enabled = false;
        _imagen.color = c;
    }
}
