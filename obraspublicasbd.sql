USE [master]
GO
/****** Object:  Database [ObrasPublicasDB]    Script Date: 7/7/2022 11:58:51 PM ******/
CREATE DATABASE [ObrasPublicasDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ObrasPublicasDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ObrasPublicasDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ObrasPublicasDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ObrasPublicasDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ObrasPublicasDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ObrasPublicasDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ObrasPublicasDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ObrasPublicasDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ObrasPublicasDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ObrasPublicasDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ObrasPublicasDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ObrasPublicasDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ObrasPublicasDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ObrasPublicasDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ObrasPublicasDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ObrasPublicasDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ObrasPublicasDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ObrasPublicasDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ObrasPublicasDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ObrasPublicasDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ObrasPublicasDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ObrasPublicasDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ObrasPublicasDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ObrasPublicasDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ObrasPublicasDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ObrasPublicasDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ObrasPublicasDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ObrasPublicasDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ObrasPublicasDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ObrasPublicasDB] SET  MULTI_USER 
GO
ALTER DATABASE [ObrasPublicasDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ObrasPublicasDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ObrasPublicasDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ObrasPublicasDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ObrasPublicasDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ObrasPublicasDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ObrasPublicasDB] SET QUERY_STORE = OFF
GO
USE [ObrasPublicasDB]
GO
/****** Object:  Table [dbo].[ReconTable]    Script Date: 7/7/2022 11:58:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReconTable](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DEVICE_NAME] [nvarchar](150) NOT NULL,
	[LOCATION] [nvarchar](100) NOT NULL,
	[PHOTO] [nvarchar](50) NOT NULL,
	[REGISTER_DATE] [date] NOT NULL,
 CONSTRAINT [PK_ReconTable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SensorsTable]    Script Date: 7/7/2022 11:58:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SensorsTable](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DEVICE_NAME] [nvarchar](50) NOT NULL,
	[LOCATION] [nvarchar](50) NOT NULL,
	[PERCENTAGE] [float] NOT NULL,
	[STATUS] [nvarchar](50) NOT NULL,
	[REGISTER_DATE] [date] NOT NULL,
 CONSTRAINT [PK_SensorsTable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [ObrasPublicasDB] SET  READ_WRITE 
GO
