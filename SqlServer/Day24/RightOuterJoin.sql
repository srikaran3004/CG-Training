CREATE TABLE CollegeMaster1 (
    Id INT PRIMARY KEY,
    Name NVARCHAR(50),
    CourseId INT
);

CREATE TABLE Course (
    Id INT PRIMARY KEY,
    CourseName NVARCHAR(50)
);

ALTER TABLE CollegeMaster1
ADD CONSTRAINT FK_College_Course
FOREIGN KEY (CourseId) REFERENCES Course(Id);

INSERT INTO Course (Id, CourseName) VALUES
(1, 'Python'),
(2, 'Java'),
(3, 'C++'),
(4, 'Dotnet'),
(5, 'Data Science');

INSERT INTO CollegeMaster1 (Id, Name, CourseId) VALUES
(1, 'Shubanshu', 4),
(2, 'Pavan', 2),
(3, 'Deepak', 1),
(4, 'Arjun', 4),
(5, 'Srikaran', 4),
(6, 'Siva', 1),
(7, 'Tirtharaj', 2);

--RIGHT OUTER JOIN --
SELECT 
    c.CourseName,
    s.Name AS StudentName
FROM CollegeMaster1 s
RIGHT OUTER JOIN Course c
    ON s.CourseId = c.Id;

--OR--

SELECT 
    c.CourseName,
    s.Name AS StudentName
FROM CollegeMaster1 s
RIGHT JOIN Course c
    ON s.CourseId = c.Id
ORDER BY 
    CASE WHEN s.Name IS NULL THEN 1 ELSE 0 END,
    c.CourseName;

