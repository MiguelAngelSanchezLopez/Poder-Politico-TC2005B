    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

// Scipt para el manejo del QUIZ
// Autor: Pedro Sotelo Arce 
// Last Modified: 28/05/2024
public class QuizManager : MonoBehaviour
{
    //Variables para el quiz (deben de asignarse en el inspector)
    [SerializeField] private AudioClip _correcta; // Audio resp correcto
    [SerializeField] private AudioClip _incorrecta; // Audio resp incorrecta
    [SerializeField] private Color _colorCorrecta = Color.black; // color resp correcta
    [SerializeField] private Color _colorIncorrecta = Color.black; // color resp incorrecta
    [SerializeField] private float _waitTime = 0.0f; // Timer para esperar
    [SerializeField] private Text scoreText; // Texto score user
    [SerializeField] private Text _botscoreText1; // Texto score bot1
    [SerializeField] private Text _botscoreText2; // same pero bot 2
    [SerializeField] private Text _botscoreText3; // same pero bot 3
    [SerializeField] private Text _botscoreText4; // same pero bot 4
    [SerializeField] private GameObject resultsPanel; // Panel de resultados
    [SerializeField] private Text resultsText; // Texto de resultados
    [SerializeField] private Button _resultsBoton; // Boton de continuar
    [SerializeField] private GameObject PanelBoton; // Panel conteniendo boton
    private QuizDB _quizDB = null; // Iniciamos los scripts QuizDB
    private QuizUI _quizUI = null; // Quiz UI
    private AudioSource _audioSource = null;
    private int score = 0; // El jugador empieza con 0 pts
    private List<float> confidenceLevels = new List<float>(); // Lista para medir los niveles de confianza

    private List<Bot> bots; // Lista de Bots

    private void Start()
    {
        // Buscamos y asignamos los componentes
        _quizDB = GameObject.FindObjectOfType<QuizDB>();
        _quizUI = GameObject.FindObjectOfType<QuizUI>();
        _audioSource = GetComponent<AudioSource>();

        // Hacemos una lista con los Bots de la clase bot
        bots = new List<Bot>
        {
            new Bot("Juan"),
            new Bot("Pedro"),
            new Bot("Laura"),
            new Bot("Alex")
        };

        //Corremos procesos que se tienen que estar updating
        UpdateScoreText();
        UpdateBotScoreTexts();
        NextQuestion();
    }

    // Revisar y pasar a la siguiente pregunta en caso de que exista
    private void NextQuestion()
    {
        if (_quizDB.HasQuestions())
        {
            _quizUI.Constructor(_quizDB.GetNext(), GiveAnswer);
            AskQuestion();
        }
        else
        {
            EndQuizRes();
        }
    }

    // Hacer una preugnta y que los bots la contesten
    public void AskQuestion()
    {
        foreach (var bot in bots)
        {
            bot.AnswerQuestion(); // Cada bot la contesta
        }
        UpdateBotScoreTexts(); // Actualizamos el texto de los bots
    }

    // Verificar si la respuesta es correcta
    private void GiveAnswer(BotonOpciones botonOpcion)
    {
        float confidenceLevel = _quizUI.GetConfidenceLevel();
        confidenceLevels.Add(confidenceLevel);
        StartCoroutine(GiveAnswerRoutine(botonOpcion));
    }

    // Corutina para manejar que audio suena y que color se pone
    // dependiendo de si es correcta o incorrecta
    private IEnumerator GiveAnswerRoutine(BotonOpciones botonOpcion)
    {
        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }

        _audioSource.clip = botonOpcion.Opcion.correct ? _correcta : _incorrecta;
        botonOpcion.SetColor(botonOpcion.Opcion.correct ? _colorCorrecta : _colorIncorrecta);

        _audioSource.Play();

        yield return new WaitForSeconds(_waitTime);

        if (botonOpcion.Opcion.correct)
        {
            // Si la opcion es correcta, sumar 10 pts
            score += 10;
        }
        else
        {
            // Si la respuesta es incorrecta, sumar 0pts
            score -= 0;
        }

        UpdateScoreText(); //Actualizar texto del score

        // Si la score es 0, que cargue la escena otra vez, si no, que pase a la sig pregunta
        if (score <= 0)
        {
            GameOver();
        }
        else
        {
            NextQuestion();
        }
    }

    // Actualizar el texto de score del jugador
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

        // Lo mismo pero con los textos de los bots
        private void UpdateBotScoreTexts()
{
    if (_botscoreText1 != null)
    {
        _botscoreText1.text = $"{bots[0].Name}: {bots[0].Score}";
    }
    if (_botscoreText2 != null)
    {
        _botscoreText2.text = $"{bots[1].Name}: {bots[1].Score}";
    }
    if (_botscoreText3 != null)
    {
        _botscoreText3.text = $"{bots[2].Name}: {bots[2].Score}";
    }
    if (_botscoreText4 != null)
    {
        _botscoreText4.text = $"{bots[3].Name}: {bots[3].Score}";
    }
}

    //Hacer algo diferente si la score es superior o inferior a 70
    // Menor, carga la escena de fallo
    // Mayor, carga la escena de ir a votar
    public void EndQuiz()
    {
        if (score >= 70)
        {
            SceneManager.LoadScene(9); 
        }
        else
        {
            SceneManager.LoadScene(1); 
        }
    }

    // Desplegar los resultados y deshabilitar elementos de la UI 
    // que no sean necesarios
    private void EndQuizRes()
    {
        _quizUI.DisableUI();
        DisableUI();
        DisplayResults();
    }


    // Desplegar los resultados
    private void DisplayResults()
    {

        // Calculamos nivel de confianza promedio
        float averageConfidence = 0;
        if (confidenceLevels.Count > 0)
        {
            float totalConfidence = 0;
            foreach (var confidence in confidenceLevels)
            {
                totalConfidence += confidence;
            }
            averageConfidence = totalConfidence / confidenceLevels.Count;
        }
        // Mostrar en consola la puntuacion y niveles de confianza del jugador
        Debug.Log($"Player Score: {score}");
        Debug.Log($"Average Confidence Level: {averageConfidence}");

        List<Bot> sortedBots = new List<Bot>(bots);
        sortedBots.Sort((x, y) => y.Score.CompareTo(x.Score));

        for (int i = 0; i < sortedBots.Count; i++)
        {
            Debug.Log($"{sortedBots[i].Name}: {sortedBots[i].Score}");
        }

        resultsPanel.SetActive(true);
        resultsText.text = $"Puntuacion personal: {score}\nNivel de confianza promedio: {averageConfidence}\n\n";
        if (score >= 70)
    {
        resultsText.text += "\nEstado: <color=green>APROBADO</color>\n";
    }
    else
    {
        resultsText.text += "\nEstado: <color=red>REPROBADO</color>\n";
    }
        for (int i = 0; i < sortedBots.Count; i++)
        {
             resultsText.text += $"{sortedBots[i].Name}: {sortedBots[i].Score}\n";
        }

        _resultsBoton.onClick.RemoveAllListeners();
        _resultsBoton.onClick.AddListener(EndQuiz);
    }

    // Funcion de GameOver
    private void GameOver()
    {
        SceneManager.LoadScene(8);
    }

    // Deshabilitar UI
    private void DisableUI()
    {
        _botscoreText1.gameObject.SetActive(false);
        _botscoreText2.gameObject.SetActive(false);
        _botscoreText3.gameObject.SetActive(false);
        _botscoreText4.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        PanelBoton.gameObject.SetActive(true);
    }
}
