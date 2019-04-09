use HotelReservations
go
----------------------------------------------------------------------------------------------
-- #1  Write a query that returns a list of reservations that end tomorrow.
--     bonus: that also don't have a bill issued
----------------------------------------------------------------------------------------------
SELECT * 
FROM   reservation 
WHERE  dateend = CONVERT(DATE, Dateadd(day, 1, Getdate())) 

-- Bonus 
SELECT * 
FROM   reservation 
       LEFT JOIN bill 
              ON reservation.reservationid = bill.reservationid 
WHERE  dateend = CONVERT(DATE, Dateadd(day, 1, Getdate())) 
       AND billid IS NULL 

----------------------------------------------------------------------------------------------
-- #2	Write a query that returns all the rooms reserved for a particular customer.
--		bonus: instead query based on promotional code
----------------------------------------------------------------------------------------------
SELECT        Customer.FirstName, Customer.LastName, Room.RoomNumber,customer.customerID 
FROM            Customer INNER JOIN
                         Reservation ON Customer.CustomerID = Reservation.CustomerId 
						 INNER JOIN
                         ReservationRoomType ON Reservation.ReservationId = ReservationRoomType.ReservationId 
						 INNER JOIN
                         Room ON ReservationRoomType.RoomId = Room.RoomId
WHERE customer.customerID = 9
----------------------------------------------------------------------------------------------
-- #3	Write a query that returns rooms that do not contain a specific amenity.
--		bonus: also order by cheapest & not reserved
----------------------------------------------------------------------------------------------
SELECT roomnumber 
FROM   room 
WHERE  ( roomid NOT IN (SELECT r.roomid 
                        FROM   room AS r 
                               INNER JOIN roomamenity AS ra 
                                       ON ra.roomid = r.roomid 
                               INNER JOIN amenity AS a 
                                       ON a.amenityid = ra.amenityid 
                        WHERE  ( a.amenityid = 4 )) ) 

----------------------------------------------------------------------------------------------
-- #4	Write a query that returns all the rooms available for a date range.
--		bonus: allow me to also specify room type
----------------------------------------------------------------------------------------------
DECLARE @startDate DATE = '2/10/2019' 
DECLARE @endDate DATE = '2/15/2019' 

SELECT DISTINCT rm.roomnumber 
FROM   reservation r 
       INNER JOIN reservationroomtype ra 
               ON ra.reservationid = r.reservationid 
       INNER JOIN room rm 
               ON rm.roomid = ra.roomid 
			   inner join RoomType rt on rt.RoomTypeId = rm.RoomTypeId
WHERE  r.datestart NOT BETWEEN @startDate AND @EndDate 
       AND r.dateend NOT BETWEEN @startDate AND @EndDate 
GO

--Bonus 
DECLARE @startDate DATE = '2/10/2019' 
DECLARE @endDate DATE = '2/15/2019' 
DECLARE @RoomType varchar(50) = 'Double'
SELECT DISTINCT rm.roomnumber 
FROM   reservation r 
       INNER JOIN reservationroomtype ra 
               ON ra.reservationid = r.reservationid 
       INNER JOIN room rm 
               ON rm.roomid = ra.roomid 
       INNER JOIN roomtype rt 
               ON rt.roomtypeid = rm.roomtypeid 
WHERE  r.DateStart NOT BETWEEN @startDate AND @EndDate 
       AND r.DateEnd NOT BETWEEN @startDate AND @EndDate 
	   AND rt.RoomTypeDescription = @RoomType
GO


