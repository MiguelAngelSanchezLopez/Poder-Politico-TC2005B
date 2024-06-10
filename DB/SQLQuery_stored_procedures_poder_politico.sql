/*---Candidatos----*/
CREATE PROCEDURE insertCandidatosPresidenciales
@nombreCandidato VARCHAR(100),
@apellidoCandidato VARCHAR(100),
@edad int,
@motivo VARCHAR(100),
@propuesta VARCHAR(500)
AS
    INSERT INTO CandidatosPresidenciales VALUES (@nombreCandidato,@apellidoCandidato,@edad,@motivo,@propuesta)
GO



CREATE PROCEDURE deleteCandidatos
@idCandidato int
AS 
    DELETE FROM CandidatosPresidenciales WHERE idCandidato = @idCandidato
    
GO


CREATE PROCEDURE updateCandidatos
@idCandidato INT,
@nombreCandidato VARCHAR(100),
@apellidoCandidato VARCHAR(100),
@edad int,
@motivo VARCHAR(100),
@propuesta VARCHAR(500)
AS 
     UPDATE CandidatosPresidenciales SET nombreCandidato = @nombreCandidato WHERE idCandidato = @idCandidato
     UPDATE CandidatosPresidenciales SET apellidoCandidato = @apellidoCandidato WHERE idCandidato = @idCandidato
     UPDATE CandidatosPresidenciales SET edad = @Edad WHERE idCandidato = @idCandidato
     UPDATE CandidatosPresidenciales SET motivo = @motivo WHERE idCandidato = @idCandidato
     UPDATE CandidatosPresidenciales SET propuesta = @Propuesta WHERE idCandidato = @idCandidato
GO

CREATE PROCEDURE getallCandidatos
AS
    SELECT * FROM CandidatosPresidenciales
GO

/*EXEC insert_candidatos 1,'jorge','maynez',31,'cambiar mexico','4 ejes'
EXEC update_candidatos 2,'xochitl','galvez',65,'who','impuestos'
EXEC getall_candidatos
EXEC delete_candidatos 1
EXEC delete_candidatos 2
EXEC getall_candidatos*/

/*---Cuestionario----*/
CREATE PROCEDURE insertCuestionarios
@idUsuario int,
@idPregunta int
AS
    INSERT INTO Cuestionarios VALUES (@idUsuario,@idPregunta)
GO

CREATE PROCEDURE deleteCuestionarios
@idCuestionario int
AS 
    DELETE FROM Cuestionarios WHERE idCuestionario = @idCuestionario  
GO

CREATE PROCEDURE updateCuestionarios
@idCuestionario int,
@idUsuario int,
@idPregunta int
AS 
     UPDATE Cuestionarios SET idUsuario = @idUsuario WHERE idCuestionario = @idCuestionario
     UPDATE Cuestionarios SET idPregunta = @idPregunta WHERE idCuestionario = @idCuestionario
GO

CREATE PROCEDURE getallCuestionarios
AS
    SELECT * FROM Cuestionarios
GO
/*EXEC insert_cuestionario 1,1,1*/

/*---Eleccion_Candidato----*/
CREATE PROCEDURE insertEleccionCandidatos
@idUsuario int,
@idCandidato int
AS
    INSERT INTO EleccionCandidatos VALUES (@idUsuario,@idCandidato)
GO

CREATE PROCEDURE deleteEleccionCandidatos
@idEleccion_Candidato int
AS 
    DELETE FROM EleccionCandidatos WHERE idEleccionCandidato = @idEleccion_Candidato 
GO

CREATE PROCEDURE updateEleccionCandidatos
@idEleccionCandidato int,
@idUsuario int,
@idCandidato int
AS 
     UPDATE EleccionCandidatos SET idUsuario = @idUsuario WHERE idEleccionCandidato = @idEleccionCandidato
     UPDATE EleccionCandidatos SET idCandidato = @idCandidato WHERE idEleccionCandidato = @idEleccionCandidato
GO

CREATE PROCEDURE getallEleccionCandidatos
AS
    SELECT * FROM EleccionCandidatos
GO

/*---Iniciar_Sesion----*/
CREATE PROCEDURE insertIniciarSesion
@idUsuario int,
@Fecha date
AS
    INSERT INTO IniciarSesion VALUES (@idUsuario,@Fecha)
GO

CREATE PROCEDURE deleteIniciarSesion
@idIniciarSesion int
AS 
    DELETE FROM IniciarSesion WHERE idIniciarSesion = @idIniciarSesion 
GO

