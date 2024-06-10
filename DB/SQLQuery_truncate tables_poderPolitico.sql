
TRUNCATE TABLE Usuarios/*listo*/
TRUNCATE TABLE CandidatosPresidenciales/*listo*/
TRUNCATE TABLE EleccionCandidatos/*listo*/
TRUNCATE TABLE Cuestionarios/*listo*/
TRUNCATE TABLE IniciarSesion/*listo*/
TRUNCATE TABLE LogEliminados/*listo*/
TRUNCATE TABLE Preguntas/*listo*/
TRUNCATE TABLE RegistroEncuestas/*listo*/
TRUNCATE TABLE Resultados/*listo*/

--Revisar que esten vacías--
EXEC getallCandidatos
EXEC getallEleccionCandidatos
EXEC getallUsuarios
EXEC getallCuestionarios
EXEC getallIniciarSesion
EXEC getallPreguntas
EXEC getallRegistroEncuestas
EXEC getallResultados

