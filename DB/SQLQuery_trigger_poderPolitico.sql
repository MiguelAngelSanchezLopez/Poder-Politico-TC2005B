-- TRIGGER 
/*SELECT * FROM Usuarios
SELECT * FROM LogEliminados
DROP TRIGGER tr_insert_usuario
DROP TRIGGER trg_AfterDeleteUser
DELETE FROM Usuarios WHERE idUsuario = 5;
INSERT INTO Usuarios(nombre,contrasenia,correo) VALUES('mikesf','sofee@fmes.com','124334')
SELECT * FROM Usuarios*/

CREATE TRIGGER trg_AfterDeleteUser
ON Usuarios
AFTER DELETE
AS
BEGIN

    DECLARE @idUsuario INT;
    DECLARE @nombre VARCHAR(100);


    SELECT 
        @nombre = deleted.nombre
    FROM deleted;

   INSERT INTO LogEliminados (fecha, accion, usuario, comentarios) 
   VALUES (GETDATE(), 'Elimino cliente', (SELECT deleted.nombre FROM deleted), 'Se ha eliminado el usuario!')
END;
