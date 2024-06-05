﻿Create Database LoginDemoDB
Go
use LoginDemoDB

Create Table Users (
	Email nvarchar(100) PRIMARY KEY,
	[Password] nvarchar(20) NOT NULL,
	PhoneNumber nvarchar(20) NULL,
	BirthDate DATETIME NULL,
	[Status] int NULL,
	[Name] nvarchar(50) NOT NULL
)

Go

INSERT INTO dbo.Users VALUES ('talsi@talsi.com', '1234', '+972506665835','20-may-1976',1,'Tal Simon')
Go
CREATE TABLE [dbo].[Grades]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Grade] NVARCHAR(10) NOT NULL, 
    [EmailId] NVARCHAR(100) NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [Subject] NVARCHAR(100) NULL, 
    CONSTRAINT [FK_Grades_Users] FOREIGN KEY ([EmailId]) REFERENCES [Users]([Email])
)
--scaffold-DbContext "Server = (localdb)\MSSQLLocalDB;Initial Catalog=LoginDemoDB;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models -Context LoginDemoDbContext -DataAnnotations -force