-- UP script for SQL Server

CREATE TABLE [Peak] (
  [ID]              INT PRIMARY KEY IDENTITY(1, 1),
  [Name]            NVARCHAR(30) NOT NULL,
  [Height]          INT NOT NULL,
  [ClimbingStatus]  BIT NOT NULL,
  [FirstAscentYear] INT
)
GO

CREATE TABLE [Expedition] (
  [ID]                INT PRIMARY KEY IDENTITY(1, 1),
  [Season]            NVARCHAR(10),
  [Year]              INT,
  [StartDate]         DATE,
  [TerminationReason] NVARCHAR(80),
  [OxygenUsed]        BIT,
  [PeakID]            INT,
  [TrekkingAgencyID]  INT,
  --[MemberID] INT
)
GO

CREATE TABLE [TrekkingAgency] (
  [ID]    INT PRIMARY KEY IDENTITY(1, 1),
  [Name]  NVARCHAR(100)
)
GO

--CREATE TABLE [Member] (
--	[ID]      INT PRIMARY KEY IDENTITY(1, 1),
--	[FirstName]	  NVARCHAR(50),
--	[LastName]	  NVARCHAR(50),
--	[Nationality] NVARCHAR(50),
--	[BirthDate] DATE,
--	[Age]	  INT,
--  [Role] NVARCHAR(35),
--  [HighPoint] INT,
--  [OxygenUsed] BIT
--)
--GO

ALTER TABLE [Expedition] ADD CONSTRAINT [Expedition_FK_Peak] FOREIGN KEY ([PeakID]) REFERENCES [Peak] ([ID])
ALTER TABLE [Expedition] ADD CONSTRAINT [Expedition_FK_TrekkingAgency] FOREIGN KEY ([TrekkingAgencyID]) REFERENCES [TrekkingAgency] ([ID])
--ALTER TABLE [Expedition] ADD CONSTRAINT [Expedition_FK_Member] FOREIGN KEY ([MemberID]) REFERENCES [Memeber] ([ID]) 	
GO