CREATE PROCEDURE updateIniciarSesion
@idIniciarSesion int,
@idUsuario int,
@fecha date
AS 
     UPDATE IniciarSesion SET idUsuario = @idUsuario WHERE idIniciarSesion = @idIniciarSesion
     UPDATE IniciarSesion SET fecha = @fecha WHERE idIniciarSesion = @idIniciarSesion
GO

CREATE PROCEDURE getallIniciarSesion
AS
    SELECT * FROM IniciarSesion
GO


/*---Pregunta----*/
CREATE PROCEDURE insertPreguntas
@descripcion VARCHAR(500)
AS
    INSERT INTO Preguntas VALUES (@descripcion)
GO

CREATE PROCEDURE deletePreguntas
@idPregunta int
AS 
    DELETE FROM Preguntas WHERE idPregunta = @idPregunta 
GO

CREATE PROCEDURE updatePreguntas
@idPregunta int,
@descripcion VARCHAR(500)
AS 
     UPDATE Preguntas SET descripcion = @descripcion WHERE idPregunta = @idPregunta
GO

CREATE PROCEDURE getallPreguntas
AS
    SELECT * FROM Preguntas
GO


/*---Registro_Encuesta----*/
CREATE PROCEDURE insertRegistroEncuestas
@idUsuario int,
@idCuestionario int,
@respuestas VARCHAR(500)
AS
    INSERT INTO RegistroEncuestas VALUES (@idUsuario,@idCuestionario,@respuestas)
GO
/*DROP PROCEDURE insertRegistroEncuestas*/
CREATE PROCEDURE deleteRegistroEncuestas
@idRegistroEncuesta int
AS 
    DELETE FROM RegistroEncuestas WHERE idRegistroEncuesta = @idRegistroEncuesta
GO

CREATE PROCEDURE updateRegistroEncuestas
@idRegistroEncuesta int,
@idUsuario int,
@idCuestionario int,
@respuestas VARCHAR(500)
AS 
     UPDATE RegistroEncuestas SET idUsuario = @idUsuario WHERE idRegistroEncuesta = @idRegistroEncuesta
     UPDATE RegistroEncuestas SET idCuestionario = @idCuestionario WHERE idRegistroEncuesta = @idRegistroEncuesta
     UPDATE RegistroEncuestas SET respuestas = @respuestas WHERE idRegistroEncuesta = @idRegistroEncuesta
GO

CREATE PROCEDURE getallRegistroEncuestas
AS
    SELECT * FROM RegistroEncuestas
GO


/*---Resultado----*/
CREATE PROCEDURE insertResultados
@idIniciar_Sesion int,
@idUsuario int,
@idEleccion_Candidato int,
@idRegistro_encuesta int
AS
    INSERT INTO Resultados VALUES (@idIniciar_Sesion,@idUsuario,@idEleccion_Candidato,@idRegistro_encuesta)
GO

CREATE PROCEDURE deleteResultados
@idResultado int
AS 
    DELETE FROM Resultados WHERE idResultado = @idResultado 
GO

CREATE PROCEDURE updateResultados
@idResultado int,
@idIniciarSesion int,
@idUsuario int,
@idEleccionCandidato int,
@idRegistroEncuesta int
AS 
     UPDATE Resultados SET idIniciarSesion = @idIniciarSesion WHERE idResultado = @idResultado
     UPDATE Resultados SET idUsuario = @idUsuario WHERE idResultado = @idResultado
     UPDATE Resultados SET idEleccionCandidato = @idEleccionCandidato WHERE idResultado = @idResultado
     UPDATE Resultados SET idRegistroencuesta = @idRegistroEncuesta WHERE idResultado = @idResultado
GO

CREATE PROCEDURE getallResultados
AS
    SELECT * FROM Resultados
GO


/*---Usuario----*/
CREATE PROCEDURE insertUsuarios
@nombre VARCHAR(100),
@contrasenia VARCHAR(100),
@correo VARCHAR(100)
AS
    INSERT INTO Usuarios VALUES (@nombre,@contrasenia,@correo)
GO

CREATE PROCEDURE deleteUsuarios
@idUsuario int
AS 
    DELETE FROM Usuarios WHERE @idUsuario = @idUsuario 
GO

CREATE PROCEDURE updateUsuarios
@idUsuario int,
@nombre VARCHAR(100),
@contrasenia VARCHAR(100),
@correo VARCHAR(100)
AS 
     UPDATE Usuarios SET nombre = @nombre WHERE idUsuario = @idUsuario
     UPDATE Usuarios SET contrasenia = @contrasenia WHERE idUsuario = @idUsuario
     UPDATE Usuarios SET correo = @correo WHERE idUsuario = @idUsuario
GO

CREATE PROCEDURE getallUsuarios
AS
    SELECT * FROM Usuarios
GO