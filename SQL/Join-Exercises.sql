USE PersonalTrainer
GO

-- Select all columns from ExerciseCategory and Exercise.
-- The tables should be joined on ExerciseCategoryId.
-- This query returns all Exercises and their associated ExerciseCategory.
-- 64 rows
--------------------
select * from exercise e
inner join ExerciseCategory ec on e.ExerciseCategoryId = ec.ExerciseCategoryId
    
-- Select ExerciseCategory.Name and Exercise.Name
-- where the ExerciseCategory does not have a ParentCategoryId (it is null).
-- Again, join the tables on their shared key (ExerciseCategoryId).
-- 9 rows
--------------------
select * from exercise e
inner join ExerciseCategory ec on e.ExerciseCategoryId = ec.ExerciseCategoryId
where ec.ParentCategoryId is null


-- The query above is a little confusing. At first glance, it's hard to tell
-- which Name belongs to ExerciseCategory and which belongs to Exercise.
-- Rewrite the query using an aliases. 
-- Alias ExerciseCategory.Name as 'CategoryName'.
-- Alias Exercise.Name as 'ExerciseName'.
-- 9 rows
---select * from exercise e
SELECT        e.ExerciseId, e.Name AS ExerciseName, e.ExerciseCategoryId, ec.ExerciseCategoryId AS CategoryName, ec.Name AS Expr2, ec.ParentCategoryId
FROM            Exercise AS e INNER JOIN
                         ExerciseCategory AS ec ON e.ExerciseCategoryId = ec.ExerciseCategoryId
WHERE        (ec.ParentCategoryId IS NULL)

-- Select FirstName, LastName, and BirthDate from Client
-- and EmailAddress from Login 
-- where Client.BirthDate is in the 1990s.
-- Join the tables by their key relationship. 
-- What is the primary-foreign key relationship?
-- 35 rows
--------------------
select * from client c
inner join login l on c.ClientId=l.clientid
where BirthDate between '01/01/1990' and '01/01/2000'
		-- relationship is 1 to 1




-- Select Workout.Name, Client.FirstName, and Client.LastName
-- for Clients with LastNames starting with 'C'?
-- How are Clients and Workouts related?
-- 25 rows
--------------------
Select w.Name, c.FirstName,  c.LastName
from client c
inner join ClientWorkout cw on c.ClientId=cw.ClientId
inner join Workout w on cw.WorkoutId=w.workoutid
where c.lastname like 'c%'
	-- many-to-many relationship with a bridge table.


-- Select Names from Workouts and their Goals.
-- This is a many-to-many relationship with a bridge table.
-- Use aliases appropriately to avoid ambiguous columns in the result.
--------------------
SELECT        Workout.Name AS WorkoutName, Workout_1.Name AS GoalName
FROM            Workout INNER JOIN
                         WorkoutGoal ON Workout.WorkoutId = WorkoutGoal.WorkoutId INNER JOIN
                         Workout AS Workout_1 ON WorkoutGoal.WorkoutId = Workout_1.WorkoutId


-- Select FirstName and LastName from Client.
-- Select ClientId and EmailAddress from Login.
-- Join the tables, but make Login optional.
-- 500 rows
--------------------
select c.firstname, c.lastname, l.clientid, l.EmailAddress from client c
left join login l on l.ClientId = c.clientid




-- Using the query above as a foundation, select Clients
-- who do _not_ have a Login.
-- 200 rows
--------------------
select c.firstname, c.lastname, l.clientid, l.EmailAddress from client c
left join login l on l.ClientId = c.clientid
where l.clientid is null

