USE [master]
GO
/****** Object:  Database [Admitere]    Script Date: 11/26/2021 5:40:59 PM ******/
CREATE DATABASE [Admitere]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Admitere', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Admitere.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB ),
( NAME = N'Admitere2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Admitere2.ndf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10240KB ),
( NAME = N'Admitere3', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Admitere3.ndf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10240KB )
 LOG ON 
( NAME = N'Admitere_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Admitere_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB ), 
( NAME = N'Admitere_log2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Admitere_log2.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10240KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Admitere] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Admitere].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Admitere] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Admitere] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Admitere] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Admitere] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Admitere] SET ARITHABORT OFF 
GO
ALTER DATABASE [Admitere] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Admitere] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Admitere] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Admitere] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Admitere] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Admitere] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Admitere] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Admitere] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Admitere] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Admitere] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Admitere] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Admitere] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Admitere] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Admitere] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Admitere] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Admitere] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Admitere] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Admitere] SET RECOVERY FULL 
GO
ALTER DATABASE [Admitere] SET  MULTI_USER 
GO
ALTER DATABASE [Admitere] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Admitere] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Admitere] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Admitere] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Admitere] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Admitere] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Admitere', N'ON'
GO
ALTER DATABASE [Admitere] SET QUERY_STORE = OFF
GO
USE [Admitere]
GO
/****** Object:  Table [dbo].[Beneficiari]    Script Date: 11/26/2021 5:41:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beneficiari](
	[IdBeneficiar] [int] IDENTITY(1,1) NOT NULL,
	[Denumire] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Beneficiari] PRIMARY KEY CLUSTERED 
(
	[IdBeneficiar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Beneficiari_ProgrameDeStudii]    Script Date: 11/26/2021 5:41:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beneficiari_ProgrameDeStudii](
	[IdBeneficiar] [int] NOT NULL,
	[IdProgrameDeStudiu] [int] NOT NULL,
	[LocuriScoaseLaConcurs] [int] NOT NULL,
 CONSTRAINT [PK_Beneficiari_ProgrameDeStudii] PRIMARY KEY CLUSTERED 
(
	[IdBeneficiar] ASC,
	[IdProgrameDeStudiu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DateCandidati]    Script Date: 11/26/2021 5:41:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DateCandidati](
	[IdCandidat] [int] IDENTITY(1,1) NOT NULL,
	[Nume] [nvarchar](100) NOT NULL,
	[PrenumeTata] [nvarchar](100) NOT NULL,
	[PrenumeCandidat] [nvarchar](100) NOT NULL,
	[CodCandidat] [int] NOT NULL,
	[DataNasterii] [date] NOT NULL,
	[LoculNasterii] [nvarchar](100) NOT NULL,
	[Judet] [nvarchar](100) NOT NULL,
	[Localitatea] [nvarchar](100) NOT NULL,
	[Sector] [nvarchar](100) NULL,
	[Strada] [nvarchar](100) NOT NULL,
	[NumarStarda] [int] NOT NULL,
	[Bloc] [nvarchar](100) NOT NULL,
	[Scara] [nvarchar](100) NOT NULL,
	[Etaj] [nvarchar](100) NOT NULL,
	[Apartament] [nvarchar](100) NOT NULL,
	[Cod] [int] NOT NULL,
	[Telefon] [nvarchar](100) NOT NULL,
	[SerieCI] [nvarchar](100) NOT NULL,
	[NumarCI] [nvarchar](100) NOT NULL,
	[CNP] [char](13) NOT NULL,
	[MedieBacalaureat] [float] NOT NULL,
	[PDF] [varbinary](max) NOT NULL,
	[IdBeneficiar] [int] NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_DateCandidati] PRIMARY KEY CLUSTERED 
(
	[IdCandidat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProgrameDeStudiu]    Script Date: 11/26/2021 5:41:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgrameDeStudiu](
	[IdProgramDeStudiu] [int] IDENTITY(1,1) NOT NULL,
	[Denumire] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ProgrameDeStudiu] PRIMARY KEY CLUSTERED 
(
	[IdProgramDeStudiu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Beneficiari] ON 

INSERT [dbo].[Beneficiari] ([IdBeneficiar], [Denumire]) VALUES (1, N'Mai')
INSERT [dbo].[Beneficiari] ([IdBeneficiar], [Denumire]) VALUES (2, N'Sri')
INSERT [dbo].[Beneficiari] ([IdBeneficiar], [Denumire]) VALUES (3, N'Mapn')
SET IDENTITY_INSERT [dbo].[Beneficiari] OFF
GO
INSERT [dbo].[Beneficiari_ProgrameDeStudii] ([IdBeneficiar], [IdProgrameDeStudiu], [LocuriScoaseLaConcurs]) VALUES (1, 1, 10)
INSERT [dbo].[Beneficiari_ProgrameDeStudii] ([IdBeneficiar], [IdProgrameDeStudiu], [LocuriScoaseLaConcurs]) VALUES (1, 2, 5)
INSERT [dbo].[Beneficiari_ProgrameDeStudii] ([IdBeneficiar], [IdProgrameDeStudiu], [LocuriScoaseLaConcurs]) VALUES (1, 3, 4)
INSERT [dbo].[Beneficiari_ProgrameDeStudii] ([IdBeneficiar], [IdProgrameDeStudiu], [LocuriScoaseLaConcurs]) VALUES (2, 4, 5)
GO
SET IDENTITY_INSERT [dbo].[ProgrameDeStudiu] ON 

INSERT [dbo].[ProgrameDeStudiu] ([IdProgramDeStudiu], [Denumire]) VALUES (1, N'Motoare de aviatie')
INSERT [dbo].[ProgrameDeStudiu] ([IdProgramDeStudiu], [Denumire]) VALUES (2, N'Calculatoare')
INSERT [dbo].[ProgrameDeStudiu] ([IdProgramDeStudiu], [Denumire]) VALUES (3, N'Comunicatii')
INSERT [dbo].[ProgrameDeStudiu] ([IdProgramDeStudiu], [Denumire]) VALUES (4, N'Bat')
SET IDENTITY_INSERT [dbo].[ProgrameDeStudiu] OFF
GO
ALTER TABLE [dbo].[Beneficiari_ProgrameDeStudii]  WITH CHECK ADD  CONSTRAINT [FK_Beneficiari_ProgrameDeStudii_Beneficiari] FOREIGN KEY([IdBeneficiar])
REFERENCES [dbo].[Beneficiari] ([IdBeneficiar])
GO
ALTER TABLE [dbo].[Beneficiari_ProgrameDeStudii] CHECK CONSTRAINT [FK_Beneficiari_ProgrameDeStudii_Beneficiari]
GO
ALTER TABLE [dbo].[Beneficiari_ProgrameDeStudii]  WITH CHECK ADD  CONSTRAINT [FK_Beneficiari_ProgrameDeStudii_ProgrameDeStudiu] FOREIGN KEY([IdProgrameDeStudiu])
REFERENCES [dbo].[ProgrameDeStudiu] ([IdProgramDeStudiu])
GO
ALTER TABLE [dbo].[Beneficiari_ProgrameDeStudii] CHECK CONSTRAINT [FK_Beneficiari_ProgrameDeStudii_ProgrameDeStudiu]
GO
ALTER TABLE [dbo].[DateCandidati]  WITH CHECK ADD  CONSTRAINT [FK_DateCandidati_Beneficiari] FOREIGN KEY([IdBeneficiar])
REFERENCES [dbo].[Beneficiari] ([IdBeneficiar])
GO
ALTER TABLE [dbo].[DateCandidati] CHECK CONSTRAINT [FK_DateCandidati_Beneficiari]
GO
/****** Object:  StoredProcedure [dbo].[GetProgrameDeStudiuPtBeneficiar]    Script Date: 11/26/2021 5:41:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetProgrameDeStudiuPtBeneficiar]
	@IdBeneficiar as nvarchar(50)
as 
begin
	
	Select P.Denumire 
	from Beneficiari as B
	inner join
	Beneficiari_ProgrameDeStudii as BP
	ON B.IdBeneficiar=BP.IdBeneficiar
	inner join ProgrameDeStudiu as P
	ON P.IdProgramDeStudiu=BP.IdProgrameDeStudiu
	WHERE B.IdBeneficiar = @IdBeneficiar
return;
end;
GO
USE [master]
GO
ALTER DATABASE [Admitere] SET  READ_WRITE 
GO
