
-- Procedimiento para obtener el stock de todos los productos
CREATE PROCEDURE getStock
AS
BEGIN
    SELECT
        P.Nombre AS Producto,
        Stock.Cantidad - ISNULL(Ventas.Cantidad, 0) AS Cantidad,
        Stock.PrecioMedio AS PrecioMedio
    FROM
        [Almacen].[dbo].[Productos] AS P
        LEFT JOIN (
            SELECT
                ProductoId,
                SUM(Cantidad) AS Cantidad,
                AVG(Precio) AS PrecioMedio
            FROM
                [Almacen].[dbo].[Compras]
            GROUP BY
                ProductoId
        ) AS Stock ON P.Id = Stock.ProductoId
        LEFT JOIN (
            SELECT
                ProductoId,
                SUM(Cantidad) AS Cantidad
            FROM
                [Almacen].[dbo].[Ventas]
            GROUP BY
                ProductoId
        ) AS Ventas ON P.Id = Ventas.ProductoId
    WHERE
        (Stock.Cantidad - ISNULL(Ventas.Cantidad, 0)) > 0;
END;