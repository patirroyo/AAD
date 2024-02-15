/*Vamos a crear procedimientos almacenados*/
/*
CREATE PROCEDURE getSeriesVehiculos
AS
BEGIN
	SELECT dbo.Vehiculos.Matricula, dbo.Vehiculos.Color, dbo.Marcas.Nom_Marca, dbo.Series.NomSerie
	FROM dbo.Marcas 
		INNER JOIN dbo.Series ON dbo.Marcas.Id = dbo.Series.MarcaId 
		INNER JOIN dbo.Vehiculos ON dbo.Series.Id = dbo.Vehiculos.SerieId
END
*/
/*************************************************************/

CREATE PROCEDURE getVehiculosPorColor
@ColorSel nvarchar(30)
AS
BEGIN
    SELECT dbo.Vehiculos.Matricula, dbo.Vehiculos.Color, dbo.Marcas.Nom_Marca, dbo.Series.NomSerie
    FROM dbo.Marcas 
        INNER JOIN dbo.Series ON dbo.Marcas.Id = dbo.Series.MarcaId 
        INNER JOIN dbo.Vehiculos ON dbo.Series.Id = dbo.Vehiculos.SerieId
    WHERE dbo.Vehiculos.Color LIKE (@ColorSel)
END