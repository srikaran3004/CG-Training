-- SINGLE ROW SUBQUERY --
SELECT Name
FROM CollegeMaster1
WHERE CourseId = (
    SELECT Id FROM Course WHERE CourseName = 'Python'
);

--MULTI-ROW SUBQUERY --
SELECT Name
FROM CollegeMaster1
WHERE CourseId IN (
    SELECT Id FROM Course WHERE CourseName IN ('Python', 'Java')
);

--SUBQUERY IN SELECT (Selecting all Students details) --
SELECT 
    Name,
    (SELECT CourseName 
     FROM Course 
     WHERE Course.Id = CollegeMaster1.CourseId) AS CourseName
FROM CollegeMaster1;


--CORRELATED SUBQUERY --
SELECT CourseName
FROM Course c
WHERE EXISTS (
    SELECT 1
    FROM CollegeMaster1 s
    WHERE s.CourseId = c.Id
);


