USE [master]
GO
/****** Object:  Database [HotelReservations]    Script Date: 2/27/2019 2:04:13 AM ******/
CREATE DATABASE [HotelReservations]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HotelReservations', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\HotelReservations.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HotelReservations_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\HotelReservations_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [HotelReservations] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HotelReservations].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HotelReservations] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HotelReservations] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HotelReservations] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HotelReservations] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HotelReservations] SET ARITHABORT OFF 
GO
ALTER DATABASE [HotelReservations] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HotelReservations] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HotelReservations] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HotelReservations] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HotelReservations] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HotelReservations] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HotelReservations] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HotelReservations] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HotelReservations] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HotelReservations] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HotelReservations] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HotelReservations] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HotelReservations] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HotelReservations] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HotelReservations] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HotelReservations] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HotelReservations] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HotelReservations] SET RECOVERY FULL 
GO
ALTER DATABASE [HotelReservations] SET  MULTI_USER 
GO
ALTER DATABASE [HotelReservations] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HotelReservations] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HotelReservations] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HotelReservations] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HotelReservations] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HotelReservations', N'ON'
GO
ALTER DATABASE [HotelReservations] SET QUERY_STORE = OFF
GO
USE [HotelReservations]
GO
/****** Object:  Table [dbo].[AddOn]    Script Date: 2/27/2019 2:04:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddOn](
	[AddOnId] [int] NOT NULL,
	[AddOnDescription] [varchar](50) NULL,
 CONSTRAINT [PK_AddOn] PRIMARY KEY CLUSTERED 
(
	[AddOnId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AddOnFee]    Script Date: 2/27/2019 2:04:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddOnFee](
	[AddOnFeeId] [int] IDENTITY(1,1) NOT NULL,
	[AddOnId] [int] NOT NULL,
	[Fee] [decimal](18, 2) NOT NULL,
	[DateStart] [date] NOT NULL,
	[DateEnd] [date] NOT NULL,
 CONSTRAINT [PK_AddOnFee] PRIMARY KEY CLUSTERED 
(
	[AddOnFeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Amenity]    Script Date: 2/27/2019 2:04:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Amenity](
	[AmenityId] [int] IDENTITY(1,1) NOT NULL,
	[AmenityDescription] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Amenity] PRIMARY KEY CLUSTERED 
(
	[AmenityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 2/27/2019 2:04:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[BillId] [int] IDENTITY(1,1) NOT NULL,
	[ReservationId] [int] NOT NULL,
	[Total] [decimal](18, 0) NULL,
	[Tax] [decimal](18, 0) NULL,
	[Paid] [bit] NOT NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[BillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillDetail]    Script Date: 2/27/2019 2:04:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillDetail](
	[BillDetailId] [int] IDENTITY(1,1) NOT NULL,
	[BillId] [int] NOT NULL,
	[AddOnId] [int] NOT NULL,
	[Charge] [decimal](18, 2) NOT NULL,
	[Waived] [bit] NOT NULL,
 CONSTRAINT [PK_BillDetail] PRIMARY KEY CLUSTERED 
(
	[BillDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillPromo]    Script Date: 2/27/2019 2:04:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillPromo](
	[BillPromoId] [int] IDENTITY(1,1) NOT NULL,
	[BillId] [int] NOT NULL,
	[PromId] [int] NOT NULL,
 CONSTRAINT [PK_BillPromo] PRIMARY KEY CLUSTERED 
(
	[BillPromoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2/27/2019 2:04:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Phone] [varchar](50) NOT NULL,
	[Email] [varchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fee]    Script Date: 2/27/2019 2:04:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fee](
	[FeeId] [int] IDENTITY(1,1) NOT NULL,
	[Fee] [money] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [date] NULL,
 CONSTRAINT [PK_Fee] PRIMARY KEY CLUSTERED 
(
	[FeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guest]    Script Date: 2/27/2019 2:04:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guest](
	[GuestId] [int] IDENTITY(1,1) NOT NULL,
	[GuestFirstName] [varchar](50) NOT NULL,
	[GuestLastName] [varchar](50) NOT NULL,
	[Age] [int] NOT NULL,
 CONSTRAINT [PK_Guest] PRIMARY KEY CLUSTERED 
(
	[GuestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promo]    Script Date: 2/27/2019 2:04:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promo](
	[PromoId] [int] IDENTITY(1,1) NOT NULL,
	[PromoCode] [varchar](50) NOT NULL,
	[PromoDescription] [varchar](50) NOT NULL,
	[DateStart] [datetime] NOT NULL,
	[DateEnd] [datetime] NOT NULL,
	[PromoDiscount] [decimal](18, 0) NOT NULL,
	[PromoType] [char](1) NOT NULL,
 CONSTRAINT [PK_Promo] PRIMARY KEY CLUSTERED 
(
	[PromoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rate]    Script Date: 2/27/2019 2:04:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rate](
	[RateId] [int] IDENTITY(1,1) NOT NULL,
	[Rate] [decimal](18, 0) NOT NULL,
	[DateStart] [datetime] NOT NULL,
	[DateEnd] [datetime] NOT NULL,
 CONSTRAINT [PK_Rate] PRIMARY KEY CLUSTERED 
(
	[RateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 2/27/2019 2:04:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[ReservationId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[DateStart] [date] NOT NULL,
	[DateEnd] [date] NOT NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[ReservationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservationGuest]    Script Date: 2/27/2019 2:04:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservationGuest](
	[ReservationGuestId] [int] IDENTITY(1,1) NOT NULL,
	[ReservationId] [int] NOT NULL,
	[GuestId] [int] NOT NULL,
 CONSTRAINT [PK_ReservationGuest] PRIMARY KEY CLUSTERED 
(
	[ReservationGuestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservationPromo]    Script Date: 2/27/2019 2:04:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservationPromo](
	[ReservationPromoId] [int] IDENTITY(1,1) NOT NULL,
	[ReservationId] [int] NOT NULL,
	[PromoId] [int] NOT NULL,
 CONSTRAINT [PK_ReservationPromo] PRIMARY KEY CLUSTERED 
(
	[ReservationPromoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservationRoomType]    Script Date: 2/27/2019 2:04:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservationRoomType](
	[ReservationRoomTypeId] [int] IDENTITY(1,1) NOT NULL,
	[ReservationId] [int] NOT NULL,
	[RoomTypeId] [int] NOT NULL,
	[DateStart] [date] NOT NULL,
	[DateEnd] [date] NOT NULL,
	[RoomId] [int] NULL,
 CONSTRAINT [PK_ReservationRoom] PRIMARY KEY CLUSTERED 
(
	[ReservationRoomTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 2/27/2019 2:04:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[RoomId] [int] IDENTITY(1,1) NOT NULL,
	[RoomNumber] [int] NOT NULL,
	[FloorNumber] [int] NOT NULL,
	[OccupancyMax] [int] NOT NULL,
	[RoomTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomAmenity]    Script Date: 2/27/2019 2:04:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomAmenity](
	[RoomAmenityId] [int] IDENTITY(1,1) NOT NULL,
	[RoomId] [int] NOT NULL,
	[AmenityId] [int] NOT NULL,
 CONSTRAINT [PK_RoomAmenity] PRIMARY KEY CLUSTERED 
(
	[RoomAmenityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomType]    Script Date: 2/27/2019 2:04:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomType](
	[RoomTypeId] [int] IDENTITY(1,1) NOT NULL,
	[RoomTypeDescription] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RoomType] PRIMARY KEY CLUSTERED 
(
	[RoomTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomTypeRate]    Script Date: 2/27/2019 2:04:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomTypeRate](
	[RoomTypeRateId] [int] IDENTITY(1,1) NOT NULL,
	[RoomTypeId] [int] NOT NULL,
	[RateId] [int] NOT NULL,
 CONSTRAINT [PK_RoomRate] PRIMARY KEY CLUSTERED 
(
	[RoomTypeRateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AddOn] ([AddOnId], [AddOnDescription]) VALUES (1, N'Alcohol')
INSERT [dbo].[AddOn] ([AddOnId], [AddOnDescription]) VALUES (2, N'Late Checkout')
INSERT [dbo].[AddOn] ([AddOnId], [AddOnDescription]) VALUES (3, N'Champagne')
INSERT [dbo].[AddOn] ([AddOnId], [AddOnDescription]) VALUES (4, N'Movie')
INSERT [dbo].[AddOn] ([AddOnId], [AddOnDescription]) VALUES (5, N'Housekeeping')
INSERT [dbo].[AddOn] ([AddOnId], [AddOnDescription]) VALUES (6, N'Valet Service')
SET IDENTITY_INSERT [dbo].[AddOnFee] ON 

INSERT [dbo].[AddOnFee] ([AddOnFeeId], [AddOnId], [Fee], [DateStart], [DateEnd]) VALUES (1, 1, CAST(10.00 AS Decimal(18, 2)), CAST(N'2019-01-01' AS Date), CAST(N'2019-12-31' AS Date))
INSERT [dbo].[AddOnFee] ([AddOnFeeId], [AddOnId], [Fee], [DateStart], [DateEnd]) VALUES (2, 2, CAST(25.00 AS Decimal(18, 2)), CAST(N'2019-01-01' AS Date), CAST(N'2019-12-31' AS Date))
INSERT [dbo].[AddOnFee] ([AddOnFeeId], [AddOnId], [Fee], [DateStart], [DateEnd]) VALUES (3, 3, CAST(50.00 AS Decimal(18, 2)), CAST(N'2019-01-01' AS Date), CAST(N'2019-12-31' AS Date))
INSERT [dbo].[AddOnFee] ([AddOnFeeId], [AddOnId], [Fee], [DateStart], [DateEnd]) VALUES (4, 4, CAST(5.00 AS Decimal(18, 2)), CAST(N'2019-01-01' AS Date), CAST(N'2019-12-31' AS Date))
INSERT [dbo].[AddOnFee] ([AddOnFeeId], [AddOnId], [Fee], [DateStart], [DateEnd]) VALUES (5, 5, CAST(15.00 AS Decimal(18, 2)), CAST(N'2019-01-01' AS Date), CAST(N'2019-12-31' AS Date))
INSERT [dbo].[AddOnFee] ([AddOnFeeId], [AddOnId], [Fee], [DateStart], [DateEnd]) VALUES (6, 6, CAST(12.00 AS Decimal(18, 2)), CAST(N'2019-01-01' AS Date), CAST(N'2019-12-31' AS Date))
SET IDENTITY_INSERT [dbo].[AddOnFee] OFF
SET IDENTITY_INSERT [dbo].[Amenity] ON 

INSERT [dbo].[Amenity] ([AmenityId], [AmenityDescription]) VALUES (1, N'Fridge')
INSERT [dbo].[Amenity] ([AmenityId], [AmenityDescription]) VALUES (2, N'Microwave')
INSERT [dbo].[Amenity] ([AmenityId], [AmenityDescription]) VALUES (3, N'Hot Tub')
INSERT [dbo].[Amenity] ([AmenityId], [AmenityDescription]) VALUES (4, N'Mini Bar')
INSERT [dbo].[Amenity] ([AmenityId], [AmenityDescription]) VALUES (5, N'Golden Toilet')
SET IDENTITY_INSERT [dbo].[Amenity] OFF
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([BillId], [ReservationId], [Total], [Tax], [Paid]) VALUES (1, 1, CAST(500 AS Decimal(18, 0)), CAST(30 AS Decimal(18, 0)), 0)
INSERT [dbo].[Bill] ([BillId], [ReservationId], [Total], [Tax], [Paid]) VALUES (2, 11, CAST(358 AS Decimal(18, 0)), CAST(32 AS Decimal(18, 0)), 1)
SET IDENTITY_INSERT [dbo].[Bill] OFF
SET IDENTITY_INSERT [dbo].[BillDetail] ON 

INSERT [dbo].[BillDetail] ([BillDetailId], [BillId], [AddOnId], [Charge], [Waived]) VALUES (1, 2, 1, CAST(10.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[BillDetail] ([BillDetailId], [BillId], [AddOnId], [Charge], [Waived]) VALUES (2, 2, 4, CAST(50.00 AS Decimal(18, 2)), 0)
SET IDENTITY_INSERT [dbo].[BillDetail] OFF
SET IDENTITY_INSERT [dbo].[BillPromo] ON 

INSERT [dbo].[BillPromo] ([BillPromoId], [BillId], [PromId]) VALUES (1, 1, 1)
SET IDENTITY_INSERT [dbo].[BillPromo] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Phone], [Email]) VALUES (1, N'Ryan', N'Richardson', N'5025551212', N'ryan@test.com')
INSERT [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Phone], [Email]) VALUES (3, N'Peter ', N'Griffin', N'5025558376', N'Peter@test.com')
INSERT [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Phone], [Email]) VALUES (4, N'Glenn', N'Quagmire', N'5025559988', N'Quagmire@test.com')
INSERT [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Phone], [Email]) VALUES (5, N'Brian', N'Griffin', N'5025551212', N'Brian@test.com')
INSERT [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Phone], [Email]) VALUES (6, N'Joe', N'Swanson', N'5025553333', N'Joe@test.com')
INSERT [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Phone], [Email]) VALUES (7, N'John', N'Herbert', N'5025554444', N'MrHerbert@test.com')
INSERT [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Phone], [Email]) VALUES (8, N'Mayor', N'West', N'5025555555', N'Mayor@test.com')
INSERT [dbo].[Customer] ([CustomerID], [FirstName], [LastName], [Phone], [Email]) VALUES (9, N'Megan', N'C', N'5027373737', N'Megan@Ford.com')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Fee] ON 

INSERT [dbo].[Fee] ([FeeId], [Fee], [StartDate], [EndDate]) VALUES (1, 10.0000, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-31' AS Date))
INSERT [dbo].[Fee] ([FeeId], [Fee], [StartDate], [EndDate]) VALUES (2, 20.0000, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-31' AS Date))
INSERT [dbo].[Fee] ([FeeId], [Fee], [StartDate], [EndDate]) VALUES (3, 50.0000, CAST(N'2019-02-14T00:00:00.000' AS DateTime), CAST(N'2019-02-14' AS Date))
INSERT [dbo].[Fee] ([FeeId], [Fee], [StartDate], [EndDate]) VALUES (4, 9.9900, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-04-01' AS Date))
SET IDENTITY_INSERT [dbo].[Fee] OFF
SET IDENTITY_INSERT [dbo].[Guest] ON 

INSERT [dbo].[Guest] ([GuestId], [GuestFirstName], [GuestLastName], [Age]) VALUES (1, N'Stewie', N'Griffin', 1)
INSERT [dbo].[Guest] ([GuestId], [GuestFirstName], [GuestLastName], [Age]) VALUES (2, N'Meg', N'Griffin', 16)
INSERT [dbo].[Guest] ([GuestId], [GuestFirstName], [GuestLastName], [Age]) VALUES (3, N'Chris', N'Griffin', 14)
INSERT [dbo].[Guest] ([GuestId], [GuestFirstName], [GuestLastName], [Age]) VALUES (4, N'Lois', N'Griffin', 40)
INSERT [dbo].[Guest] ([GuestId], [GuestFirstName], [GuestLastName], [Age]) VALUES (5, N'Cheryl', N'Tiegs', 50)
INSERT [dbo].[Guest] ([GuestId], [GuestFirstName], [GuestLastName], [Age]) VALUES (6, N'Jillian', N'Russell', 20)
INSERT [dbo].[Guest] ([GuestId], [GuestFirstName], [GuestLastName], [Age]) VALUES (7, N'Bonnie', N'Swanson', 50)
INSERT [dbo].[Guest] ([GuestId], [GuestFirstName], [GuestLastName], [Age]) VALUES (8, N'Carol', N'Pewterschmidt', 38)
INSERT [dbo].[Guest] ([GuestId], [GuestFirstName], [GuestLastName], [Age]) VALUES (9, N'Ryan', N'Richardson', 23)
INSERT [dbo].[Guest] ([GuestId], [GuestFirstName], [GuestLastName], [Age]) VALUES (10, N'Socks', N'Carfield', 2)
INSERT [dbo].[Guest] ([GuestId], [GuestFirstName], [GuestLastName], [Age]) VALUES (11, N'Milo', N'Carfield', 1)
SET IDENTITY_INSERT [dbo].[Guest] OFF
SET IDENTITY_INSERT [dbo].[Promo] ON 

INSERT [dbo].[Promo] ([PromoId], [PromoCode], [PromoDescription], [DateStart], [DateEnd], [PromoDiscount], [PromoType]) VALUES (1, N'15Off', N'15% Off', CAST(N'2019-02-01T00:00:00.000' AS DateTime), CAST(N'2019-02-28T00:00:00.000' AS DateTime), CAST(15 AS Decimal(18, 0)), N'P')
INSERT [dbo].[Promo] ([PromoId], [PromoCode], [PromoDescription], [DateStart], [DateEnd], [PromoDiscount], [PromoType]) VALUES (2, N'Heart20', N'$20 Off Nightly Rate', CAST(N'2019-02-14T00:00:00.000' AS DateTime), CAST(N'2019-02-15T00:00:00.000' AS DateTime), CAST(20 AS Decimal(18, 0)), N'F')
INSERT [dbo].[Promo] ([PromoId], [PromoCode], [PromoDescription], [DateStart], [DateEnd], [PromoDiscount], [PromoType]) VALUES (3, N'20Off', N'20% Off', CAST(N'2019-05-01T00:00:00.000' AS DateTime), CAST(N'2019-05-20T00:00:00.000' AS DateTime), CAST(20 AS Decimal(18, 0)), N'P')
INSERT [dbo].[Promo] ([PromoId], [PromoCode], [PromoDescription], [DateStart], [DateEnd], [PromoDiscount], [PromoType]) VALUES (5, N'50Off', N'50% Off', CAST(N'2019-03-01T00:00:00.000' AS DateTime), CAST(N'2019-03-15T00:00:00.000' AS DateTime), CAST(50 AS Decimal(18, 0)), N'P')
SET IDENTITY_INSERT [dbo].[Promo] OFF
SET IDENTITY_INSERT [dbo].[Rate] ON 

INSERT [dbo].[Rate] ([RateId], [Rate], [DateStart], [DateEnd]) VALUES (1, CAST(50 AS Decimal(18, 0)), CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-01-31T00:00:00.000' AS DateTime))
INSERT [dbo].[Rate] ([RateId], [Rate], [DateStart], [DateEnd]) VALUES (2, CAST(75 AS Decimal(18, 0)), CAST(N'2019-02-01T00:00:00.000' AS DateTime), CAST(N'2019-02-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Rate] ([RateId], [Rate], [DateStart], [DateEnd]) VALUES (3, CAST(100 AS Decimal(18, 0)), CAST(N'2019-03-01T00:00:00.000' AS DateTime), CAST(N'2019-05-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Rate] ([RateId], [Rate], [DateStart], [DateEnd]) VALUES (4, CAST(500 AS Decimal(18, 0)), CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-31T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Rate] OFF
SET IDENTITY_INSERT [dbo].[Reservation] ON 

INSERT [dbo].[Reservation] ([ReservationId], [CustomerId], [DateStart], [DateEnd]) VALUES (1, 1, CAST(N'2019-02-22' AS Date), CAST(N'2019-02-28' AS Date))
INSERT [dbo].[Reservation] ([ReservationId], [CustomerId], [DateStart], [DateEnd]) VALUES (2, 3, CAST(N'2019-01-01' AS Date), CAST(N'2019-02-27' AS Date))
INSERT [dbo].[Reservation] ([ReservationId], [CustomerId], [DateStart], [DateEnd]) VALUES (3, 4, CAST(N'2019-03-01' AS Date), CAST(N'2019-03-03' AS Date))
INSERT [dbo].[Reservation] ([ReservationId], [CustomerId], [DateStart], [DateEnd]) VALUES (4, 4, CAST(N'2019-03-15' AS Date), CAST(N'2019-03-22' AS Date))
INSERT [dbo].[Reservation] ([ReservationId], [CustomerId], [DateStart], [DateEnd]) VALUES (5, 6, CAST(N'2019-03-01' AS Date), CAST(N'2019-03-31' AS Date))
INSERT [dbo].[Reservation] ([ReservationId], [CustomerId], [DateStart], [DateEnd]) VALUES (6, 5, CAST(N'2019-02-23' AS Date), CAST(N'2019-02-26' AS Date))
INSERT [dbo].[Reservation] ([ReservationId], [CustomerId], [DateStart], [DateEnd]) VALUES (7, 7, CAST(N'2019-03-01' AS Date), CAST(N'2019-03-08' AS Date))
INSERT [dbo].[Reservation] ([ReservationId], [CustomerId], [DateStart], [DateEnd]) VALUES (8, 7, CAST(N'2019-03-15' AS Date), CAST(N'2019-03-18' AS Date))
INSERT [dbo].[Reservation] ([ReservationId], [CustomerId], [DateStart], [DateEnd]) VALUES (9, 7, CAST(N'2019-02-26' AS Date), CAST(N'2019-02-28' AS Date))
INSERT [dbo].[Reservation] ([ReservationId], [CustomerId], [DateStart], [DateEnd]) VALUES (10, 8, CAST(N'2019-02-14' AS Date), CAST(N'2019-02-15' AS Date))
INSERT [dbo].[Reservation] ([ReservationId], [CustomerId], [DateStart], [DateEnd]) VALUES (11, 9, CAST(N'2019-03-01' AS Date), CAST(N'2019-03-10' AS Date))
SET IDENTITY_INSERT [dbo].[Reservation] OFF
SET IDENTITY_INSERT [dbo].[ReservationGuest] ON 

INSERT [dbo].[ReservationGuest] ([ReservationGuestId], [ReservationId], [GuestId]) VALUES (1, 2, 1)
INSERT [dbo].[ReservationGuest] ([ReservationGuestId], [ReservationId], [GuestId]) VALUES (2, 2, 2)
INSERT [dbo].[ReservationGuest] ([ReservationGuestId], [ReservationId], [GuestId]) VALUES (3, 2, 3)
INSERT [dbo].[ReservationGuest] ([ReservationGuestId], [ReservationId], [GuestId]) VALUES (4, 2, 4)
INSERT [dbo].[ReservationGuest] ([ReservationGuestId], [ReservationId], [GuestId]) VALUES (5, 4, 5)
INSERT [dbo].[ReservationGuest] ([ReservationGuestId], [ReservationId], [GuestId]) VALUES (6, 4, 5)
INSERT [dbo].[ReservationGuest] ([ReservationGuestId], [ReservationId], [GuestId]) VALUES (7, 6, 6)
INSERT [dbo].[ReservationGuest] ([ReservationGuestId], [ReservationId], [GuestId]) VALUES (8, 5, 7)
INSERT [dbo].[ReservationGuest] ([ReservationGuestId], [ReservationId], [GuestId]) VALUES (9, 10, 8)
INSERT [dbo].[ReservationGuest] ([ReservationGuestId], [ReservationId], [GuestId]) VALUES (10, 11, 9)
INSERT [dbo].[ReservationGuest] ([ReservationGuestId], [ReservationId], [GuestId]) VALUES (11, 11, 10)
INSERT [dbo].[ReservationGuest] ([ReservationGuestId], [ReservationId], [GuestId]) VALUES (12, 11, 11)
SET IDENTITY_INSERT [dbo].[ReservationGuest] OFF
SET IDENTITY_INSERT [dbo].[ReservationPromo] ON 

INSERT [dbo].[ReservationPromo] ([ReservationPromoId], [ReservationId], [PromoId]) VALUES (1, 11, 5)
SET IDENTITY_INSERT [dbo].[ReservationPromo] OFF
SET IDENTITY_INSERT [dbo].[ReservationRoomType] ON 

INSERT [dbo].[ReservationRoomType] ([ReservationRoomTypeId], [ReservationId], [RoomTypeId], [DateStart], [DateEnd], [RoomId]) VALUES (1, 1, 1, CAST(N'2019-02-21' AS Date), CAST(N'2019-02-27' AS Date), 1)
INSERT [dbo].[ReservationRoomType] ([ReservationRoomTypeId], [ReservationId], [RoomTypeId], [DateStart], [DateEnd], [RoomId]) VALUES (2, 1, 2, CAST(N'2019-02-27' AS Date), CAST(N'2019-02-28' AS Date), 2)
INSERT [dbo].[ReservationRoomType] ([ReservationRoomTypeId], [ReservationId], [RoomTypeId], [DateStart], [DateEnd], [RoomId]) VALUES (12, 11, 2, CAST(N'2019-03-01' AS Date), CAST(N'2019-03-08' AS Date), 2)
INSERT [dbo].[ReservationRoomType] ([ReservationRoomTypeId], [ReservationId], [RoomTypeId], [DateStart], [DateEnd], [RoomId]) VALUES (13, 11, 1, CAST(N'2019-03-08' AS Date), CAST(N'2019-03-10' AS Date), 1)
INSERT [dbo].[ReservationRoomType] ([ReservationRoomTypeId], [ReservationId], [RoomTypeId], [DateStart], [DateEnd], [RoomId]) VALUES (14, 11, 2, CAST(N'2019-03-01' AS Date), CAST(N'2019-03-10' AS Date), 5)
SET IDENTITY_INSERT [dbo].[ReservationRoomType] OFF
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([RoomId], [RoomNumber], [FloorNumber], [OccupancyMax], [RoomTypeId]) VALUES (1, 101, 1, 1, 1)
INSERT [dbo].[Room] ([RoomId], [RoomNumber], [FloorNumber], [OccupancyMax], [RoomTypeId]) VALUES (2, 202, 2, 2, 2)
INSERT [dbo].[Room] ([RoomId], [RoomNumber], [FloorNumber], [OccupancyMax], [RoomTypeId]) VALUES (3, 303, 3, 3, 3)
INSERT [dbo].[Room] ([RoomId], [RoomNumber], [FloorNumber], [OccupancyMax], [RoomTypeId]) VALUES (4, 404, 4, 4, 4)
INSERT [dbo].[Room] ([RoomId], [RoomNumber], [FloorNumber], [OccupancyMax], [RoomTypeId]) VALUES (5, 102, 1, 2, 2)
SET IDENTITY_INSERT [dbo].[Room] OFF
SET IDENTITY_INSERT [dbo].[RoomAmenity] ON 

INSERT [dbo].[RoomAmenity] ([RoomAmenityId], [RoomId], [AmenityId]) VALUES (1, 1, 1)
INSERT [dbo].[RoomAmenity] ([RoomAmenityId], [RoomId], [AmenityId]) VALUES (2, 1, 2)
INSERT [dbo].[RoomAmenity] ([RoomAmenityId], [RoomId], [AmenityId]) VALUES (3, 2, 1)
INSERT [dbo].[RoomAmenity] ([RoomAmenityId], [RoomId], [AmenityId]) VALUES (4, 2, 2)
INSERT [dbo].[RoomAmenity] ([RoomAmenityId], [RoomId], [AmenityId]) VALUES (5, 2, 3)
INSERT [dbo].[RoomAmenity] ([RoomAmenityId], [RoomId], [AmenityId]) VALUES (6, 3, 1)
INSERT [dbo].[RoomAmenity] ([RoomAmenityId], [RoomId], [AmenityId]) VALUES (7, 3, 2)
INSERT [dbo].[RoomAmenity] ([RoomAmenityId], [RoomId], [AmenityId]) VALUES (8, 3, 3)
INSERT [dbo].[RoomAmenity] ([RoomAmenityId], [RoomId], [AmenityId]) VALUES (9, 4, 1)
INSERT [dbo].[RoomAmenity] ([RoomAmenityId], [RoomId], [AmenityId]) VALUES (10, 4, 2)
INSERT [dbo].[RoomAmenity] ([RoomAmenityId], [RoomId], [AmenityId]) VALUES (11, 4, 3)
INSERT [dbo].[RoomAmenity] ([RoomAmenityId], [RoomId], [AmenityId]) VALUES (12, 4, 4)
SET IDENTITY_INSERT [dbo].[RoomAmenity] OFF
SET IDENTITY_INSERT [dbo].[RoomType] ON 

INSERT [dbo].[RoomType] ([RoomTypeId], [RoomTypeDescription]) VALUES (1, N'Single')
INSERT [dbo].[RoomType] ([RoomTypeId], [RoomTypeDescription]) VALUES (2, N'Double')
INSERT [dbo].[RoomType] ([RoomTypeId], [RoomTypeDescription]) VALUES (3, N'Suite')
INSERT [dbo].[RoomType] ([RoomTypeId], [RoomTypeDescription]) VALUES (4, N'Penthouse')
SET IDENTITY_INSERT [dbo].[RoomType] OFF
SET IDENTITY_INSERT [dbo].[RoomTypeRate] ON 

INSERT [dbo].[RoomTypeRate] ([RoomTypeRateId], [RoomTypeId], [RateId]) VALUES (1, 1, 1)
INSERT [dbo].[RoomTypeRate] ([RoomTypeRateId], [RoomTypeId], [RateId]) VALUES (2, 1, 2)
INSERT [dbo].[RoomTypeRate] ([RoomTypeRateId], [RoomTypeId], [RateId]) VALUES (3, 1, 3)
INSERT [dbo].[RoomTypeRate] ([RoomTypeRateId], [RoomTypeId], [RateId]) VALUES (4, 2, 1)
INSERT [dbo].[RoomTypeRate] ([RoomTypeRateId], [RoomTypeId], [RateId]) VALUES (5, 2, 2)
INSERT [dbo].[RoomTypeRate] ([RoomTypeRateId], [RoomTypeId], [RateId]) VALUES (6, 2, 3)
INSERT [dbo].[RoomTypeRate] ([RoomTypeRateId], [RoomTypeId], [RateId]) VALUES (7, 4, 4)
SET IDENTITY_INSERT [dbo].[RoomTypeRate] OFF
ALTER TABLE [dbo].[AddOnFee]  WITH CHECK ADD  CONSTRAINT [FK_AddOnFee_AddOn] FOREIGN KEY([AddOnId])
REFERENCES [dbo].[AddOn] ([AddOnId])
GO
ALTER TABLE [dbo].[AddOnFee] CHECK CONSTRAINT [FK_AddOnFee_AddOn]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Reservation1] FOREIGN KEY([ReservationId])
REFERENCES [dbo].[Reservation] ([ReservationId])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Reservation1]
GO
ALTER TABLE [dbo].[BillDetail]  WITH CHECK ADD  CONSTRAINT [FK_BillDetail_AddOn] FOREIGN KEY([AddOnId])
REFERENCES [dbo].[AddOn] ([AddOnId])
GO
ALTER TABLE [dbo].[BillDetail] CHECK CONSTRAINT [FK_BillDetail_AddOn]
GO
ALTER TABLE [dbo].[BillDetail]  WITH CHECK ADD  CONSTRAINT [FK_BillDetail_Bill] FOREIGN KEY([BillId])
REFERENCES [dbo].[Bill] ([BillId])
GO
ALTER TABLE [dbo].[BillDetail] CHECK CONSTRAINT [FK_BillDetail_Bill]
GO
ALTER TABLE [dbo].[BillPromo]  WITH CHECK ADD  CONSTRAINT [FK_BillPromo_Bill] FOREIGN KEY([BillId])
REFERENCES [dbo].[Bill] ([BillId])
GO
ALTER TABLE [dbo].[BillPromo] CHECK CONSTRAINT [FK_BillPromo_Bill]
GO
ALTER TABLE [dbo].[BillPromo]  WITH CHECK ADD  CONSTRAINT [FK_BillPromo_Promo] FOREIGN KEY([PromId])
REFERENCES [dbo].[Promo] ([PromoId])
GO
ALTER TABLE [dbo].[BillPromo] CHECK CONSTRAINT [FK_BillPromo_Promo]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Customer]
GO
ALTER TABLE [dbo].[ReservationGuest]  WITH CHECK ADD  CONSTRAINT [FK_ReservationGuest_Guest] FOREIGN KEY([GuestId])
REFERENCES [dbo].[Guest] ([GuestId])
GO
ALTER TABLE [dbo].[ReservationGuest] CHECK CONSTRAINT [FK_ReservationGuest_Guest]
GO
ALTER TABLE [dbo].[ReservationGuest]  WITH CHECK ADD  CONSTRAINT [FK_ReservationGuest_Reservation] FOREIGN KEY([ReservationId])
REFERENCES [dbo].[Reservation] ([ReservationId])
GO
ALTER TABLE [dbo].[ReservationGuest] CHECK CONSTRAINT [FK_ReservationGuest_Reservation]
GO
ALTER TABLE [dbo].[ReservationPromo]  WITH CHECK ADD  CONSTRAINT [FK_ReservationPromo_Promo] FOREIGN KEY([PromoId])
REFERENCES [dbo].[Promo] ([PromoId])
GO
ALTER TABLE [dbo].[ReservationPromo] CHECK CONSTRAINT [FK_ReservationPromo_Promo]
GO
ALTER TABLE [dbo].[ReservationPromo]  WITH CHECK ADD  CONSTRAINT [FK_ReservationPromo_Reservation] FOREIGN KEY([ReservationId])
REFERENCES [dbo].[Reservation] ([ReservationId])
GO
ALTER TABLE [dbo].[ReservationPromo] CHECK CONSTRAINT [FK_ReservationPromo_Reservation]
GO
ALTER TABLE [dbo].[ReservationRoomType]  WITH CHECK ADD  CONSTRAINT [FK_ReservationRoom_Reservation] FOREIGN KEY([ReservationId])
REFERENCES [dbo].[Reservation] ([ReservationId])
GO
ALTER TABLE [dbo].[ReservationRoomType] CHECK CONSTRAINT [FK_ReservationRoom_Reservation]
GO
ALTER TABLE [dbo].[ReservationRoomType]  WITH CHECK ADD  CONSTRAINT [FK_ReservationRoomType_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([RoomId])
GO
ALTER TABLE [dbo].[ReservationRoomType] CHECK CONSTRAINT [FK_ReservationRoomType_Room]
GO
ALTER TABLE [dbo].[ReservationRoomType]  WITH CHECK ADD  CONSTRAINT [FK_ReservationRoomType_RoomType] FOREIGN KEY([RoomTypeId])
REFERENCES [dbo].[RoomType] ([RoomTypeId])
GO
ALTER TABLE [dbo].[ReservationRoomType] CHECK CONSTRAINT [FK_ReservationRoomType_RoomType]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomType] FOREIGN KEY([RoomTypeId])
REFERENCES [dbo].[RoomType] ([RoomTypeId])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_RoomType]
GO
ALTER TABLE [dbo].[RoomAmenity]  WITH CHECK ADD  CONSTRAINT [FK_RoomAmenity_Amenity] FOREIGN KEY([AmenityId])
REFERENCES [dbo].[Amenity] ([AmenityId])
GO
ALTER TABLE [dbo].[RoomAmenity] CHECK CONSTRAINT [FK_RoomAmenity_Amenity]
GO
ALTER TABLE [dbo].[RoomAmenity]  WITH CHECK ADD  CONSTRAINT [FK_RoomAmenity_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([RoomId])
GO
ALTER TABLE [dbo].[RoomAmenity] CHECK CONSTRAINT [FK_RoomAmenity_Room]
GO
ALTER TABLE [dbo].[RoomTypeRate]  WITH CHECK ADD  CONSTRAINT [FK_RoomRate_Rate] FOREIGN KEY([RateId])
REFERENCES [dbo].[Rate] ([RateId])
GO
ALTER TABLE [dbo].[RoomTypeRate] CHECK CONSTRAINT [FK_RoomRate_Rate]
GO
ALTER TABLE [dbo].[RoomTypeRate]  WITH CHECK ADD  CONSTRAINT [FK_RoomTypeRate_RoomType] FOREIGN KEY([RoomTypeId])
REFERENCES [dbo].[RoomType] ([RoomTypeId])
GO
ALTER TABLE [dbo].[RoomTypeRate] CHECK CONSTRAINT [FK_RoomTypeRate_RoomType]
GO
USE [master]
GO
ALTER DATABASE [HotelReservations] SET  READ_WRITE 
GO
