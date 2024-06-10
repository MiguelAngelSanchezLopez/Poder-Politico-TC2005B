public class Bot

// Clase "Bot" para los bots del examen
// Autor: Pedro Sotelo Arce 
// Last Modified: 28/05/2024

{
    // Getters y Setters del nombre y puntuacion
    public string Name { get; set; }
    public int Score { get; set; }

    // Las caracteristicas que tiene un objeto con esta clase
    public Bot(string name)
    {
        Name = name;
        Score = 0;
    }

    // Funcion para que los bots contesten preguntas
    // Se escoge un numero random, si ese numero es 1 o 2
    // Se aumenta el score por 10
    public void AnswerQuestion()
    {
        int randomValue = UnityEngine.Random.Range(1, 5); 
        if (randomValue == 1 || randomValue == 2)
        {
            Score += 10;
        }
    }
}