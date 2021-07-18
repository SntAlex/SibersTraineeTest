USE master
CREATE DATABASE Sibers
GO

USE Sibers
GO
CREATE TABLE Employees
(
	Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	CreationDate date NOT NULL DEFAULT((getdate())),
	Firstname nvarchar(40) NOT NULL,
	Lastname nvarchar(40) NOT NULL,
	Email nvarchar(255) NOT NULL UNIQUE
);

Use Sibers
GO
CREATE TABLE Projects
(
	Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	CreationDate date NOT NULL DEFAULT((getdate())),
	ProjectName nvarchar(64) NOT NULL,
	ClientName nvarchar(64) NOT NULL DEFAULT('Empty'),
	ContractorName nvarchar(64) NOT NULL DEFAULT('Empty'),
	StartingDate Date,
	EndingDate Date,
	ProjectPriority int,
	LeaderId int

);

USE Sibers
GO
ALTER TABLE Projects
ADD CONSTRAINT FK_Projects_Employees 
FOREIGN KEY (LeaderId)
REFERENCES Employees(Id);
Go

USE Sibers
GO
CREATE TABLE ProjectsEmployees
(
		Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
		CreationDate date NOT NULL DEFAULT((getdate())),
		ProjectId int NOT NULL,
		EmployeeId int NOT NULL
);

USE Sibers
GO
ALTER TABLE ProjectsEmployees
ADD CONSTRAINT FK_ProjectsEmployees_Employees 
FOREIGN KEY (EmployeeId)
REFERENCES Employees(Id);
Go

USE Sibers
GO
ALTER TABLE ProjectsEmployees
ADD CONSTRAINT FK_ProjectsEmployees_Projects
FOREIGN KEY (ProjectId)
REFERENCES Projects(Id);
Go