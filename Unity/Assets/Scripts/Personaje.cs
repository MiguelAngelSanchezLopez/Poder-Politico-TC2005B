using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Scipt para el manejo del personaje principal
// Autor: Pedro Sotelo Arce 
// Last Modified: 28/05/2024
public class Personaje : MonoBehaviour
{
    // Variables para controlar el movimiento y animaciones
    Animator animator;
    float speed = 5;
    string isWalkTOP = "isWalkTOP";
    string isWalkBOT = "isWalkBOT";
    string isWalkLEFT = "isWalkLEFT";
    string isWalkRIGHT = "isWalkRIGHT";

    // Flags para las direcciones de movimiento (Es parte de la solucion multiplataforma)
    bool moveUp = false;
    bool moveDown = false;
    bool moveLeft = false;
    bool moveRight = false;

    // Inicializo el componente del Animator y lo asigno a animator
    void Start()
    {
        animator = GetComponent<Animator>();

        //InitializePlayerPosition();
    }

    void Update()
    {
        // Toda la logica para moverse usando W A S D
        // Actualizar los booleanos de la animación
        #region Metodos Caminar PC

        if (Input.GetKey(KeyCode.W) || moveUp)
        {
            moverArriba();
        }
        else
        {
            animator.SetBool(isWalkTOP, false);
        }

        if (Input.GetKey(KeyCode.S) || moveDown)
        {
            moverAbajo();
        }
        else
        {
            animator.SetBool(isWalkBOT, false);
        }

        if (Input.GetKey(KeyCode.D) || moveRight)
        {
            moverDerecha();
        }
        else
        {
            animator.SetBool(isWalkRIGHT, false);
        }

        if (Input.GetKey(KeyCode.A) || moveLeft)
        {
            moverIzquierda();
        }
        else
        {
            animator.SetBool(isWalkLEFT, false);
        }

        #endregion
    }

    // Metodos para el movimiento en todas las direcciones
    // Actualizar booleanos de animacion para cargar distintos sprites
    // Dependiendo de a donde te estes moviendo
    #region FuncionesMoverse
    public void moverArriba()
    {
        transform.localScale = new Vector3(-2, 2, 0);
        transform.position += Time.deltaTime * Vector3.up * speed;
        animator.SetBool(isWalkTOP, true);
    }

    public void moverIzquierda()
    {
        transform.localScale = new Vector3(2, 2, 0);
        transform.position += Time.deltaTime * Vector3.left * speed;
        animator.SetBool(isWalkLEFT, true);
    }

    public void moverDerecha()
    {
        transform.localScale = new Vector3(2, 2, 0);
        transform.position += Time.deltaTime * Vector3.right * speed;
        animator.SetBool(isWalkRIGHT, true);
    }

    public void moverAbajo()
    {
        transform.localScale = new Vector3(-2, 2, 0);
        transform.position += Time.deltaTime * Vector3.down * speed;
        animator.SetBool(isWalkBOT, true);
    }
    #endregion

    // Metodos para marcar las Flags si hay o no movimiento en
    // "X" direccion
    public void StartMoveUp() { moveUp = true; }
    public void StopMoveUp() { moveUp = false; }

    public void StartMoveDown() { moveDown = true; }
    public void StopMoveDown() { moveDown = false; }

    public void StartMoveLeft() { moveLeft = true; }
    public void StopMoveLeft() { moveLeft = false; }

    public void StartMoveRight() { moveRight = true; }
    public void StopMoveRight() { moveRight = false; }

    // NOT ACTIVE
    void CambiarEscena()
    {
        SceneManager.LoadScene(4);
    }
}
