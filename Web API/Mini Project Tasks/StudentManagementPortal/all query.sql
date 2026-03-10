USE StudentManagementPortalDB;
GO

-- Create Students Table
CREATE TABLE Students (
    StudentId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Course NVARCHAR(100) NOT NULL
);
GO

-- Create HostelAdmissions Table
CREATE TABLE HostelAdmissions (
    HostelId INT IDENTITY(1,1) PRIMARY KEY,
    RoomNumber NVARCHAR(20) NOT NULL,
    Block NVARCHAR(20) NOT NULL,
    StudentId INT NOT NULL UNIQUE, -- UNIQUE constraint enforces One-to-One relationship

    CONSTRAINT FK_HostelAdmissions_Students FOREIGN KEY (StudentId) 
    REFERENCES Students(StudentId) 
    ON DELETE CASCADE -- If a student is deleted, their hostel admission is also deleted
);
GO

