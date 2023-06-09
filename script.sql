USE [master]
GO
/****** Object:  Database [DealerDb]    Script Date: 6/6/2023 1:59:36 AM ******/
CREATE DATABASE [DealerDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DealerDb', FILENAME = N'D:\MSSQL15.SQLSERVER\MSSQL\DATA\DealerDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DealerDb_log', FILENAME = N'D:\MSSQL15.SQLSERVER\MSSQL\DATA\DealerDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DealerDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DealerDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DealerDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DealerDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DealerDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DealerDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DealerDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [DealerDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DealerDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DealerDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DealerDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DealerDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DealerDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DealerDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DealerDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DealerDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DealerDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DealerDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DealerDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DealerDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DealerDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DealerDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DealerDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DealerDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DealerDb] SET RECOVERY FULL 
GO
ALTER DATABASE [DealerDb] SET  MULTI_USER 
GO
ALTER DATABASE [DealerDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DealerDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DealerDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DealerDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DealerDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DealerDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DealerDb', N'ON'
GO
ALTER DATABASE [DealerDb] SET QUERY_STORE = OFF
GO
USE [DealerDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/6/2023 1:59:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 6/6/2023 1:59:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[NmCliente] [nvarchar](max) NOT NULL,
	[Cidade] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produtos]    Script Date: 6/6/2023 1:59:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produtos](
	[IdProduto] [int] IDENTITY(1,1) NOT NULL,
	[DscProduto] [nvarchar](max) NOT NULL,
	[VlrUnitario] [real] NOT NULL,
 CONSTRAINT [PK_Produtos] PRIMARY KEY CLUSTERED 
(
	[IdProduto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendas]    Script Date: 6/6/2023 1:59:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendas](
	[IdVenda] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdProduto] [int] NOT NULL,
	[QtdVenda] [int] NOT NULL,
	[VlrUnitarioVenda] [real] NOT NULL,
	[DthVenda] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Vendas] PRIMARY KEY CLUSTERED 
(
	[IdVenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230601003523_FirstMigration', N'7.0.5')
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([IdCliente], [NmCliente], [Cidade]) VALUES (1, N'Cli1', N'Cidade1')
INSERT [dbo].[Clientes] ([IdCliente], [NmCliente], [Cidade]) VALUES (2, N'Cli2', N'Cidade2')
INSERT [dbo].[Clientes] ([IdCliente], [NmCliente], [Cidade]) VALUES (3, N'Cli3', N'Cidade3')
INSERT [dbo].[Clientes] ([IdCliente], [NmCliente], [Cidade]) VALUES (4, N'Cli33', N'Cidade33')
INSERT [dbo].[Clientes] ([IdCliente], [NmCliente], [Cidade]) VALUES (5, N'Gabriel', N'Curitiba')
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Produtos] ON 

INSERT [dbo].[Produtos] ([IdProduto], [DscProduto], [VlrUnitario]) VALUES (1, N'Produto 1', 5)
INSERT [dbo].[Produtos] ([IdProduto], [DscProduto], [VlrUnitario]) VALUES (2, N'Produto 2', 10)
INSERT [dbo].[Produtos] ([IdProduto], [DscProduto], [VlrUnitario]) VALUES (3, N'Produto 3', 15)
INSERT [dbo].[Produtos] ([IdProduto], [DscProduto], [VlrUnitario]) VALUES (4, N'Produto 4', 20)
INSERT [dbo].[Produtos] ([IdProduto], [DscProduto], [VlrUnitario]) VALUES (5, N'Sabão', 4)
SET IDENTITY_INSERT [dbo].[Produtos] OFF
GO
SET IDENTITY_INSERT [dbo].[Vendas] ON 

INSERT [dbo].[Vendas] ([IdVenda], [IdCliente], [IdProduto], [QtdVenda], [VlrUnitarioVenda], [DthVenda]) VALUES (1, 1, 1, 5, 5, CAST(N'2023-06-06T04:49:09.8070000' AS DateTime2))
INSERT [dbo].[Vendas] ([IdVenda], [IdCliente], [IdProduto], [QtdVenda], [VlrUnitarioVenda], [DthVenda]) VALUES (2, 1, 2, 1, 10, CAST(N'2023-06-06T04:49:09.8070000' AS DateTime2))
INSERT [dbo].[Vendas] ([IdVenda], [IdCliente], [IdProduto], [QtdVenda], [VlrUnitarioVenda], [DthVenda]) VALUES (3, 1, 3, 1, 15, CAST(N'2023-06-06T04:49:09.8070000' AS DateTime2))
INSERT [dbo].[Vendas] ([IdVenda], [IdCliente], [IdProduto], [QtdVenda], [VlrUnitarioVenda], [DthVenda]) VALUES (4, 2, 1, 5, 5, CAST(N'2023-06-06T04:49:09.8070000' AS DateTime2))
INSERT [dbo].[Vendas] ([IdVenda], [IdCliente], [IdProduto], [QtdVenda], [VlrUnitarioVenda], [DthVenda]) VALUES (5, 2, 2, 1, 10, CAST(N'2023-06-06T04:49:09.8070000' AS DateTime2))
INSERT [dbo].[Vendas] ([IdVenda], [IdCliente], [IdProduto], [QtdVenda], [VlrUnitarioVenda], [DthVenda]) VALUES (6, 3, 1, 10, 6, CAST(N'2023-06-06T04:49:09.8070000' AS DateTime2))
INSERT [dbo].[Vendas] ([IdVenda], [IdCliente], [IdProduto], [QtdVenda], [VlrUnitarioVenda], [DthVenda]) VALUES (7, 3, 3, 2, 15, CAST(N'2023-06-06T04:49:09.8070000' AS DateTime2))
INSERT [dbo].[Vendas] ([IdVenda], [IdCliente], [IdProduto], [QtdVenda], [VlrUnitarioVenda], [DthVenda]) VALUES (8, 4, 5, 3, 4, CAST(N'2023-06-06T01:50:38.1797703' AS DateTime2))
INSERT [dbo].[Vendas] ([IdVenda], [IdCliente], [IdProduto], [QtdVenda], [VlrUnitarioVenda], [DthVenda]) VALUES (9, 4, 5, 3, 4, CAST(N'2023-06-06T01:50:44.4503506' AS DateTime2))
INSERT [dbo].[Vendas] ([IdVenda], [IdCliente], [IdProduto], [QtdVenda], [VlrUnitarioVenda], [DthVenda]) VALUES (10, 4, 4, 5, 20, CAST(N'2023-06-06T01:52:54.7321339' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Vendas] OFF
GO
/****** Object:  Index [IX_Vendas_IdCliente]    Script Date: 6/6/2023 1:59:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_Vendas_IdCliente] ON [dbo].[Vendas]
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vendas_IdProduto]    Script Date: 6/6/2023 1:59:36 AM ******/
CREATE NONCLUSTERED INDEX [IX_Vendas_IdProduto] ON [dbo].[Vendas]
(
	[IdProduto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Vendas]  WITH CHECK ADD  CONSTRAINT [FK_Vendas_Clientes_IdCliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Vendas] CHECK CONSTRAINT [FK_Vendas_Clientes_IdCliente]
GO
ALTER TABLE [dbo].[Vendas]  WITH CHECK ADD  CONSTRAINT [FK_Vendas_Produtos_IdProduto] FOREIGN KEY([IdProduto])
REFERENCES [dbo].[Produtos] ([IdProduto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Vendas] CHECK CONSTRAINT [FK_Vendas_Produtos_IdProduto]
GO
USE [master]
GO
ALTER DATABASE [DealerDb] SET  READ_WRITE 
GO
