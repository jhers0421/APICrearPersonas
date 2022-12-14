USE [master]
GO
/****** Object:  Database [PRUEBA]    Script Date: 12/09/2022 1:06:30 ******/
CREATE DATABASE [PRUEBA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PRUEBA', FILENAME = N'C:\Expertos\Prueba\DataSQL\PRUEBA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PRUEBA_log', FILENAME = N'C:\Expertos\Prueba\DataSQL\PRUEBA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PRUEBA] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PRUEBA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PRUEBA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PRUEBA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PRUEBA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PRUEBA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PRUEBA] SET ARITHABORT OFF 
GO
ALTER DATABASE [PRUEBA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PRUEBA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PRUEBA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PRUEBA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PRUEBA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PRUEBA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PRUEBA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PRUEBA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PRUEBA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PRUEBA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PRUEBA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PRUEBA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PRUEBA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PRUEBA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PRUEBA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PRUEBA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PRUEBA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PRUEBA] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PRUEBA] SET  MULTI_USER 
GO
ALTER DATABASE [PRUEBA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PRUEBA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PRUEBA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PRUEBA] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PRUEBA] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PRUEBA] SET QUERY_STORE = OFF
GO
USE [PRUEBA]
GO
/****** Object:  Table [dbo].[DataMaestra]    Script Date: 12/09/2022 1:06:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataMaestra](
	[nmdato] [varchar](150) NOT NULL,
	[nmaestro] [varchar](150) NULL,
	[cddato] [varchar](20) NULL,
	[dsdato] [varchar](100) NULL,
	[cddato1] [varchar](100) NULL,
	[cddato2] [varchar](100) NULL,
	[cddato3] [varchar](100) NULL,
	[feregistro] [datetime] NULL,
	[febaja] [datetime] NULL,
 CONSTRAINT [PK_DataMaestra] PRIMARY KEY CLUSTERED 
(
	[nmdato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Maestras]    Script Date: 12/09/2022 1:06:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maestras](
	[nmmaestro] [varchar](150) NOT NULL,
	[cdmaestro] [varchar](5) NULL,
	[dsmaestro] [varchar](100) NULL,
	[feregistro] [datetime] NULL,
	[febaja] [datetime] NULL,
 CONSTRAINT [PK_Maestras] PRIMARY KEY CLUSTERED 
(
	[nmmaestro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pacientes]    Script Date: 12/09/2022 1:06:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacientes](
	[nmind] [int] IDENTITY(1,1) NOT NULL,
	[nmind_persona] [int] NULL,
	[nimd_medicotra] [int] NULL,
	[dseps] [varchar](50) NULL,
	[dsarl] [varchar](50) NULL,
	[feregistro] [datetime] NULL,
	[febaja] [datetime] NULL,
	[cdusuario] [varchar](150) NULL,
	[dscondicion] [text] NULL,
 CONSTRAINT [PK_Pacientes] PRIMARY KEY CLUSTERED 
(
	[nmind] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 12/09/2022 1:06:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[nmid] [int] IDENTITY(1,1) NOT NULL,
	[cddocumento] [varchar](20) NULL,
	[dsnombres] [varchar](60) NULL,
	[dsapellidos] [varchar](60) NULL,
	[fenacimiento] [date] NULL,
	[cdtipo] [varchar](10) NULL,
	[cdgenero] [varchar](10) NULL,
	[feregistro] [datetime] NULL,
	[febaja] [datetime] NULL,
	[cdusuario] [varchar](150) NULL,
	[dsdireccion] [varchar](200) NULL,
	[dsphoto] [varbinary](max) NULL,
	[cdtelefono_fijo] [varchar](20) NULL,
	[cdtelefono_movil] [varchar](20) NULL,
	[dsemail] [varchar](200) NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[nmid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[DataMaestra]  WITH CHECK ADD  CONSTRAINT [FK_DataMaestra_Maestras] FOREIGN KEY([nmaestro])
REFERENCES [dbo].[Maestras] ([nmmaestro])
GO
ALTER TABLE [dbo].[DataMaestra] CHECK CONSTRAINT [FK_DataMaestra_Maestras]
GO
ALTER TABLE [dbo].[Pacientes]  WITH CHECK ADD  CONSTRAINT [FK_Pacientes_Personas] FOREIGN KEY([nmind_persona])
REFERENCES [dbo].[Personas] ([nmid])
GO
ALTER TABLE [dbo].[Pacientes] CHECK CONSTRAINT [FK_Pacientes_Personas]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_patients]    Script Date: 12/09/2022 1:06:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Jennifer Hernandez>
-- Create date: <10/09/2022>
-- =============================================
CREATE PROCEDURE [dbo].[sp_insert_patients]
@nmind_persona int,
@eps varchar(50),
@arl varchar(50),
@usuario varchar(150),
@condicion text
AS
BEGIN
	DECLARE @Respuesta varchar(50) = 'Error'
	IF NOT EXISTS (SELECT * FROM [Pacientes] WHERE [nmind_persona] = @nmind_persona)
		BEGIN
			INSERT INTO [Pacientes] ([nmind_persona],[dseps],[dsarl],[feregistro],[cdusuario],[dscondicion])
			VALUES (@nmind_persona,@eps,@arl,GETDATE(),@usuario,@condicion)
			SET @Respuesta = 'Registro exitoso'
		END
	ELSE
		BEGIN
			SET @Respuesta = 'El documento a registrar ya existe, intente con otro o modifique el existente'			
		END
	SELECT @Respuesta AS [Respuesta]
END
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_people]    Script Date: 12/09/2022 1:06:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Jennifer Hernandez>
-- Create date: <10/09/2022>
-- =============================================
CREATE PROCEDURE [dbo].[sp_insert_people]
@documento varchar(20),
@nombres varchar(60),
@apellidos varchar(60),
@fenacimiento date,
@tipo varchar(10),
@genero varchar(10),
@usuario varchar(150),
@direccion varchar(200),
@photo varbinary(max),
@telefonoFijo varchar(20),
@telefonoMovil varchar(20),
@email varchar(200)
AS
BEGIN
	DECLARE @Respuesta varchar(50) = 'Error', @nmid int = 0
	IF @documento <> '' OR @documento IS NOT NULL AND @nombres <> '' OR @nombres IS NOT NULL AND @apellidos <> '' OR @apellidos IS NOT NULL
		BEGIN
			IF NOT EXISTS (SELECT * FROM [Personas] WHERE [cddocumento] = @documento)
				BEGIN
					INSERT INTO [Personas] ([cddocumento],[dsnombres],[dsapellidos],[fenacimiento],[cdtipo],[cdgenero],[feregistro],
					[cdusuario],[dsdireccion],[dsphoto],[cdtelefono_fijo],[cdtelefono_movil],[dsemail])
					VALUES (@documento,@nombres,@apellidos,@fenacimiento,@tipo,@genero,GETDATE(),
					@usuario,@direccion,@photo,@telefonoFijo,@telefonoMovil,@email)
					SET @nmid = (@@IDENTITY)
					SET @Respuesta = 'Registro exitoso'
				END
			ELSE 
				BEGIN
					SET @Respuesta = 'El documento a registrar ya existe, intente con otro o modifique el existente'
				END
		END
	SELECT @Respuesta AS [Respuesta], @nmid AS [Nmid]
END
GO
/****** Object:  StoredProcedure [dbo].[sp_search_patients]    Script Date: 12/09/2022 1:06:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_search_patients]
@documento varchar(20)
AS
BEGIN
	DECLARE @nmind_persona int = 0
	
	IF @documento IS NOT NULL
		BEGIN
			SET @nmind_persona = (SELECT [nmid] FROM [Personas] WHERE [cddocumento] = @documento)
				
				IF @nmind_persona IS NOT NULL OR @nmind_persona <> 0
					BEGIN
						SELECT [dseps], [dsarl], [feregistro], [febaja], [cdusuario], [dscondicion]
						FROM [Pacientes]
						WHERE [nmind_persona] = @nmind_persona
					END
		END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_search_people]    Script Date: 12/09/2022 1:06:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Jennifer Hernandez Salazar>
-- Create date: <11/09/2022>
-- =============================================
--exec sp_search_people 098988766
CREATE PROCEDURE [dbo].[sp_search_people]
@documento varchar(20)
AS
BEGIN
	IF EXISTS(SELECT * FROM [Personas] WHERE [cddocumento] = @documento)
		BEGIN
			DECLARE @nmindPersona int = 0, @cdtipo nvarchar(10) = ''
			SET @nmindPersona = (SELECT [nmid] FROM [Personas] WHERE [cddocumento] = @documento )
			SET @cdtipo = (SELECT [cdtipo] FROM [Personas] WHERE [cddocumento] = @documento )
			SELECT [nmid],[cddocumento], [dsnombres],[dsapellidos],[fenacimiento],[cdtipo],[cdgenero],[cdusuario],[dsdireccion],[dsphoto],
			[cdtelefono_fijo],[cdtelefono_movil],[dsemail], CASE WHEN [febaja] IS NULL THEN 0 ELSE 1 END AS [darBaja]
			FROM [dbo].[Personas]
			WHERE [cddocumento] = @documento

			SELECT [dseps],[dsarl],[cdusuario],[dscondicion]
			FROM [Pacientes]
			WHERE [nmind_persona] = @nmindPersona

			SELECT [nmdato],[dsdato]
			FROM [DataMaestra]
			WHERE [nmdato] = @cdtipo
		END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_select_dataMaster]    Script Date: 12/09/2022 1:06:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Jennifer Hernandez>
-- Create date: <10/09/2022>
-- =============================================
CREATE PROCEDURE [dbo].[sp_select_dataMaster]
AS
BEGIN
	SELECT [nmdato],[dsdato]
	FROM [DataMaestra]
END
GO
/****** Object:  StoredProcedure [dbo].[sp_select_index_patients]    Script Date: 12/09/2022 1:06:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Jennifer Hernandez>
-- Create date: <10/09/2022>
-- =============================================
CREATE PROCEDURE [dbo].[sp_select_index_patients]
AS
BEGIN
	SELECT [nmind], [cddocumento],[dsnombres] + ' ' + [dsapellidos] AS [Paciente],[dseps],[dsarl]
	FROM [Pacientes]
		JOIN [Personas]
			ON [Personas].[nmid] = [Pacientes].[nmind_persona]
END
GO
/****** Object:  StoredProcedure [dbo].[sp_select_index_people]    Script Date: 12/09/2022 1:06:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Jennifer Hernandez>
-- Create date: <10/09/2022>
-- =============================================
CREATE PROCEDURE [dbo].[sp_select_index_people]
AS
BEGIN
	SELECT [nmid],[cddocumento],[dsnombres] + ' ' + [dsapellidos] AS [Persona],[DataMaestra].dsdato AS [tipoPersona],[cdgenero],[Personas].[feregistro]
	FROM [Personas]
		LEFT JOIN [DataMaestra]
			ON [DataMaestra].[nmdato] = [Personas].cdtipo
END
GO
/****** Object:  StoredProcedure [dbo].[sp_select_patients_full_info]    Script Date: 12/09/2022 1:06:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[sp_select_patients_full_info]
@nmind int
AS
BEGIN
	SELECT [cddocumento],[dsnombres] + ' ' + [dsapellidos] AS [Paciente],[fenacimiento],[cdgenero],[Personas].[feregistro] as [FeregistroPersona],[Personas].[febaja] as [FebajaPersona],
	[Personas].[cdusuario] as [CdusuarioPersona], [dsdireccion],[dsphoto],[cdtelefono_fijo],[cdtelefono_movil],[dsemail], [dseps], [dsarl], [Pacientes].[feregistro] as [FeregistroPaciente],
	[Pacientes].[febaja] as [FebajaPaciente], [Pacientes].[cdusuario] as [CdusuarioPaciente], [dscondicion]
	FROM [Pacientes]
		JOIN [Personas]
			ON [Personas].[nmid] = [Pacientes].[nmind_persona]
		JOIN [DataMaestra]
			ON [DataMaestra].[nmdato] = [Personas].cdtipo
	WHERE [Pacientes].[nmind] = @nmind AND [DataMaestra].[nmdato] = 'Tp-02'
END
GO
/****** Object:  StoredProcedure [dbo].[sp_update_patients]    Script Date: 12/09/2022 1:06:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Jennifer Hernandez>
-- Create date: <10/09/2022>
-- =============================================
CREATE PROCEDURE [dbo].[sp_update_patients]
@nmind_persona int,
@eps varchar(50),
@arl varchar(50),
@usuario varchar(150),
@condicion text,
@darBaja bit
AS
BEGIN
	DECLARE @Respuesta varchar(150) = 'Error'
	IF @darBaja = 1
		BEGIN
			UPDATE [Pacientes]
				SET 
					[dseps] = @eps,
					[dsarl] = @arl,
					[febaja] = GETDATE(),
					[cdusuario] = @usuario,
					[dscondicion] = @condicion
				WHERE [nmind_persona]  = @nmind_persona				
			SET @Respuesta = 'Actualización exitosa'
		END
	ELSE
		BEGIN
			UPDATE [Pacientes]
				SET 
					[dseps] = @eps,
					[dsarl] = @arl,
					[cdusuario] = @usuario,
					[dscondicion] = @condicion
				WHERE [nmind_persona]  = @nmind_persona				
			SET @Respuesta = 'Actualización exitosa'
		END
	SELECT @Respuesta AS [Respuesta]
END
GO
/****** Object:  StoredProcedure [dbo].[sp_update_people]    Script Date: 12/09/2022 1:06:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Jennifer hernandez>
-- Create date: <10/09/2022>
-- =============================================
CREATE PROCEDURE [dbo].[sp_update_people]
@nmind int,
@documento varchar(20),
@nombres varchar(60),
@apellidos varchar(60),
@fenacimiento date,
@tipo varchar(10),
@genero varchar(10),
@usuario varchar(150),
@direccion varchar(200),
@photo varbinary(max),
@telefonoFijo varchar(20),
@telefonoMovil varchar(20),
@email varchar(200),
@darBaja bit
AS
BEGIN
	DECLARE @Respuesta varchar(150) = 'Error', @nmid int = 0
	SET @nmid = (SELECT [nmid] FROM [Personas] WHERE [cddocumento] = @documento)
	IF @darBaja = 1
		BEGIN
			UPDATE [Personas]
				SET 
					[cddocumento] = @documento,
					[dsnombres] = @nombres,
					[dsapellidos] = @apellidos,
					[fenacimiento] = @fenacimiento,
					[cdtipo] = @tipo,
					[cdgenero] = @genero,
					[febaja] = GETDATE(),
					[cdusuario] = @usuario,
					[dsdireccion] = @direccion,
					[dsphoto] = @photo,
					[cdtelefono_fijo] = @telefonoFijo,
					[cdtelefono_movil] = @telefonoMovil,
					[dsemail] = @email
				WHERE [nmid] = @nmind
			SET @Respuesta = 'Actualización exitosa'
		END
	ELSE
		BEGIN
			UPDATE [Personas]
				SET 
					[cddocumento] = @documento,
					[dsnombres] = @nombres,
					[dsapellidos] = @apellidos,
					[fenacimiento] = @fenacimiento,
					[cdtipo] = @tipo,
					[cdgenero] = @genero,
						[febaja] = null,
					[cdusuario] = @usuario,
					[dsdireccion] = @direccion,
					[dsphoto] = @photo,
					[cdtelefono_fijo] = @telefonoFijo,
					[cdtelefono_movil] = @telefonoMovil,
					[dsemail] = @email
				WHERE [nmid] = @nmind
			SET @Respuesta = 'Actualización exitosa'
		END
	SELECT @Respuesta AS [Respuesta], @nmid AS [Nmid]
END
GO
USE [master]
GO
ALTER DATABASE [PRUEBA] SET  READ_WRITE 
GO