-- Does the Client, Romeo Seaward, have a Login?
-- Decide using a single query.
-- nope :(
--------------------
select * from client
inner join login on client.clientid = login.ClientId
where client.FirstName='Romeo' and client.lastname = 'Seaward'

-- Select ExerciseCategory.Name and its parent ExerciseCategory's Name.
-- This requires a self-join.
-- 12 rows
--------------------
select e.name from ExerciseCategory e
inner join ExerciseCategory e1 on e.ParentCategoryId = e1.ExerciseCategoryId
    
-- Rewrite the query above so that every ExerciseCategory.Name is
-- included, even if it doesn't have a parent.
-- 16 rows
--------------------
select e.name from ExerciseCategory e
left join ExerciseCategory e1 on e.ParentCategoryId = e1.ExerciseCategoryId   


-- Are there Clients who are not signed up for a Workout?
-- 50 rows
--------------------
select * from client
left join clientworkout on clientworkout.ClientId = client.clientid
where ClientWorkout.clientid is null

-- Which Beginner-Level Workouts satisfy at least one of Shell Creane's Goals?
-- Goals are associated to Clients through ClientGoal.
-- Goals are associated to Workouts through WorkoutGoal.
-- 6 rows, 4 unique rows
--------------------

select distinct w.* from client c
inner join clientgoal cg on c.ClientId = cg.ClientId	
inner join workoutgoal wg on wg.goalid = cg.goalid
inner join workout w on wg.WorkoutId = w.WorkoutId
where firstname = 'shell' and lastname = 'creane'
and w.levelid = 1


-- Select all Workouts. 
-- Join to the Goal, 'Core Strength', but make it optional.
-- You may have to look up the GoalId before writing the main query.
-- If you filter on Goal.Name in a WHERE clause, Workouts will be excluded.
-- Why?
-- 26 Workouts, 3 Goals
--------------------

SELECT DISTINCT workout.*
FROM            Workout INNER JOIN
                         WorkoutGoal ON Workout.WorkoutId = WorkoutGoal.WorkoutId LEFT OUTER JOIN
                         Goal ON WorkoutGoal.GoalId = Goal.GoalId
WHERE        (Goal.Name = 'Core Strength')





-- The relationship between Workouts and Exercises is... complicated.
-- Workout links to WorkoutDay (one day in a Workout routine)
-- which links to WorkoutDayExerciseInstance 
-- (Exercises can be repeated in a day so a bridge table is required) 
-- which links to ExerciseInstance 
-- (Exercises can be done with different weights, repetions,
-- laps, etc...) 
-- which finally links to Exercise.
-- Select Workout.Name and Exercise.Name for related Workouts and Exercises.
--------------------
SELECT        Workout.Name as WorkoutName, Exercise.Name AS ExerciseName
FROM            Workout INNER JOIN
                         WorkoutDay ON Workout.WorkoutId = WorkoutDay.WorkoutId INNER JOIN
                         WorkoutDayExerciseInstance ON WorkoutDay.WorkoutDayId = WorkoutDayExerciseInstance.WorkoutDayId INNER JOIN
                         ExerciseInstance ON WorkoutDayExerciseInstance.ExerciseInstanceId = ExerciseInstance.ExerciseInstanceId INNER JOIN
                         Exercise ON ExerciseInstance.ExerciseId = Exercise.ExerciseId


-- An ExerciseInstance is configured with ExerciseInstanceUnitValue.
-- It contains a Value and UnitId that links to Unit.
-- Example Unit/Value combos include 10 laps, 15 minutes, 200 pounds.
-- Select Exercise.Name, ExerciseInstanceUnitValue.Value, and Unit.Name
-- for the 'Plank' exercise. 
-- How many Planks are configured, which Units apply, and what 
-- are the configured Values?
-- 4 rows, 1 Unit, and 4 distinct Values
--------------------
SELECT        Exercise.Name, ExerciseInstanceUnitValue.Value, Unit.Name 
FROM            ExerciseInstance INNER JOIN
                         ExerciseInstanceUnitValue ON ExerciseInstance.ExerciseInstanceId = ExerciseInstanceUnitValue.ExerciseInstanceId INNER JOIN
                         Exercise ON ExerciseInstance.ExerciseId = Exercise.ExerciseId INNER JOIN
                         Unit ON ExerciseInstanceUnitValue.UnitId = Unit.UnitId
WHERE        (Exercise.Name = 'Plank')