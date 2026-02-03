CREATE FUNCTION getDeptByName (@name NVARCHAR(20))
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM CollegeMaster
    WHERE StdName = @name
);
GO

SELECT * FROM dbo.getDeptByName('Srikaran');


