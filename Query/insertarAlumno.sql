create PROCEDURE insertarAlumno
    @Name NVARCHAR(50),
    @Email NVARCHAR(50),
    @Foto NVARCHAR(50),
    @curso int
AS
BEGIN
    INSERT INTO Alumnos
        (Nombre, Email, Foto, CursoID)
    VALUES
        (@Name, @Email, @Foto, @curso)
END
