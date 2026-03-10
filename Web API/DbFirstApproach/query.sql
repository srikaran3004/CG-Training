CREATE TABLE Students
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    M1 INT NULL,
    M2 INT NULL
)

INSERT INTO Students (Name, M1, M2) VALUES ('Srikaran', 80, 90)
INSERT INTO Students (Name, M1, M2) VALUES ('Pavan', 70, 75)
INSERT INTO Students (Name) VALUES ('Aditya')