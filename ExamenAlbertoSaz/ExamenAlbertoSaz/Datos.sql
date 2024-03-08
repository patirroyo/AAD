-- Insertar datos en la tabla Clientes
INSERT INTO [Almacen].[dbo].[Clientes] ([Nombre], [NIF])
VALUES
('Eddy Merckx', '12345678A'),
('Fausto Coppi', '98765432B'),
('Miguel Indurain', '55555555C');

-- Insertar datos en la tabla Proveedores
INSERT INTO [Almacen].[dbo].[Proveedores] ([Nombre], [NIF])
VALUES
('Shimano', '11111111X'),
('Campagnolo', '99999999Y'),
('SRAM', '77777777Z');

-- Insertar datos en la tabla Productos
INSERT INTO [Almacen].[dbo].[Productos] ([Nombre], [Precio])
VALUES
-- Crearla a mano para empezar ('Bicicleta de Carretera', 3000),
('Casco de Ciclismo', 100),
('Zapatillas de Ciclismo', 120);

-- Insertar datos en la tabla Compras
INSERT INTO [Almacen].[dbo].[Compras] ([ProductoId], [ProveedorId], [Cantidad], [Precio], [Fecha])
VALUES
-- Compras del Producto 1 con diferentes proveedores
(1, 1, 50, 1500, '2024-03-08'),
(1, 2, 30, 1800, '2024-03-09'),
(1, 3, 20, 1600, '2024-03-10'),
(1, 1, 25, 1700, '2024-03-11'),
(1, 2, 10, 1550, '2024-03-12'),

-- Compras del Producto 2 con diferentes proveedores
(2, 2, 100, 100, '2024-03-08'),
(2, 1, 50, 80, '2024-03-09'),
(2, 3, 30, 90, '2024-03-10'),
(2, 2, 40, 85, '2024-03-11'),
(2, 1, 20, 95, '2024-03-12'),

-- Compras del Producto 3 con diferentes proveedores
(3, 3, 75, 120, '2024-03-08'),
(3, 1, 25, 110, '2024-03-09'),
(3, 3, 15, 130, '2024-03-10'),
(3, 2, 20, 125, '2024-03-11'),
(3, 3, 10, 140, '2024-03-12');

-- Insertar datos en la tabla Ventas con productos variados y uno sin stock
INSERT INTO [Almacen].[dbo].[Ventas] ([ClienteId], [ProductoId], [Cantidad], [Precio], [Fecha])
VALUES
-- Ventas del Producto 1
(1, 1, 20, 2000, '2024-03-13'),
(2, 1, 15, 2100, '2024-03-13'),
(3, 1, 10, 2200, '2024-03-13'),

-- Ventas del Producto 2
(1, 2, 30, 300, '2024-03-13'),
(2, 2, 25, 320, '2024-03-13'),
(3, 2, 20, 350, '2024-03-13'),

-- Ventas del Producto 3 (se quedará sin stock)
(1, 3, 75, 450, '2024-03-13'),
(2, 3, 25, 430, '2024-03-13'),
(3, 3, 15, 410, '2024-03-13'),
(1, 3, 20, 390, '2024-03-13'),
(2, 3, 10, 370, '2024-03-13');