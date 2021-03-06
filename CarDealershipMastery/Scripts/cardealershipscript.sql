
/****** Object:  Database [GuildCars]    Script Date: 3/21/2019 3:23:18 PM ******/
CREATE DATABASE [GuildCars]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GuildCars', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\GuildCars.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GuildCars_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\GuildCars_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [GuildCars] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GuildCars].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GuildCars] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GuildCars] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GuildCars] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GuildCars] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GuildCars] SET ARITHABORT OFF 
GO
ALTER DATABASE [GuildCars] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GuildCars] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GuildCars] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GuildCars] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GuildCars] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GuildCars] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GuildCars] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GuildCars] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GuildCars] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GuildCars] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GuildCars] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GuildCars] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GuildCars] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GuildCars] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GuildCars] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GuildCars] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GuildCars] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GuildCars] SET RECOVERY FULL 
GO
ALTER DATABASE [GuildCars] SET  MULTI_USER 
GO
ALTER DATABASE [GuildCars] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GuildCars] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GuildCars] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GuildCars] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GuildCars] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'GuildCars', N'ON'
GO
ALTER DATABASE [GuildCars] SET QUERY_STORE = OFF
GO
USE [GuildCars]
GO
/****** Object:  Table [dbo].[BodyStyle]    Script Date: 3/21/2019 3:23:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BodyStyle](
	[BodyStyleID] [int] IDENTITY(1,1) NOT NULL,
	[BodyStyleType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_BodyStyle] PRIMARY KEY CLUSTERED 
(
	[BodyStyleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Color]    Script Date: 3/21/2019 3:23:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[ColorID] [int] IDENTITY(1,1) NOT NULL,
	[CarColor] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[ColorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Interior]    Script Date: 3/21/2019 3:23:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Interior](
	[InteriorID] [int] IDENTITY(1,1) NOT NULL,
	[InteriorColor] [varchar](50) NOT NULL,
	[InteriorType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Interior] PRIMARY KEY CLUSTERED 
(
	[InteriorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Make]    Script Date: 3/21/2019 3:23:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Make](
	[MakeID] [int] IDENTITY(1,1) NOT NULL,
	[MakeType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Make] PRIMARY KEY CLUSTERED 
(
	[MakeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Model]    Script Date: 3/21/2019 3:23:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Model](
	[ModelID] [int] IDENTITY(1,1) NOT NULL,
	[ModelType] [varchar](50) NOT NULL,
	[MakeID] [int] NOT NULL,
 CONSTRAINT [PK_Model] PRIMARY KEY CLUSTERED 
(
	[ModelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 3/21/2019 3:23:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[SalesID] [int] IDENTITY(1,1) NOT NULL,
	[Salesman] [varchar](50) NULL,
	[SalePrice] [varchar](50) NULL,
	[CarID] [int] NULL,
	[Customer] [varchar](50) NULL,
 CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED 
(
	[SalesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpecialTable]    Script Date: 3/21/2019 3:23:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpecialTable](
	[SpecialsID] [int] IDENTITY(1,1) NOT NULL,
	[Specialtype] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SpecialTable] PRIMARY KEY CLUSTERED 
(
	[SpecialsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transmission]    Script Date: 3/21/2019 3:23:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transmission](
	[TransmissionID] [int] IDENTITY(1,1) NOT NULL,
	[TransmissionType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Transmission] PRIMARY KEY CLUSTERED 
(
	[TransmissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 3/21/2019 3:23:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle](
	[VehicleID] [int] IDENTITY(1,1) NOT NULL,
	[Year] [int] NOT NULL,
	[ModelID] [int] NOT NULL,
	[BodyStyleID] [int] NOT NULL,
	[ColorID] [int] NOT NULL,
	[Mileage] [bigint] NOT NULL,
	[VIN] [varchar](17) NOT NULL,
	[InteriorID] [int] NOT NULL,
	[SalePrice] [decimal](18, 2) NOT NULL,
	[MSRP] [decimal](18, 2) NOT NULL,
	[TransmissionID] [int] NOT NULL,
	[SalesID] [int] NULL,
 CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED 
(
	[VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Model]  WITH CHECK ADD  CONSTRAINT [FK_Model_Make] FOREIGN KEY([MakeID])
REFERENCES [dbo].[Make] ([MakeID])
GO
ALTER TABLE [dbo].[Model] CHECK CONSTRAINT [FK_Model_Make]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_BodyStyle1] FOREIGN KEY([BodyStyleID])
REFERENCES [dbo].[BodyStyle] ([BodyStyleID])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_BodyStyle1]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_Color] FOREIGN KEY([ColorID])
REFERENCES [dbo].[Color] ([ColorID])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_Color]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_Interior] FOREIGN KEY([InteriorID])
REFERENCES [dbo].[Interior] ([InteriorID])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_Interior]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_Model] FOREIGN KEY([ModelID])
REFERENCES [dbo].[Model] ([ModelID])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_Model]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_Sales] FOREIGN KEY([SalesID])
REFERENCES [dbo].[Sales] ([SalesID])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_Sales]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_Transmission] FOREIGN KEY([TransmissionID])
REFERENCES [dbo].[Transmission] ([TransmissionID])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_Transmission]
GO
USE [master]
GO
ALTER DATABASE [GuildCars] SET  READ_WRITE 
GO
