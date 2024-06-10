-- Check if the table exists
IF OBJECT_ID('dbo.Usuarios', 'U') IS NOT NULL
BEGIN
    -- Option 1: Drop the existing table
    -- DROP TABLE dbo.Usuarios;
    
    -- Option 2: Rename the existing table
    EXEC sp_rename 'dbo.Usuarios', 'Usuarios_Old';
END

CREATE TABLE Usuarios (
    idUsuario  INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100),
    correo VARCHAR(100),
    contrasenia VARCHAR(100),
)
GO

-- Check if the table exists
IF OBJECT_ID('dbo.CandidatosPresidenciales', 'U') IS NOT NULL
BEGIN
    -- Option 1: Drop the existing table
    -- DROP TABLE dbo.Usuarios;
    
    -- Option 2: Rename the existing table
    EXEC sp_rename 'dbo.CandidatosPresidenciales', 'CandidatosPresidenciales_Old';
END
CREATE TABLE CandidatosPresidenciales (
    idCandidato INT IDENTITY(1,1) PRIMARY KEY,
    nombreCandidato VARCHAR(100),
    apellidoCandidato VARCHAR(100),
    edad INT
)
GO

-- Check if the table exists
IF OBJECT_ID('dbo.EleccionCandidatos', 'U') IS NOT NULL
BEGIN
    -- Option 1: Drop the existing table
    -- DROP TABLE dbo.Usuarios;
    
    -- Option 2: Rename the existing table
    EXEC sp_rename 'dbo.EleccionCandidatos', 'EleccionCandidatos_Old';
END

CREATE TABLE EleccionCandidatos (
    idEleccionCandidato INT IDENTITY(1,1) PRIMARY KEY,
    idUsuario INT,
    idCandidato INT
)
GO
ALTER TABLE EleccionCandidatos ADD CONSTRAINT FK_EC1 FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario) ON DELETE CASCADE
ALTER TABLE EleccionCandidatos ADD CONSTRAINT FK_EC2 FOREIGN KEY (idCandidato) REFERENCES CandidatosPresidenciales(idCandidato) ON DELETE CASCADE
GO

-- Check if the table exists
IF OBJECT_ID('dbo.LogEliminados', 'U') IS NOT NULL
BEGIN
    -- Option 1: Drop the existing table
    -- DROP TABLE dbo.Usuarios;
    
    -- Option 2: Rename the existing table
    EXEC sp_rename 'dbo.LogEliminados', 'LogEliminados_Old';
END

CREATE TABLE LogEliminados (
    codigo int IDENTITY (1,1) PRIMARY KEY,
    fecha smalldatetime, 
    accion VARCHAR(100), 
    usuario VARCHAR(100) , 
    comentarios VARCHAR(100)
)
GO

--Tablas viejas--
/*CREATE TABLE Preguntas (
    idPregunta INT IDENTITY(1,1) PRIMARY KEY,
    descripcion VARCHAR(500)
)
GO*/

/*CREATE TABLE IniciarSesion (
    idIniciarSesion INT IDENTITY(1,1) PRIMARY KEY,
    idUsuario INT,
    fecha DATE
)
GO
ALTER TABLE IniciarSesion ADD CONSTRAINT FK_1 FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario) ON DELETE CASCADE
GO*/
/*
CREATE TABLE Cuestionarios (
    idCuestionario INT IDENTITY(1,1) PRIMARY KEY,
    idUsuario INT,
    idPregunta INT,
    /*FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario),
    FOREIGN KEY (idPregunta) REFERENCES Preguntas(idPregunta)*/
)
GO
ALTER TABLE Cuestionarios ADD CONSTRAINT FK_4 FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario) ON DELETE CASCADE
ALTER TABLE Cuestionarios ADD CONSTRAINT FK_5 FOREIGN KEY (idPregunta) REFERENCES Preguntas(idPregunta) ON DELETE CASCADE
GO*/

/*CREATE TABLE Resultados (
    idResultado INT IDENTITY(1,1) PRIMARY KEY,
    idIniciarSesion INT,
    idUsuario INT,
    idEleccionCandidato INT,
    idRegistroEncuesta INT,
    /*FOREIGN KEY (idIniciarSesion) REFERENCES IniciarSesion(idIniciarSesion),
    FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario),
    FOREIGN KEY (idEleccionCandidato) REFERENCES EleccionCandidatos(idEleccionCandidato),
    FOREIGN KEY (idRegistroEncuesta) REFERENCES RegistroEncuestas(idRegistroEncuesta)*/
)
GO
ALTER TABLE Resultados ADD CONSTRAINT FK_6 FOREIGN KEY (idIniciarSesion) REFERENCES IniciarSesion(idIniciarSesion) ON DELETE CASCADE
ALTER TABLE Resultados ADD CONSTRAINT FK_7 FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario) ON DELETE CASCADE
ALTER TABLE Resultados ADD CONSTRAINT FK_8 FOREIGN KEY (idEleccionCandidato) REFERENCES EleccionCandidatos(idEleccionCandidato) ON DELETE CASCADE
ALTER TABLE Resultados ADD CONSTRAINT FK_9 FOREIGN KEY (idRegistroEncuesta) REFERENCES RegistroEncuestas(idRegistroEncuesta) ON DELETE CASCADE
GO*/

/*CREATE TABLE RegistroEncuestas (
    idRegistroEncuesta INT IDENTITY(1,1) PRIMARY KEY,
    idUsuario INT,
    idCuestionario INT,
    respuestas VARCHAR(500),
    /*FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario),
    FOREIGN KEY (idCuestionario) REFERENCES Cuestionario(idCuestionario)*/
)
GO
ALTER TABLE RegistroEncuestas ADD CONSTRAINT FK_10 FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario) ON DELETE CASCADE
ALTER TABLE RegistroEncuestas ADD CONSTRAINT FK_11 FOREIGN KEY (idCuestionario) REFERENCES Cuestionarios(idCuestionario) ON DELETE CASCADE
GO*/