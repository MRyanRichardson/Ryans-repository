USE [DVDLibrary2]
GO

/****** Object:  StoredProcedure [dbo].[DVDDelete]    Script Date: 3/19/2019 6:52:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DVDDelete]

@DvdId int
as

delete from DVDs

where DvdId = @DvdId

GO

/****** Object:  StoredProcedure [dbo].[DVDEdit]    Script Date: 3/19/2019 6:52:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DVDEdit]
(@DvdId int,
@title varchar(50),
@releaseYear int,
@DirectorName varchar(50),
@RatingName Varchar(50),
@notes varchar(50))
as
declare @DirectorId int
declare @RatingId int
if exists(select * from Directors where DirectorName = @DirectorName)
begin
		set @DirectorId = (select DirectorId from Directors where DirectorName = @DirectorName)
end
else
begin
		insert into Directors values(@DirectorName)
		set @DirectorId = SCOPE_IDENTITY()
end	
if exists(select * from Ratings where RatingName = @RatingName)
begin
		set @RatingId = (select RatingId from Ratings where RatingName = @RatingName)
end
else
begin
		insert into Ratings values(@RatingName)
		set @RatingId = SCOPE_IDENTITY()
end	
update DVDs
set title = @title,
realeaseYear = @releaseYear,
notes = @notes,
ratingId = @ratingId,
directorId = @DirectorId
where DvdId = @DvdId


SELECT        d.title, d.realeaseYear, di.DirectorName, r.RatingName, d.DvdId, d.RatingID, d.DirectorID, d.notes
FROM            DVDs AS d LEFT JOIN
                         Directors AS di ON d.DirectorID = di.DirectorId LEFT JOIN
                         Ratings AS r ON d.RatingID = r.RatingId
WHERE d.DvdId = @DvdId

GO

/****** Object:  StoredProcedure [dbo].[DVDInsert]    Script Date: 3/19/2019 6:52:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DVDInsert]
(@title varchar(50),
@releaseYear int,
@DirectorName varchar(50),
@RatingName varchar(50),
@notes varchar(50),
@Identity int Out )
as
declare @DirectorId int
declare @RatingId int
if exists(select * from Directors where DirectorName = @DirectorName)
begin
		set @DirectorId = (select DirectorId from Directors where DirectorName = @DirectorName)
end
else
begin
		insert into Directors values(@DirectorName)
		set @DirectorId = SCOPE_IDENTITY()
end	
if exists(select * from Ratings where RatingName = @RatingName)
begin

		set @RatingId = (select RatingId from Ratings where RatingName = @RatingName)
end
else
begin
		insert into Ratings values(@RatingName)
		set @RatingId = SCOPE_IDENTITY()
end	
insert into DVDs
values
(@title,
@releaseYear,
@notes,
@RatingId,
@DirectorId
)

SELECT        d.dvdid,d.title, d.realeaseYear, di.DirectorName, r.RatingName, d.DvdId, d.RatingID, d.DirectorID, d.notes
FROM            DVDs AS d LEFT JOIN
                         Directors AS di ON d.DirectorID = di.DirectorId LEFT JOIN
                         Ratings AS r ON d.RatingID = r.RatingId
where d.dvdid = SCOPE_IDENTITY();


GO

/****** Object:  StoredProcedure [dbo].[DVDSelectByDirector]    Script Date: 3/19/2019 6:52:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DVDSelectByDirector]
@DirectorName varchar(50)
as


SELECT        d.title, d.realeaseYear, di.DirectorName, r.RatingName, d.DvdId, d.RatingID, d.DirectorID, d.notes
FROM            DVDs AS d LEFT JOIN
                         Directors AS di ON d.DirectorID = di.DirectorId LEFT JOIN
                         Ratings AS r ON d.RatingID = r.RatingId
where DirectorName like '%' + @DirectorName + '%'

GO

/****** Object:  StoredProcedure [dbo].[DVDSelectById]    Script Date: 3/19/2019 6:52:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DVDSelectById]
@DvdId int = 0
as
if @DvdId = 0 
begin
--if zero i am going to run query without a where clause
SELECT        d.title, d.realeaseYear, di.DirectorName, r.RatingName, d.DvdId, d.RatingID, d.DirectorID,d.Notes
FROM            DVDs AS d LEFT JOIN
                         Directors AS di ON d.DirectorID = di.DirectorId LEFT JOIN
                         Ratings AS r ON d.RatingID = r.RatingId
end
else
begin

SELECT        d.title, d.realeaseYear, di.DirectorName, r.RatingName, d.DvdId, d.RatingID, d.DirectorID,d.Notes
FROM            DVDs AS d LEFT JOIN
                         Directors AS di ON d.DirectorID = di.DirectorId LEFT JOIN
                         Ratings AS r ON d.RatingID = r.RatingId
where DvdId = @DvdId
end


GO

/****** Object:  StoredProcedure [dbo].[DVDSelectByRating]    Script Date: 3/19/2019 6:52:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DVDSelectByRating]
@ratingName varchar(50)
as
SELECT        d.title, d.realeaseYear, di.DirectorName, r.RatingName, d.DvdId, d.RatingID, d.DirectorID, d.notes
FROM            DVDs AS d LEFT JOIN
                         Directors AS di ON d.DirectorID = di.DirectorId LEFT JOIN
                         Ratings AS r ON d.RatingID = r.RatingId
where RatingName = @ratingName

GO

/****** Object:  StoredProcedure [dbo].[DVDSelectByreleaseYear]    Script Date: 3/19/2019 6:52:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DVDSelectByreleaseYear]
@releaseYear int
as


SELECT        d.title, d.realeaseYear, di.DirectorName, r.RatingName, d.DvdId, d.RatingID, d.DirectorID, d.Notes
FROM            DVDs AS d LEFT JOIN
                         Directors AS di ON d.DirectorID = di.DirectorId LEFT JOIN
                         Ratings AS r ON d.RatingID = r.RatingId
where realeaseYear = @releaseYear

GO

/****** Object:  StoredProcedure [dbo].[DVDSelectByTitle]    Script Date: 3/19/2019 6:52:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DVDSelectByTitle]
@title varchar(50)
as


SELECT        d.title, d.realeaseYear, di.DirectorName, r.RatingName, d.DvdId, d.RatingID, d.DirectorID, d.notes
FROM            DVDs AS d LEFT JOIN
                         Directors AS di ON d.DirectorID = di.DirectorId LEFT JOIN
                         Ratings AS r ON d.RatingID = r.RatingId
where title like '%'+@title+'%'

GO


