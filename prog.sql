CREATE TABLE [Classes]
(
 [ID]   int NOT NULL IDENTITY,
 [Name] varchar(50) NOT NULL ,


 CONSTRAINT [PK_classes] PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO


CREATE TABLE [Users]
(
 [ID]      int NOT NULL IDENTITY,
 [Name]    varchar(50) NOT NULL ,
 [Surname] varchar(50) NOT NULL ,
 [Admin]   bit NOT NULL ,
 [Password]   varchar(50) NOT NULL ,
[Login] VARCHAR(50) NOT NULL,
Class VARCHAR(2) NULL,


 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO

CREATE TABLE [Grades]
(
 [ID]         int NOT NULL IDENTITY,
 [Student_ID] int NOT NULL ,
 [Teache_ID]  int NOT NULL ,
 [Class_ID]   int NOT NULL ,
 [Wage]       int NOT NULL ,
 [Date]       datetime NOT NULL ,
[Grade] int NOT NULL,


 CONSTRAINT [PK_grades] PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO

INSERT INTO Users VALUES('Adam', 'Nowakowski', 1, 'Test123', 'Adamek42', '');
INSERT INTO Users VALUES('Marek', 'Kowalski', 0, 'Test123', 'MKowalski', 2);
INSERT INTO Users VALUES('Romek', 'Ostryk', 0, 'Test123', 'ROstryk', 5);
INSERT INTO Users VALUES('Aleks', 'Kaczyk', 0, 'Test123', 'AKaczyk', 4);
INSERT INTO Users VALUES('Romek', 'Okowski', 0, 'Test123', 'ROkowski', 3);


INSERT INTO Classes VALUES('Przyroda'),
  ('Matematyka'),
  ('Fizyka'),
  ('Chemia'),
  ('Historia'),
  ('Plastyka'),
  ('Sport'),
  ('Muzyka');

INSERT INTO Grades VALUES(2, 1, 1, 1, GETDATE(), 5);
INSERT INTO Grades VALUES(4, 1, 4, 4, GETDATE(), 3);
INSERT INTO Grades VALUES(4, 1, 2, 3, GETDATE(), 4);
INSERT INTO Grades VALUES(5, 1, 2, 3, GETDATE(), 4);