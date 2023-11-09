create PROCEDURE GetAlumnoById
    @Id int
as
BEGIN
    SELECT *
    FROM Alumnos
    WHERE Id = @Id
END

EXECUTE GetAlumnoById 2;