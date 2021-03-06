USE [DVDLibrary2]
GO
SET IDENTITY_INSERT [dbo].[Directors] ON 

GO
INSERT [dbo].[Directors] ([DirectorId], [DirectorName]) VALUES (1, N'Ivan Reitman')
GO
INSERT [dbo].[Directors] ([DirectorId], [DirectorName]) VALUES (2, N'Terry  Gilliam')
GO
INSERT [dbo].[Directors] ([DirectorId], [DirectorName]) VALUES (3, N'Dennis Dugan')
GO
INSERT [dbo].[Directors] ([DirectorId], [DirectorName]) VALUES (4, N'Steven Spielberg')
GO
INSERT [dbo].[Directors] ([DirectorId], [DirectorName]) VALUES (5, N'John  Lasseter')
GO
INSERT [dbo].[Directors] ([DirectorId], [DirectorName]) VALUES (6, N'Terry Jones')
GO
SET IDENTITY_INSERT [dbo].[Directors] OFF
GO
SET IDENTITY_INSERT [dbo].[Ratings] ON 

GO
INSERT [dbo].[Ratings] ([RatingId], [RatingName]) VALUES (1, N'G')
GO
INSERT [dbo].[Ratings] ([RatingId], [RatingName]) VALUES (2, N'PG')
GO
INSERT [dbo].[Ratings] ([RatingId], [RatingName]) VALUES (3, N'PG-13')
GO
INSERT [dbo].[Ratings] ([RatingId], [RatingName]) VALUES (4, N'R')
GO
SET IDENTITY_INSERT [dbo].[Ratings] OFF
GO
SET IDENTITY_INSERT [dbo].[DVDs] ON 

GO
INSERT [dbo].[DVDs] ([DvdId], [Title], [RealeaseYear], [Notes], [RatingID], [DirectorID]) VALUES (2, N'Monte Python and the Holy Grail', 1975, N'Lobbest though the holy hand grenade', 2, 2)
GO
INSERT [dbo].[DVDs] ([DvdId], [Title], [RealeaseYear], [Notes], [RatingID], [DirectorID]) VALUES (3, N'Happy Gilmore', 1996, N'The price is wrong', 3, 3)
GO
INSERT [dbo].[DVDs] ([DvdId], [Title], [RealeaseYear], [Notes], [RatingID], [DirectorID]) VALUES (4, N'Raider Of The Lost Ark', 1981, NULL, 2, 4)
GO
INSERT [dbo].[DVDs] ([DvdId], [Title], [RealeaseYear], [Notes], [RatingID], [DirectorID]) VALUES (5, N'Toy Story', 1995, N'Youve got a friend in me.', 1, 5)
GO
INSERT [dbo].[DVDs] ([DvdId], [Title], [RealeaseYear], [Notes], [RatingID], [DirectorID]) VALUES (6, N'Life Of Brian', 1970, NULL, 4, 6)
GO

SET IDENTITY_INSERT [dbo].[DVDs] OFF
GO

USE [DVDLibrary3]
GO
SET IDENTITY_INSERT [dbo].[Directors] ON 

GO
INSERT [dbo].[Directors] ([DirectorId], [DirectorName]) VALUES (2, N'Terry  Gilliam')
GO
INSERT [dbo].[Directors] ([DirectorId], [DirectorName]) VALUES (3, N'Dennis Dugan')
GO
INSERT [dbo].[Directors] ([DirectorId], [DirectorName]) VALUES (4, N'Steven Spielberg')
GO
INSERT [dbo].[Directors] ([DirectorId], [DirectorName]) VALUES (5, N'John  Lasseter')
GO
INSERT [dbo].[Directors] ([DirectorId], [DirectorName]) VALUES (6, N'Terry Jones')
GO
INSERT [dbo].[Directors] ([DirectorId], [DirectorName]) VALUES (14, N'Ivan Reitman')
GO
SET IDENTITY_INSERT [dbo].[Directors] OFF
GO
SET IDENTITY_INSERT [dbo].[Ratings] ON 

GO
INSERT [dbo].[Ratings] ([RatingId], [RatingName]) VALUES (1, N'G')
GO
INSERT [dbo].[Ratings] ([RatingId], [RatingName]) VALUES (2, N'PG')
GO
INSERT [dbo].[Ratings] ([RatingId], [RatingName]) VALUES (3, N'PG-13')
GO
INSERT [dbo].[Ratings] ([RatingId], [RatingName]) VALUES (4, N'R')
GO
INSERT [dbo].[Ratings] ([RatingId], [RatingName]) VALUES (5, N'test2')
GO
INSERT [dbo].[Ratings] ([RatingId], [RatingName]) VALUES (6, N'R')
GO
INSERT [dbo].[Ratings] ([RatingId], [RatingName]) VALUES (7, N'PG')
GO
INSERT [dbo].[Ratings] ([RatingId], [RatingName]) VALUES (8, N'R')
GO
SET IDENTITY_INSERT [dbo].[Ratings] OFF
GO
SET IDENTITY_INSERT [dbo].[DVDs] ON 

GO
INSERT [dbo].[DVDs] ([dvdId], [title], [realeaseYear], [notes], [RatingId], [DirectorId], [director], [rating]) VALUES (2, N'Monte Python and Holy Grail', 1975, N'Lobbest though the holy hand grenade', 2, 2, N'Terry  Gilliam', N'PG')
GO
INSERT [dbo].[DVDs] ([dvdId], [title], [realeaseYear], [notes], [RatingId], [DirectorId], [director], [rating]) VALUES (3, N'Happy Gilmore', 1996, N'The price is wrong', 3, 3, N'Dennis Dugan', N'PG-13')
GO
INSERT [dbo].[DVDs] ([dvdId], [title], [realeaseYear], [notes], [RatingId], [DirectorId], [director], [rating]) VALUES (4, N'Raiders Of The Lost Ark', 1981, N'Epic tale in which an intrepid archaeologist tries to beat a band of Nazis to a unique religious relic which is central to their plans for world domination. Battling against a snake phobia and a vengeful ex-girlfriend, Indiana Jones is in constant peril, making hair''s-breadth escapes at every turn in this celebration of the innocent adventure movies of an earlier era.', 2, 4, N'Steven Spielberg', N'PG')
GO
INSERT [dbo].[DVDs] ([dvdId], [title], [realeaseYear], [notes], [RatingId], [DirectorId], [director], [rating]) VALUES (5, N'Toy Story', 1995, N'Youve got a friend in me.', 1, 5, N'John  Lasseter', N'G')
GO
INSERT [dbo].[DVDs] ([dvdId], [title], [realeaseYear], [notes], [RatingId], [DirectorId], [director], [rating]) VALUES (6, N'Life Of Brian', 1970, N'You are the Messiah, I should know, I''ve followed a few.', 4, 6, N'Terry Jones', N'R')
GO
SET IDENTITY_INSERT [dbo].[DVDs] OFF
GO
