USE [Concesionario]
GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 09/02/2024 18:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nom_Marca] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Marcas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Series]    Script Date: 09/02/2024 18:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Series](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomSerie] [nvarchar](max) NOT NULL,
	[MarcaId] [int] NOT NULL,
 CONSTRAINT [PK_Series] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehiculos]    Script Date: 09/02/2024 18:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehiculos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Matricula] [nvarchar](max) NOT NULL,
	[Color] [nvarchar](max) NOT NULL,
	[SerieId] [int] NOT NULL,
	[SucursalId] [int] NOT NULL,
 CONSTRAINT [PK_Vehiculos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[VistaTotal]    Script Date: 09/02/2024 18:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VistaTotal]
AS
SELECT        dbo.Vehiculos.Matricula, dbo.Vehiculos.Color, dbo.Marcas.Nom_Marca, dbo.Series.NomSerie
FROM            dbo.Marcas INNER JOIN
                         dbo.Series ON dbo.Marcas.Id = dbo.Series.MarcaId INNER JOIN
                         dbo.Vehiculos ON dbo.Series.Id = dbo.Vehiculos.SerieId
GO
/****** Object:  Table [dbo].[Sucursales]    Script Date: 09/02/2024 18:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Direccion] [nvarchar](max) NOT NULL,
	[Ciudad] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Sucursales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Marcas] ON 

INSERT [dbo].[Marcas] ([Id], [Nom_Marca]) VALUES (1, N'Seat')
INSERT [dbo].[Marcas] ([Id], [Nom_Marca]) VALUES (2, N'Citroën')
INSERT [dbo].[Marcas] ([Id], [Nom_Marca]) VALUES (3, N'Volkswagen')
INSERT [dbo].[Marcas] ([Id], [Nom_Marca]) VALUES (4, N'Ferrari')
INSERT [dbo].[Marcas] ([Id], [Nom_Marca]) VALUES (5, N'Ford')
SET IDENTITY_INSERT [dbo].[Marcas] OFF
GO
SET IDENTITY_INSERT [dbo].[Series] ON 

INSERT [dbo].[Series] ([Id], [NomSerie], [MarcaId]) VALUES (1, N'Málaga', 1)
INSERT [dbo].[Series] ([Id], [NomSerie], [MarcaId]) VALUES (2, N'León', 1)
INSERT [dbo].[Series] ([Id], [NomSerie], [MarcaId]) VALUES (3, N'Toledo', 1)
INSERT [dbo].[Series] ([Id], [NomSerie], [MarcaId]) VALUES (4, N'c3', 2)
INSERT [dbo].[Series] ([Id], [NomSerie], [MarcaId]) VALUES (5, N'Saxo', 2)
INSERT [dbo].[Series] ([Id], [NomSerie], [MarcaId]) VALUES (6, N'Golf', 3)
INSERT [dbo].[Series] ([Id], [NomSerie], [MarcaId]) VALUES (7, N'Jetta', 3)
INSERT [dbo].[Series] ([Id], [NomSerie], [MarcaId]) VALUES (8, N'F-150', 4)
INSERT [dbo].[Series] ([Id], [NomSerie], [MarcaId]) VALUES (9, N'LaFerrari', 4)
INSERT [dbo].[Series] ([Id], [NomSerie], [MarcaId]) VALUES (10, N'Focus', 5)
SET IDENTITY_INSERT [dbo].[Series] OFF
GO
SET IDENTITY_INSERT [dbo].[Sucursales] ON 

INSERT [dbo].[Sucursales] ([Id], [Nombre], [Direccion], [Ciudad]) VALUES (1, N'Flexicar', N'Crtra Logroño', N'Zaragoza')
INSERT [dbo].[Sucursales] ([Id], [Nombre], [Direccion], [Ciudad]) VALUES (2, N'CompramosTuCoche', N'las Fuentes', N'Zaragoza')
INSERT [dbo].[Sucursales] ([Id], [Nombre], [Direccion], [Ciudad]) VALUES (3, N'HR Motor', N'Alcobendas', N'Madrid')
SET IDENTITY_INSERT [dbo].[Sucursales] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehiculos] ON 

INSERT [dbo].[Vehiculos] ([Id], [Matricula], [Color], [SerieId], [SucursalId]) VALUES (1, N'TE-5498-D', N'Verde', 1, 1)
INSERT [dbo].[Vehiculos] ([Id], [Matricula], [Color], [SerieId], [SucursalId]) VALUES (2, N'9862 DGC', N'Negro', 2, 2)
INSERT [dbo].[Vehiculos] ([Id], [Matricula], [Color], [SerieId], [SucursalId]) VALUES (3, N'4414 FCZ', N'Verde', 7, 3)
INSERT [dbo].[Vehiculos] ([Id], [Matricula], [Color], [SerieId], [SucursalId]) VALUES (4, N'0030 LHY', N'Blanco', 6, 1)
INSERT [dbo].[Vehiculos] ([Id], [Matricula], [Color], [SerieId], [SucursalId]) VALUES (5, N'7785 JMS', N'Blanco', 10, 1)
SET IDENTITY_INSERT [dbo].[Vehiculos] OFF
GO
ALTER TABLE [dbo].[Series]  WITH CHECK ADD  CONSTRAINT [FK_Series_Marcas_MarcaId] FOREIGN KEY([MarcaId])
REFERENCES [dbo].[Marcas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Series] CHECK CONSTRAINT [FK_Series_Marcas_MarcaId]
GO
ALTER TABLE [dbo].[Vehiculos]  WITH CHECK ADD  CONSTRAINT [FK_Vehiculos_Series_SerieId] FOREIGN KEY([SerieId])
REFERENCES [dbo].[Series] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Vehiculos] CHECK CONSTRAINT [FK_Vehiculos_Series_SerieId]
GO
ALTER TABLE [dbo].[Vehiculos]  WITH CHECK ADD  CONSTRAINT [FK_Vehiculos_Sucursales_SucursalId] FOREIGN KEY([SucursalId])
REFERENCES [dbo].[Sucursales] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Vehiculos] CHECK CONSTRAINT [FK_Vehiculos_Sucursales_SucursalId]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Marcas"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Series"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 119
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Vehiculos"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 136
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaTotal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaTotal'
GO
