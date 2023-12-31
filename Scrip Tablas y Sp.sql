USE [master]
GO
/****** Object:  Database [CrudPaises]    Script Date: 9/10/2023 10:42:21 a. m. ******/
CREATE DATABASE [CrudPaises]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CrudPaises', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\CrudPaises.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CrudPaises_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\CrudPaises_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CrudPaises] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CrudPaises].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CrudPaises] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CrudPaises] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CrudPaises] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CrudPaises] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CrudPaises] SET ARITHABORT OFF 
GO
ALTER DATABASE [CrudPaises] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CrudPaises] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CrudPaises] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CrudPaises] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CrudPaises] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CrudPaises] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CrudPaises] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CrudPaises] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CrudPaises] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CrudPaises] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CrudPaises] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CrudPaises] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CrudPaises] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CrudPaises] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CrudPaises] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CrudPaises] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CrudPaises] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CrudPaises] SET RECOVERY FULL 
GO
ALTER DATABASE [CrudPaises] SET  MULTI_USER 
GO
ALTER DATABASE [CrudPaises] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CrudPaises] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CrudPaises] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CrudPaises] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CrudPaises] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CrudPaises] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CrudPaises', N'ON'
GO
ALTER DATABASE [CrudPaises] SET QUERY_STORE = ON
GO
ALTER DATABASE [CrudPaises] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CrudPaises]
GO
/****** Object:  Table [dbo].[Ciudades]    Script Date: 9/10/2023 10:42:22 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudades](
	[Id_Ciudad] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](20) NULL,
	[Id_Pais] [int] NULL,
 CONSTRAINT [PK_Ciudades] PRIMARY KEY CLUSTERED 
(
	[Id_Ciudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Giros]    Script Date: 9/10/2023 10:42:22 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Giros](
	[Id_Giro] [int] IDENTITY(1,1) NOT NULL,
	[Giro_Recibido] [varchar](30) NULL,
	[Id_Ciudad] [int] NULL,
 CONSTRAINT [PK_Giros] PRIMARY KEY CLUSTERED 
(
	[Id_Giro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paises]    Script Date: 9/10/2023 10:42:22 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paises](
	[Id_Pais] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](20) NULL,
 CONSTRAINT [PK_Paises] PRIMARY KEY CLUSTERED 
(
	[Id_Pais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Ciudades] ON 

INSERT [dbo].[Ciudades] ([Id_Ciudad], [Nombre], [Id_Pais]) VALUES (1, N'Barranquilla', 1)
INSERT [dbo].[Ciudades] ([Id_Ciudad], [Nombre], [Id_Pais]) VALUES (2, N'Cartagena', 1)
INSERT [dbo].[Ciudades] ([Id_Ciudad], [Nombre], [Id_Pais]) VALUES (3, N'Medellin', 1)
INSERT [dbo].[Ciudades] ([Id_Ciudad], [Nombre], [Id_Pais]) VALUES (4, N'Santa Marta', 1)
INSERT [dbo].[Ciudades] ([Id_Ciudad], [Nombre], [Id_Pais]) VALUES (5, N'Manizales', 1)
INSERT [dbo].[Ciudades] ([Id_Ciudad], [Nombre], [Id_Pais]) VALUES (6, N'Armenia', 1)
INSERT [dbo].[Ciudades] ([Id_Ciudad], [Nombre], [Id_Pais]) VALUES (7, N'Paris', 2)
INSERT [dbo].[Ciudades] ([Id_Ciudad], [Nombre], [Id_Pais]) VALUES (8, N'Moustle', 2)
INSERT [dbo].[Ciudades] ([Id_Ciudad], [Nombre], [Id_Pais]) VALUES (9, N'Georgia', 3)
INSERT [dbo].[Ciudades] ([Id_Ciudad], [Nombre], [Id_Pais]) VALUES (10, N'San Francisco', 3)
INSERT [dbo].[Ciudades] ([Id_Ciudad], [Nombre], [Id_Pais]) VALUES (11, N'Ilinois', 3)
INSERT [dbo].[Ciudades] ([Id_Ciudad], [Nombre], [Id_Pais]) VALUES (12, N'Calabria', 5)
INSERT [dbo].[Ciudades] ([Id_Ciudad], [Nombre], [Id_Pais]) VALUES (13, N'Milan', 5)
INSERT [dbo].[Ciudades] ([Id_Ciudad], [Nombre], [Id_Pais]) VALUES (14, N'Toscana', 5)
INSERT [dbo].[Ciudades] ([Id_Ciudad], [Nombre], [Id_Pais]) VALUES (15, N'Ciudad del cabo', 9)
INSERT [dbo].[Ciudades] ([Id_Ciudad], [Nombre], [Id_Pais]) VALUES (16, N'Cartago', 1)
SET IDENTITY_INSERT [dbo].[Ciudades] OFF
GO
SET IDENTITY_INSERT [dbo].[Giros] ON 

INSERT [dbo].[Giros] ([Id_Giro], [Giro_Recibido], [Id_Ciudad]) VALUES (1, N'200000', 3)
INSERT [dbo].[Giros] ([Id_Giro], [Giro_Recibido], [Id_Ciudad]) VALUES (2, N'Televisor', 5)
INSERT [dbo].[Giros] ([Id_Giro], [Giro_Recibido], [Id_Ciudad]) VALUES (3, N'Ropa deportiva', 7)
INSERT [dbo].[Giros] ([Id_Giro], [Giro_Recibido], [Id_Ciudad]) VALUES (4, N'Zapatillas', 4)
INSERT [dbo].[Giros] ([Id_Giro], [Giro_Recibido], [Id_Ciudad]) VALUES (5, N'Busos', 4)
INSERT [dbo].[Giros] ([Id_Giro], [Giro_Recibido], [Id_Ciudad]) VALUES (6, N'Computador', 10)
INSERT [dbo].[Giros] ([Id_Giro], [Giro_Recibido], [Id_Ciudad]) VALUES (7, N'Pantalla LCD', 6)
INSERT [dbo].[Giros] ([Id_Giro], [Giro_Recibido], [Id_Ciudad]) VALUES (8, N'300 Euros', 6)
SET IDENTITY_INSERT [dbo].[Giros] OFF
GO
SET IDENTITY_INSERT [dbo].[Paises] ON 

INSERT [dbo].[Paises] ([Id_Pais], [Nombre]) VALUES (1, N'Colombia')
INSERT [dbo].[Paises] ([Id_Pais], [Nombre]) VALUES (2, N'Francia')
INSERT [dbo].[Paises] ([Id_Pais], [Nombre]) VALUES (3, N'Estado Unidos')
INSERT [dbo].[Paises] ([Id_Pais], [Nombre]) VALUES (4, N'España')
INSERT [dbo].[Paises] ([Id_Pais], [Nombre]) VALUES (5, N'Italia')
INSERT [dbo].[Paises] ([Id_Pais], [Nombre]) VALUES (6, N'Argentina')
INSERT [dbo].[Paises] ([Id_Pais], [Nombre]) VALUES (7, N'Paraguay')
INSERT [dbo].[Paises] ([Id_Pais], [Nombre]) VALUES (8, N'Uruguay')
INSERT [dbo].[Paises] ([Id_Pais], [Nombre]) VALUES (9, N'Canada')
INSERT [dbo].[Paises] ([Id_Pais], [Nombre]) VALUES (11, N'Ciudad del cabo')
INSERT [dbo].[Paises] ([Id_Pais], [Nombre]) VALUES (12, N'IRLANDA')
SET IDENTITY_INSERT [dbo].[Paises] OFF
GO
ALTER TABLE [dbo].[Ciudades]  WITH CHECK ADD  CONSTRAINT [FK_Ciudades_Paises] FOREIGN KEY([Id_Pais])
REFERENCES [dbo].[Paises] ([Id_Pais])
GO
ALTER TABLE [dbo].[Ciudades] CHECK CONSTRAINT [FK_Ciudades_Paises]
GO
ALTER TABLE [dbo].[Giros]  WITH CHECK ADD  CONSTRAINT [FK_Giros_Ciudades] FOREIGN KEY([Id_Ciudad])
REFERENCES [dbo].[Ciudades] ([Id_Ciudad])
GO
ALTER TABLE [dbo].[Giros] CHECK CONSTRAINT [FK_Giros_Ciudades]
GO
/****** Object:  StoredProcedure [dbo].[spActualizar_Ciudad]    Script Date: 9/10/2023 10:42:23 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spActualizar_Ciudad](
@id_ciudad int,
@nombre varchar(20),
@id_pais int
)
AS
BEGIN
	UPDATE Ciudades SET Nombre = @nombre, Id_Pais = @id_pais
	WHERE Id_Ciudad = @id_ciudad
END
GO
/****** Object:  StoredProcedure [dbo].[spActualizar_Giro]    Script Date: 9/10/2023 10:42:23 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[spActualizar_Giro](
@id_giro int,
@giro varchar(20),
@id_ciudad int
)
AS
BEGIN
	update Giros set Giro_Recibido = @giro, Id_Ciudad = @id_ciudad
	where Id_Giro = @id_giro
END
GO
/****** Object:  StoredProcedure [dbo].[spAgregar_Ciudad]    Script Date: 9/10/2023 10:42:23 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spAgregar_Ciudad](
@ciudad varchar(20),
@id_pais int
)
AS
BEGIN
	insert into Ciudades values (@ciudad, @id_pais)
END
GO
/****** Object:  StoredProcedure [dbo].[spAgregar_Giro]    Script Date: 9/10/2023 10:42:23 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[spAgregar_Giro](
@giro varchar(20),
@id_ciudad int
)
AS
BEGIN
	insert into Giros values (@giro, @id_ciudad)
END
GO
/****** Object:  StoredProcedure [dbo].[spBuscar_Ciudad_Id]    Script Date: 9/10/2023 10:42:23 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spBuscar_Ciudad_Id](
@id_ciudad int
)
AS
BEGIN
	SELECT Ciudades.Id_Ciudad 'ID', Ciudades.Nombre 'NOMBRE', Ciudades.Id_Pais 'PAIS'
	FROM Ciudades INNER JOIN Paises
	ON Ciudades.Id_Ciudad = Paises.Id_Pais
	WHERE Id_Ciudad = @id_ciudad
END
GO
/****** Object:  StoredProcedure [dbo].[spBuscar_Giro_Id]    Script Date: 9/10/2023 10:42:23 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[spBuscar_Giro_Id](
@id_giro int
)
AS
BEGIN
	SELECT Giros.Id_Giro 'ID', Giros.Giro_Recibido 'DESCRIPCION', Giros.Id_Ciudad 'CIUDAD'
	FROM Giros INNER JOIN Ciudades
	ON Giros.Id_Ciudad = Ciudades.Id_Ciudad
	WHERE Id_Giro = @id_giro
END
GO
/****** Object:  StoredProcedure [dbo].[spDrop_Ciudad]    Script Date: 9/10/2023 10:42:23 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spDrop_Ciudad](
@obtener varchar(20),
@i_pais int
)
AS
BEGIN
	if(@obtener = 'NOMBRE')
	select distinct ''[Id_Ciudad], Nombre from Ciudades
	order by Nombre asc

	else if(@obtener = 'PAIS')
	select distinct Id_Ciudad, ''[Nombre], Id_Pais from Ciudades
	where Id_Pais = @i_pais
	order by Nombre asc
	

END
GO
/****** Object:  StoredProcedure [dbo].[spDrop_Lista]    Script Date: 9/10/2023 10:42:23 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spDrop_Lista](
@obtener varchar(20)
)
AS
BEGIN
	if(@obtener = 'PAIS')
	select distinct ''[Id_Pais], Nombre from Paises
	order by Nombre asc

	

END
GO
/****** Object:  StoredProcedure [dbo].[spEliminar_Ciudad]    Script Date: 9/10/2023 10:42:23 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spEliminar_Ciudad](
@id_ciudad int
)
AS
BEGIN
	DELETE Ciudades WHERE Id_Ciudad = @id_ciudad
END
GO
/****** Object:  StoredProcedure [dbo].[spEliminar_Giro]    Script Date: 9/10/2023 10:42:23 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[spEliminar_Giro](
@id_giro int
)
AS
BEGIN
	DELETE Giros WHERE Id_Giro = @id_giro
END
GO
/****** Object:  StoredProcedure [dbo].[spListar_Ciudad]    Script Date: 9/10/2023 10:42:23 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spListar_Ciudad]
AS
BEGIN
	SELECT Ciudades.Id_Ciudad 'ID', Ciudades.Nombre 'NOMBRE', Paises.Nombre 'PAIS'
	FROM Ciudades INNER JOIN Paises
	ON Ciudades.Id_Pais = Paises.Id_Pais
END
GO
/****** Object:  StoredProcedure [dbo].[spListar_Giros]    Script Date: 9/10/2023 10:42:23 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[spListar_Giros]
AS
BEGIN
	SELECT Giros.Id_Giro 'ID', Giros.Giro_Recibido 'DESCRIPCION GIRO', Ciudades.Nombre 'CIUDAD'
	FROM Giros INNER JOIN Ciudades
	ON Giros.Id_Ciudad = Ciudades.Id_Ciudad
END
GO
/****** Object:  StoredProcedure [dbo].[spPais_Actualizar]    Script Date: 9/10/2023 10:42:23 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[spPais_Actualizar]
	@Id_Pais int,
	@Nombre varchar(20)
AS
BEGIN
	UPDATE Paises SET Nombre = @Nombre
	WHERE Id_Pais = @Id_Pais
END
GO
/****** Object:  StoredProcedure [dbo].[spPais_BuscarId]    Script Date: 9/10/2023 10:42:23 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spPais_BuscarId]
	@Id_Pais int
AS
BEGIN 
	SELECT Id_Pais 'ID', Nombre 'Nombre'
	FROM Paises
	WHERE Id_Pais = @Id_Pais
END
GO
/****** Object:  StoredProcedure [dbo].[spPais_Eliminar]    Script Date: 9/10/2023 10:42:23 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spPais_Eliminar]
	@Id_Pais int
AS
BEGIN
	DELETE Paises WHERE Id_Pais = @Id_Pais
END
GO
/****** Object:  StoredProcedure [dbo].[spPais_Listado]    Script Date: 9/10/2023 10:42:23 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spPais_Listado]
AS
BEGIN
	SELECT Id_Pais 'ID', Nombre 'Nombre pais'
	FROM Paises
END 
GO
/****** Object:  StoredProcedure [dbo].[spPaises_Crear]    Script Date: 9/10/2023 10:42:23 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spPaises_Crear]
	@Nombre varchar (20)
AS
BEGIN 
	INSERT INTO Paises VALUES(@Nombre)
END
GO
USE [master]
GO
ALTER DATABASE [CrudPaises] SET  READ_WRITE 
GO
