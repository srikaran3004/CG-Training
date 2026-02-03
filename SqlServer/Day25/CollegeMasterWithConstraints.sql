CREATE TABLE CollegeMaster (
    StdId INT IDENTITY(1,1) PRIMARY KEY,
    StdName VARCHAR(100),
    Gender CHAR(1),
    Age INT,
    Dept VARCHAR(100),
    Year INT,
    CourseName VARCHAR(100),
    RoomNo INT,
    State VARCHAR(50),
    M1 INT,
    M2 INT,
    M3 INT
);

INSERT INTO CollegeMaster 
(StdName, Gender, Age, Dept, Year, CourseName, RoomNo, State, M1, M2, M3)
VALUES
('Srikaran', 'M', 20, 'Computer Science', 2, 'Dotnet', 10, 'Telangana', 100, 100, 85),
('Pavan', 'M', 21, 'Mechanical', 3, 'Java', 20, 'AP', 99, 100, 87),
('Shubanshu', 'M', 19, 'Electronics', 1, 'Python', 30, 'UP', 100, 98, 89),
('Aditya', 'M', 22, 'Civil', 4, 'C++', 40, 'Bihar', 99, 98, 85),
('Neha', 'F', 20, 'Computer Science', 2, 'Data Science', 10, 'Delhi', 98, 87, 78),
('Rahul', 'M', 18, 'Mechanical', 1, 'Python', 10, 'AP', 97, 88, 90),
('Sneha', 'F', 21, 'Electronics', 3, 'Java', 30, 'Telangana', 96, 92, 88),
('Arjun', 'M', 20, 'Civil', 2, 'Dotnet', 40, 'UP', 95, 85, 80),
('Siva', 'M', 22, 'Mechanical', 2, 'Python', 10, 'AP', 98, 100, 92),
('Gauri', 'F', 19, 'Computer Science', 1, 'Data Science', 20, 'Delhi', 97, 89, 91);

ALTER TABLE CollegeMaster
ADD CONSTRAINT CHK_Gender CHECK (Gender IN ('M','F')),
    CONSTRAINT CHK_Age CHECK (Age BETWEEN 16 AND 99),

    CONSTRAINT CHK_M1_Range CHECK (M1 BETWEEN 0 AND 100),
    CONSTRAINT CHK_M2_Range CHECK (M2 BETWEEN 0 AND 100),
    CONSTRAINT CHK_M3_Range CHECK (M3 BETWEEN 0 AND 100),

    CONSTRAINT CHK_TotalMarks CHECK ((M1 + M2 + M3) <= 300),

    CONSTRAINT UQ_Student UNIQUE (StdName, Dept);


ALTER TABLE CollegeMaster
ADD CONSTRAINT CHK_Gender 
        CHECK (Gender IN ('M','F')),

    CONSTRAINT CHK_Age 
        CHECK (Age BETWEEN 16 AND 99),

    CONSTRAINT CHK_M1_Range 
        CHECK (M1 BETWEEN 0 AND 100),

    CONSTRAINT CHK_M2_Range 
        CHECK (M2 BETWEEN 0 AND 100),

    CONSTRAINT CHK_M3_Range 
        CHECK (M3 BETWEEN 0 AND 100),

    CONSTRAINT CHK_TotalMarks 
        CHECK ((M1 + M2 + M3) <= 300),

    CONSTRAINT CHK_HostelType 
        CHECK (HostelType IN ('BH', 'GH', 'NH')),

    CONSTRAINT CHK_RoomNo_HostelRule
        CHECK (
            (HostelType = 'NH' AND RoomNo IS NULL) OR
            (HostelType IN ('BH','GH') AND RoomNo IS NOT NULL)
        ),

    CONSTRAINT UQ_Student 
        UNIQUE (StdName, Dept);

-- DATEADD Function --
ALTER TABLE CollegeMaster
ADD AdmissionDate DATE;

UPDATE CollegeMaster SET AdmissionDate = '2023-06-15' WHERE StdName = 'Srikaran';
UPDATE CollegeMaster SET AdmissionDate = '2022-07-10' WHERE StdName = 'Neha';
UPDATE CollegeMaster SET AdmissionDate = '2021-08-01' WHERE StdName = 'Pavan';
UPDATE CollegeMaster SET AdmissionDate = '2023-01-20' WHERE StdName = 'Kavya';

-- Add 1 Year to Admission Date --
SELECT StdName, AdmissionDate,
       DATEADD(YEAR, 1, AdmissionDate) AS NextYearDate
FROM CollegeMaster;

--Add 6 Months--
SELECT StdName, AdmissionDate,
       DATEADD(MONTH, 6, AdmissionDate) AS AfterSixMonths
FROM CollegeMaster;

-- No.of days lived for Srikaran --
SELECT 
    StdName,
    DOB,
    DATEDIFF(DAY, DOB, GETDATE()) AS Days_Lived
FROM CollegeMaster
WHERE StdName = 'Srikaran';


-- Stored Procedure where DOB Month is 03 --
create proc dbo.usp_getAllStdByMonth
    @monthInput int
as
begin
select StdId,StdName,DOB
from CollegeMaster
where MONTH(DOB) = @monthInput;
end;

Exec dbo.usp_getAllStdByMonth 5;
