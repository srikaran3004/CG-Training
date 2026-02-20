CREATE TABLE StudentsMaster
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50),
    Age INT,
    City NVARCHAR(50)
);


INSERT INTO StudentsMaster (Name, Age, City)
VALUES
('Srikaran', 20, 'Chennai'),
('Pavan', 21, 'Bangalore'),
('Aditya', 19, 'Hyderabad');