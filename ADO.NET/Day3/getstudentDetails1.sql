USE MyDatabase;
GO

CREATE PROCEDURE sp_getstudentDetails1
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM CollegeMaster;
END;
GO
