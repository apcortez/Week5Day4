USE [master]
GO
/****** Object:  Database [NegozioElettronica]    Script Date: 8/26/2021 3:28:27 PM ******/
CREATE DATABASE [NegozioElettronica]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NegozioElettronica', FILENAME = N'C:\Users\angelica.cortez\NegozioElettronica.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NegozioElettronica_log', FILENAME = N'C:\Users\angelica.cortez\NegozioElettronica_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [NegozioElettronica] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NegozioElettronica].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NegozioElettronica] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NegozioElettronica] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NegozioElettronica] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NegozioElettronica] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NegozioElettronica] SET ARITHABORT OFF 
GO
ALTER DATABASE [NegozioElettronica] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NegozioElettronica] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NegozioElettronica] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NegozioElettronica] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NegozioElettronica] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NegozioElettronica] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NegozioElettronica] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NegozioElettronica] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NegozioElettronica] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NegozioElettronica] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NegozioElettronica] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NegozioElettronica] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NegozioElettronica] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NegozioElettronica] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NegozioElettronica] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NegozioElettronica] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NegozioElettronica] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NegozioElettronica] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NegozioElettronica] SET  MULTI_USER 
GO
ALTER DATABASE [NegozioElettronica] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NegozioElettronica] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NegozioElettronica] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NegozioElettronica] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NegozioElettronica] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NegozioElettronica] SET QUERY_STORE = OFF
GO
USE [NegozioElettronica]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [NegozioElettronica]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 8/26/2021 3:28:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Brand] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Memory] [int] NULL,
	[OS] [int] NULL,
	[Touchscreen] [bit] NULL,
	[Inch] [int] NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OS], [Touchscreen], [Inch], [Type], [Id]) VALUES (N'HP', N'Notebook 1', 4, NULL, 0, 1, NULL, N'Pc', 1)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OS], [Touchscreen], [Inch], [Type], [Id]) VALUES (N'ACER', N'Aspire 4', 100, NULL, 2, 0, NULL, N'Pc', 2)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OS], [Touchscreen], [Inch], [Type], [Id]) VALUES (N'Apple', N'Macbook M1', 176, NULL, 1, 0, NULL, N'Pc', 3)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OS], [Touchscreen], [Inch], [Type], [Id]) VALUES (N'Dell', N'Dell321', 150, NULL, 2, 1, NULL, N'Pc', 4)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OS], [Touchscreen], [Inch], [Type], [Id]) VALUES (N'Apple', N'Iphone 11 Pro', 320, 256, NULL, NULL, NULL, N'Phone', 5)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OS], [Touchscreen], [Inch], [Type], [Id]) VALUES (N'Apple', N'Iphone 12 Mini', 500, 128, NULL, NULL, NULL, N'Phone', 6)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OS], [Touchscreen], [Inch], [Type], [Id]) VALUES (N'Apple', N'Iphone 12 Pro', 150, 512, NULL, NULL, NULL, N'Phone', 7)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OS], [Touchscreen], [Inch], [Type], [Id]) VALUES (N'Samsung', N'Flip X', 350, 256, NULL, NULL, NULL, N'Phone', 8)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OS], [Touchscreen], [Inch], [Type], [Id]) VALUES (N'Samsung', N'Note 10', 556, 512, NULL, NULL, NULL, N'Phone', 9)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OS], [Touchscreen], [Inch], [Type], [Id]) VALUES (N'Xiaomi', N'Mi 11 Pro', 113, 512, NULL, NULL, NULL, N'Phone', 11)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OS], [Touchscreen], [Inch], [Type], [Id]) VALUES (N'Sony', N'MaxiSchermo', 100, NULL, NULL, NULL, 50, N'Tv', 12)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OS], [Touchscreen], [Inch], [Type], [Id]) VALUES (N'Samsung', N'1012', 250, NULL, NULL, NULL, 42, N'Tv', 13)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OS], [Touchscreen], [Inch], [Type], [Id]) VALUES (N'Samsung', N'MaxiSchermo', 521, NULL, NULL, NULL, 100, N'Tv', 14)
INSERT [dbo].[Product] ([Brand], [Model], [Quantity], [Memory], [OS], [Touchscreen], [Inch], [Type], [Id]) VALUES (N'Asus', N'Maxi', 10, NULL, NULL, NULL, 32, N'Tv', 1002)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
USE [master]
GO
ALTER DATABASE [NegozioElettronica] SET  READ_WRITE 
GO
