/*DBCC CHECKIDENT('Table',RESEED,1) para reset sequences,primero drop sequences*/
/*Secuencia Candidato */
CREATE SEQUENCE candidato_idCandidato_seq
START WITH 2
INCREMENT BY 1;

ALTER TABLE Candidatos
ADD CONSTRAINT DF_Candidato_idCandidato DEFAULT NEXT VALUE FOR candidato_idCandidato_seq FOR id;

/*Secuencia Eleccion_Candidato */
CREATE SEQUENCE eleccion_Candidato_idEleccion_Candidato_seq
START WITH 1
INCREMENT BY 1;

ALTER TABLE Eleccion_Candidato
ADD CONSTRAINT DF_eleccion_Candidato_idEleccion_Candidato DEFAULT NEXT VALUE FOR eleccion_Candidato_idEleccion_Candidato_seq FOR idEleccion_Candidato;

/*Crear la secuencia Usuario*/
CREATE SEQUENCE usuario_usuarioid_seq
START WITH 2
INCREMENT BY 1;

-- Agregar una columna que use la secuencia en la tabla Usuario
-- Supongamos que la tabla Usuario ya existe y queremos agregar una columna con valores generados por la secuenci

-- O si la columna ya existe y queremos establecer el valor por defecto
ALTER TABLE Usuario
ADD CONSTRAINT DF_Usuario_idUsuario DEFAULT NEXT VALUE FOR usuario_usuarioid_seq FOR idUsuario;

ALTER TABLE Usuario
DROP CONSTRAINT DF_Usuario_idUsuario;

--Sequences viejas--
/*
--Secuencia Cuestionario-- 
CREATE SEQUENCE cuestionario_idCuestionario_seq
START WITH 1
INCREMENT BY 1;

ALTER TABLE Cuestionario
ADD CONSTRAINT DF_Cuestionario_idCuestionario DEFAULT NEXT VALUE FOR cuestionario_idCuestionario_seq FOR idCuestionario;

--Secuencia Iniciar_Sesion-- 
CREATE SEQUENCE iniciar_Sesion_idIniciar_Sesion_seq
START WITH 1
INCREMENT BY 1;

ALTER TABLE Iniciar_Sesion
ADD CONSTRAINT DF_iniciar_Sesion_idIniciar_Sesion DEFAULT NEXT VALUE FOR iniciar_Sesion_idIniciar_Sesion_seq FOR idIniciar_Sesion;

--Secuencia Pregunta--
CREATE SEQUENCE pregunta_idPregunta_seq
START WITH 1
INCREMENT BY 1;

ALTER TABLE Pregunta
ADD CONSTRAINT DF_pregunta_idPregunta DEFAULT NEXT VALUE FOR pregunta_idPregunta_seq FOR idPregunta;

--Secuencia Registro_encuesta--
CREATE SEQUENCE registro_encuesta_idRegistro_encuesta_seq
START WITH 1
INCREMENT BY 1;

ALTER TABLE Registro_encuesta
ADD CONSTRAINT DF_registro_encuesta_idRegistro_encuesta DEFAULT NEXT VALUE FOR registro_encuesta_idRegistro_encuesta_seq FOR idRegistro_encuesta;

--Secuencia Resultado --
CREATE SEQUENCE resultado_idResultado_seq
START WITH 1
INCREMENT BY 1;

ALTER TABLE Resultado
ADD CONSTRAINT DF_resultado_idResultado DEFAULT NEXT VALUE FOR resultado_idResultado_seq FOR idResultado;
*/