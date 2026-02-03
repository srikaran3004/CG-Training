CREATE PROCEDURE dbo.usp_GetStdByDept
    @dept NVARCHAR(50),   --input parameter
    @stdCnt INT OUTPUT    --output parameter 
AS
BEGIN
    SET NOCOUNT ON;

    SELECT @stdCnt = COUNT(*) 
    FROM dbo.College 
    WHERE Dept = @dept;
END;
GO
-----------------------
DECLARE @sCnt INT;

EXEC dbo.usp_GetStdByDept
    @dept = 'Computer Science',
    @stdCnt = @sCnt OUTPUT;

SELECT @sCnt AS StudentCount;

