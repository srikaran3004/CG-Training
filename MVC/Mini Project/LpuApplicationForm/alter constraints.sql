/* 1. Remove existing constraints to avoid conflicts */
/* Note: If your constraint names differ, SSMS will throw an error. 
   You can find your specific names under 'Constraints' in the Table folder. */

ALTER TABLE Students DROP CONSTRAINT IF EXISTS CHK_Student_Age;
ALTER TABLE Students DROP CONSTRAINT IF EXISTS CHK_Student_Name;
ALTER TABLE Students DROP CONSTRAINT IF EXISTS CHK_Student_Mobile;
ALTER TABLE Students DROP CONSTRAINT IF EXISTS CHK_Student_Email;
ALTER TABLE Students DROP CONSTRAINT IF EXISTS CHK_Student_Marks;
ALTER TABLE Students DROP CONSTRAINT IF EXISTS CHK_Student_Pincode;

/* 2. Apply New Synchronized Constraints */

-- FullName: No numbers allowed
ALTER TABLE Students ADD CONSTRAINT CHK_Student_Name 
    CHECK (FullName NOT LIKE '%[0-9]%');

-- Email: Basic pattern check
ALTER TABLE Students ADD CONSTRAINT CHK_Student_Email 
    CHECK (Email LIKE '%_@__%.%_');

-- Mobile: Exactly 10 digits
ALTER TABLE Students ADD CONSTRAINT CHK_Student_Mobile 
    CHECK (Mobile LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]');

-- Pincode: Exactly 6 digits
ALTER TABLE Students ADD CONSTRAINT CHK_Student_Pincode 
    CHECK (Pincode LIKE '[0-9][0-9][0-9][0-9][0-9][0-9]');

-- Marks: Range between 0 and 100
ALTER TABLE Students ADD CONSTRAINT CHK_Student_Marks 
    CHECK (HighSchoolMarks BETWEEN 0 AND 100 AND IntermediateMarks BETWEEN 0 AND 100);

-- Age: 16 to 100 years old (Calculated from DOB)
ALTER TABLE Students ADD CONSTRAINT CHK_Student_Age 
    CHECK (DATEDIFF(YEAR, DOB, GETDATE()) BETWEEN 16 AND 100);

-- City: No numbers allowed
ALTER TABLE Students ADD CONSTRAINT CHK_Student_City 
    CHECK (City NOT LIKE '%[0-9]%');

--Verifying Active Constraints--
SELECT 
    con.name AS ConstraintName, 
    con.definition AS ConstraintLogic,
    t.name AS TableName
FROM sys.check_constraints con
INNER JOIN sys.objects t ON con.parent_object_id = t.object_id
WHERE t.name = 'Students';