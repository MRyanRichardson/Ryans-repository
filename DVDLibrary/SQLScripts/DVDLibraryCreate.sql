
USE [master]
GO

/****** Object:  Database [DVDLibrary2]    Script Date: 3/19/2019 6:49:40 AM ******/
CREATE DATABASE [DVDLibrary2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DVDLibrary2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.DLR\MSSQL\DATA\DVDLibrary2.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DVDLibrary2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.DLR\MSSQL\DATA\DVDLibrary2_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO



USE [DVDLibrary2]
GO

GO
/****** Object:  Table [dbo].[Directors]    Script Date: 3/19/2019 6:48:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Directors](
	[DirectorId] [int] IDENTITY(1,1) NOT NULL,
	[DirectorName] [varchar](50) NULL,
 CONSTRAINT [PK_Director] PRIMARY KEY CLUSTERED 
(
	[DirectorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DVDs]    Script Date: 3/19/2019 6:48:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DVDs](
	[DvdId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[RealeaseYear] [int] NOT NULL,
	[Notes] [varchar](50) NULL,
	[RatingID] [int] NOT NULL,
	[DirectorID] [int] NOT NULL,
 CONSTRAINT [PK_dvdID] PRIMARY KEY CLUSTERED 
(
	[DvdId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 3/19/2019 6:48:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ratings](
	[RatingId] [int] IDENTITY(1,1) NOT NULL,
	[RatingName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Rating] PRIMARY KEY CLUSTERED 
(
	[RatingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET IDENTITY_INSERT [dbo].[Ratings] OFF
GO
ALTER TABLE [dbo].[DVDs]  WITH CHECK ADD  CONSTRAINT [FK_DVDs_Directors] FOREIGN KEY([DirectorID])
REFERENCES [dbo].[Directors] ([DirectorId])
GO
ALTER TABLE [dbo].[DVDs] CHECK CONSTRAINT [FK_DVDs_Directors]
GO
ALTER TABLE [dbo].[DVDs]  WITH CHECK ADD  CONSTRAINT [FK_DVDs_Ratings] FOREIGN KEY([RatingID])
REFERENCES [dbo].[Ratings] ([RatingId])
GO
ALTER TABLE [dbo].[DVDs] CHECK CONSTRAINT [FK_DVDs_Ratings]
GO



---  DVDLibrary3



USE [master]
GO

/****** Object:  Database [DVDLibrary3]    Script Date: 3/19/2019 6:49:40 AM ******/
CREATE DATABASE [DVDLibrary3]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DVDLibrary3', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.DLR\MSSQL\DATA\DVDLibrary3.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DVDLibrary3_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.DLR\MSSQL\DATA\DVDLibrary3_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

USE [DVDLibrary3]
GO

/****** Object:  Table [dbo].[Ratings]    Script Date: 3/20/2019 11:43:23 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Ratings](
	[RatingId] [int] IDENTITY(1,1) NOT NULL,
	[RatingName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Ratings] PRIMARY KEY CLUSTERED 
(
	[RatingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[DVDs]    Script Date: 3/20/2019 11:43:23 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DVDs](
	[dvdId] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](max) NULL,
	[realeaseYear] [int] NOT NULL,
	[notes] [nvarchar](max) NULL,
	[RatingId] [int] NOT NULL,
	[DirectorId] [int] NOT NULL,
	[director] [nvarchar](max) NULL,
	[rating] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.DVDs] PRIMARY KEY CLUSTERED 
(
	[dvdId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Directors]    Script Date: 3/20/2019 11:43:23 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Directors](
	[DirectorId] [int] IDENTITY(1,1) NOT NULL,
	[DirectorName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Directors] PRIMARY KEY CLUSTERED 
(
	[DirectorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[DVDs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DVDs_dbo.Directors_DirectorId] FOREIGN KEY([DirectorId])
REFERENCES [dbo].[Directors] ([DirectorId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[DVDs] CHECK CONSTRAINT [FK_dbo.DVDs_dbo.Directors_DirectorId]
GO

ALTER TABLE [dbo].[DVDs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DVDs_dbo.Ratings_RatingId] FOREIGN KEY([RatingId])
REFERENCES [dbo].[Ratings] ([RatingId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[DVDs] CHECK CONSTRAINT [FK_dbo.DVDs_dbo.Ratings_RatingId]
GO


