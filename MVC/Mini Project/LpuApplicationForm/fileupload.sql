/* Add column to store actual image bytes */
ALTER TABLE Students ADD ProfileImage VARBINARY(MAX) NULL;

/* Add column to store the file extension (needed to render the image later) */
ALTER TABLE Students ADD ImageExtension NVARCHAR(10) NULL;

/* Database-level format validation */
ALTER TABLE Students ADD CONSTRAINT CHK_ImageFormat 
    CHECK (ImageExtension IN ('.jpg', '.jpeg', '.png'));

/* Database-level size validation (optional but professional) */
/* Rejects any binary data larger than 3MB at the storage level */
ALTER TABLE Students ADD CONSTRAINT CHK_ImageSize 
    CHECK (DATALENGTH(ProfileImage) <= 3145728);

ALTER PROCEDURE InsertStudent
    @FullName NVARCHAR(100),
    @Email NVARCHAR(100),
    @Mobile NVARCHAR(10),
    @Gender NVARCHAR(10),
    @DOB DATE,
    @Address NVARCHAR(500),
    @City NVARCHAR(50),
    @State NVARCHAR(50),
    @Pincode NVARCHAR(6),
    @HighSchoolMarks DECIMAL(5,2),
    @IntermediateMarks DECIMAL(5,2),
    @CourseApplied NVARCHAR(50),
    @ProfileImage VARBINARY(MAX) = NULL,
    @ImageExtension NVARCHAR(10) = NULL
AS
BEGIN
    INSERT INTO Students (FullName, Email, Mobile, Gender, DOB, Address, City, State, Pincode,
        HighSchoolMarks, IntermediateMarks, CourseApplied, ProfileImage, ImageExtension)
    VALUES (@FullName, @Email, @Mobile, @Gender, @DOB, @Address, @City, @State, @Pincode,
        @HighSchoolMarks, @IntermediateMarks, @CourseApplied, @ProfileImage, @ImageExtension);
END
GO

ALTER PROCEDURE UpdateStudent
    @StudentId INT,
    @FullName NVARCHAR(100),
    @Email NVARCHAR(100),
    @Mobile NVARCHAR(10),
    @Gender NVARCHAR(10),
    @DOB DATE,
    @Address NVARCHAR(500),
    @City NVARCHAR(50),
    @State NVARCHAR(50),
    @Pincode NVARCHAR(6),
    @HighSchoolMarks DECIMAL(5,2),
    @IntermediateMarks DECIMAL(5,2),
    @CourseApplied NVARCHAR(50),
    @ProfileImage VARBINARY(MAX) = NULL,
    @ImageExtension NVARCHAR(10) = NULL
AS
BEGIN
    UPDATE Students SET
        FullName = @FullName, Email = @Email, Mobile = @Mobile, Gender = @Gender,
        DOB = @DOB, Address = @Address, City = @City, State = @State, Pincode = @Pincode,
        HighSchoolMarks = @HighSchoolMarks, IntermediateMarks = @IntermediateMarks,
        CourseApplied = @CourseApplied, ProfileImage = @ProfileImage, ImageExtension = @ImageExtension
    WHERE StudentId = @StudentId;
END
GO

-- City minimum 3 characters
ALTER TABLE Students ADD CONSTRAINT CHK_City_MinLen CHECK (LEN(City) >= 3);
GO

-- State minimum 4 characters
ALTER TABLE Students ADD CONSTRAINT CHK_State_MinLen CHECK (LEN(State) >= 4);
GO

-- Email must contain @ and a dot after @
ALTER TABLE Students ADD CONSTRAINT CHK_Email_Format CHECK (Email LIKE '%_@_%.__%');
GO