create table Students(
StudentId int primary key identity(1,1),
FullName nvarchar(25) not null,
Email nvarchar(100) not null,
Mobile nvarchar(15) not null,
Gender nvarchar(10) not null,
DOB date not null,
Address nvarchar(max) not null,
City nvarchar(50) not null,
State nvarchar(50) not null,
Pincode nvarchar(50) not null,
HighSchoolMarks decimal(5,2) not null,
IntermediateMarks decimal(5,2) not null,
CourseApplied nvarchar(25) not null,
ApplicationDate datetime default getdate()
);

-- 1. Ensure Email is unique and formatted (Basic check)
ALTER TABLE Students 
ADD CONSTRAINT UQ_Email UNIQUE (Email);

-- 2. Ensure Mobile is exactly 10 digits
ALTER TABLE Students 
ADD CONSTRAINT CHK_Mobile_Length CHECK (LEN(Mobile) = 10 AND Mobile NOT LIKE '%[^0-9]%');

-- 3. Age Constraint: Must be between 17 and 60 (Logic: Current Date - DOB)
ALTER TABLE Students
ADD CONSTRAINT CHK_Student_Age 
CHECK (DATEDIFF(year, DOB, GETDATE()) >= 17 AND DATEDIFF(year, DOB, GETDATE()) <= 60);

-- 4. Marks Constraint: Must be between 0 and 100
ALTER TABLE Students
ADD CONSTRAINT CHK_HighSchool_Range CHECK (HighSchoolMarks BETWEEN 0 AND 100);

ALTER TABLE Students
ADD CONSTRAINT CHK_Intermediate_Range CHECK (IntermediateMarks BETWEEN 0 AND 100);

-- 5. Gender Constraint: Restrict to specific values
ALTER TABLE Students
ADD CONSTRAINT CHK_Gender_Values CHECK (Gender IN ('Male', 'Female', 'Other'));

--Sp  to Insert Student--
create proc InsertStudent
    @FullName nvarchar(100), @Email nvarchar(100), @Mobile nvarchar(15),
    @Gender nvarchar(10), @DOB date, @Address nvarchar(max),
    @City nvarchar(50), @State nvarchar(50), @Pincode nvarchar(10),
    @HighSchoolMarks decimal(5,2), @IntermediateMarks decimal(5,2),
    @CourseApplied nvarchar(50)
as
begin
    insert into Students (FullName, Email, Mobile, Gender, DOB, Address, City, State, Pincode, HighSchoolMarks, IntermediateMarks, CourseApplied)
    values (@FullName, @Email, @Mobile, @Gender, @DOB, @Address, @City, @State, @Pincode, @HighSchoolMarks, @IntermediateMarks, @CourseApplied)
end

--Sp to GetAllStudents--
create procedure GetAllStudent
as
begin
    select * from Students order by ApplicationDate desc
end

--Sp to Update Student--
create procedure UpdateStudent
    @StudentId int,
    @FullName nvarchar(100), @Email nvarchar(100), @Mobile nvarchar(15),
    @Gender nvarchar(10), @DOB date, @Address nvarchar(max),
    @City nvarchar(50), @State nvarchar(50), @Pincode nvarchar(10),
    @HighSchoolMarks decimal(5,2), @IntermediateMarks decimal(5,2),
    @CourseApplied nvarchar(50)
as
begin
    update Students set 
        FullName=@FullName, Email=@Email, Mobile=@Mobile, Gender=@Gender, DOB=@DOB, 
        Address=@Address, City=@City, State=@State, Pincode=@Pincode, 
        HighSchoolMarks=@HighSchoolMarks, IntermediateMarks=@IntermediateMarks, CourseApplied=@CourseApplied
    where StudentId=@StudentId
end

