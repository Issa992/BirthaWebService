﻿--select * from dbo.[user]
--Select * FROM dbo.[User] where id = 1
--INSERT INTO dbo.[User](Name,Email,Password)VALUES('Ben','ben@gmail.com','1234')
--update dbo.[user] set name='findingben',email='findingben@gmail.com',password=123 where id=2;
--DELETE FROM dbo.[User] WHERE Id=2

--DELETE FROM dbo.Health WHERE Id=1

--select * from dbo.health
--INSERT INTO dbo.Health(BloodPressure,HeartBeat,Age,Weight,Gender,UserId)VALUES(33,30,80,'Male',5)
--UPDATE dbo.Health SET BloodPressure=11,HeartBeat=11,Age=11,Weight=11,Gender='maleaa',UserId=3 WHERE Id=4
--SELECT*FROM dbo.Health
--SELECT * FROM dbo.Environment
--Select * FROM dbo.Environment where id = 1

--INSERT INTO dbo.Environment(Oxygen,Nitrogen,CarbonDioxide,Methane,UserId)VALUES(3,2,4,5,1)

--UPDATE dbo.Environment SET Oxygen=@oxygen,Nitrogen=@nitrogen,CarbonDioxide=@carbonDioxide,Methane=@methane,UserId=@userId WHERE Id=@id
--SELECT * FROM dbo.Health WHERE UserId =1;
Select * FROM dbo.[Health] where UserId = 1