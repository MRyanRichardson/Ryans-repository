use DVDLibrary2
/*creating server login*/
create login DvdLibraryApp with password = 'Testing123'
go
/*creating user*/
create user DvdLibraryApp for login DvdLibraryApp
go
/*grant permissions to Execute on each stored procedure*/
grant execute on DVDDelete To DvdLibraryApp
grant execute on DVDEdit To DvdLibraryApp
grant execute on DVDInsert To DvdLibraryApp
grant execute on DVDSelectByDirector To DvdLibraryApp
grant execute on DVDSelectById To DvdLibraryApp
grant execute on DVDSelectByRating To DvdLibraryApp
grant execute on DVDSelectByreleaseYear To DvdLibraryApp
grant execute on DVDSelectByTitle To DvdLibraryApp
go

/*Grant User to be able to crud director table*/
grant select on Directors to DvdLibraryApp
grant insert on Directors to DvdLibraryApp
grant update on Directors to DvdLibraryApp
grant delete on Directors to DvdLibraryApp

/*Grant User to be able to crud DVD table*/
grant select on DVDs to DvdLibraryApp
grant insert on DVDs to DvdLibraryApp
grant update on DVDs to DvdLibraryApp
grant delete on DVDs to DvdLibraryApp

/*Grant User to be able to crud Rating table*/
grant select on Ratings to DvdLibraryApp
grant insert on Ratings to DvdLibraryApp
grant update on Ratings to DvdLibraryApp
grant delete on Ratings to DvdLibraryApp




use DVDLibrary3
/*creating server login*/
create login DvdLibraryApp with password = 'Testing123'
go
/*creating user*/
create user DvdLibraryApp for login DvdLibraryApp
go


/*Grant User to be able to crud director table*/
grant select on Directors to DvdLibraryApp
grant insert on Directors to DvdLibraryApp
grant update on Directors to DvdLibraryApp
grant delete on Directors to DvdLibraryApp

/*Grant User to be able to crud DVD table*/
grant select on DVDs to DvdLibraryApp
grant insert on DVDs to DvdLibraryApp
grant update on DVDs to DvdLibraryApp
grant delete on DVDs to DvdLibraryApp

/*Grant User to be able to crud Rating table*/
grant select on Ratings to DvdLibraryApp
grant insert on Ratings to DvdLibraryApp
grant update on Ratings to DvdLibraryApp
grant delete on Ratings to DvdLibraryApp