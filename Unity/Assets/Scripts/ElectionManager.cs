using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using System.Net.Http; // Añadido ahora para HTTP requests
using System.Text; // Añadido para Encoding

public class ElectionManager : MonoBehaviour
{
   // private static readonly HttpClient client = new HttpClient();
    //private int idUsuario = 6; // Este debe ser el ID del usuario actual como prueba CAMBIABLEEEEEEEEEEEEEEEEEEEEEEE

    private int idCandidatoXochitl = 2; // Reemplaza con el ID real de Xóchitl Gálvez en tu tabla de candidatos
    private int idCandidatoMaynez = 1;  // Reemplaza con el ID real de Jorge Maynez
    private int idCandidatoClaudia = 3; // Reemplaza con el ID real de Claudia Sheinbaum
    public int score = 5;

    // Definimos un string de votaciones
    public static string voteMessage;

    //public string addScore = "http://10.22.3.238/unity/addscore.php?";
    public string linkAPI = "https://votingapi2024.azurewebsites.net";
    public Text _texto1;

    // Hacemos un string de resultados para cada candidato
    // Region solo ayuda a poder esconder o minimizar ciertas partes del txt}
    #region ResultadosCandidatos
    private string messageXochitl = "Xóchitl Gálvez\n" +
    "- Desmantelamiento de los 5 cárteles del narcotráfico más violentos que operan en el país.\n" +
    "- Acceso de todas las familias mexicanas a servicios de salud y medicinas de calidad, totalmente gratuitos.\n" +
    "- Disminución en un 50% de los feminicidios y cero impunidad para los agresores de mujeres.\n" +
    "- Cumplimiento integral de todos los derechos de los pueblos indígenas y afromexicanos.\n" +
    "- Reducción de la pobreza extrema en un 30% gracias al programa Tarjeta Mexicana para mujeres vulnerables.\n" +
    "- 200 mil mujeres más graduadas de carreras STEM (ciencia, tecnología, ingeniería y matemáticas) con la Beca Libertad.";
    private string messageMaynez = "Jorge Maynez \n" +
    "- Una disminución del 40% en la tasa de homicidios con su nuevo modelo de seguridad y justicia.\n" +
    "- Que el 50% de la energía del país provenga de fuentes limpias y renovables.\n" +
    "- Cobertura universal de educación inicial, atendiendo a todos los niños de 0 a 5 años.\n" +
    "- Un aumento de un millón de estudiantes universitarios, con equidad de género (50% mujeres).\n" +
    "- Implementación de un Sistema Nacional de Cuidados que libere a millones de mujeres de esta labor no remunerada.\n" +
    "- Aumento del 20% del salario promedio gracias a un programa de jornadas laborales dignas.";
    private string messageClaudia = "Claudia Sheinbaum\n" +
    "- Una reducción de la corrupción en un 50% y cero impunidades para funcionarios públicos corruptos.\n" +
    "- Cobertura universal de la pensión para adultos mayores de 65 años.\n" +
    "- Aumento acumulado del salario mínimo en un 25%.\n" +
    "- Reducción de la violencia contra las mujeres en un 30% gracias a reformas legales para la igualdad sustantiva de género.\n" +
    "- Expansión de la matrícula en universidades públicas en un 20%.\n" +
    "- Fortalecimiento del sistema de salud pública, con un incremento del 30% en su presupuesto.";
    #endregion

    void Start()
    {
        //client.BaseAddress = new System.Uri("https://votingapi2024.azurewebsites.net");
        //client.DefaultRequestHeaders.Accept.Clear();
        //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    }

    public void VotaXochitl()
    {
        voteMessage = messageXochitl;
        StartCoroutine(PostVote(idCandidatoXochitl));
        //await RegistrarVoto(idCandidatoXochitl); //Para base de datos
        CambiarEscena();
    }

    public void VotaMaynez()
    {
        voteMessage = messageMaynez;
        StartCoroutine(PostVote(idCandidatoMaynez));
        //await RegistrarVoto(idCandidatoMaynez); //Para base de datos
        CambiarEscena();
    }

    public void VotaClaudia()
    {
        voteMessage = messageClaudia;
        StartCoroutine(PostVote(idCandidatoClaudia));
        //await RegistrarVoto(idCandidatoClaudia); //Para base de datos
        CambiarEscena();
    }

    // Cambiamos escena a la 11
    // (Escena de Resultados)
    public void CambiarEscena()
    {
        SceneManager.LoadScene(11);
    }

    //Para base de datos
    //private async System.Threading.Tasks.Task RegistrarVoto(int idCandidato)
    //{
      //  var voto = new Voto { idUsuario = this.idUsuario, idCandidato = idCandidato };
       // var json = JsonUtility.ToJson(voto);
        //var content = new StringContent(json, Encoding.UTF8, "application/json");
        //HttpResponseMessage response = await client.PostAsync("/vote", content);
        //Debug.Log(response.ToString());

        //if (response.IsSuccessStatusCode)
        //{
         //   Debug.Log("Voto registrado para el candidato con ID " + idCandidato);
        //}
        //else
        //{
          //  string responseContent = await response.Content.ReadAsStringAsync();
            //Debug.LogWarning("Error al registrar el voto: " + response.ReasonPhrase);
        //}
    //}

    IEnumerator PostVote(int idCandidato)
    {
        int idUsuario = NameHandler.idUsuarioFinal;
        string post_url = $"{linkAPI}/vote?idUsuario={idUsuario}&idCandidato={idCandidato}";
        Debug.Log(post_url);
        // Post the URL to the site and create a download object to get the result.
        WWW hs_post = new WWW(post_url);
        yield return hs_post; // Wait until the download is done
        if (hs_post.error != null)
        {
        print("There was an error posting the high score: " + hs_post.error);
        }
    }       

    //[System.Serializable]
    //public class Voto
    //{
      //  public int idUsuario;
      //  public int idCandidato;
    //}
}

