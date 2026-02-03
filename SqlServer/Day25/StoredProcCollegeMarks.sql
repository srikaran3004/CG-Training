CREATE PROC usp_check1
    @count INT OUTPUT
AS
BEGIN
    SELECT @count = COUNT(*)
    FROM CollegeMarks
    WHERE M1 = 100 OR M2 = 100 OR M3 = 100;
END;

DECLARE @count INT;

EXEC usp_check1 @count OUTPUT;

IF (@count < 4)
BEGIN
    UPDATE CollegeMarks
    SET M2 = 100
    WHERE State IN ('AP', 'Telangana');
END;
