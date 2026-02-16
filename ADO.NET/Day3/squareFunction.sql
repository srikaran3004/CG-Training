CREATE or alter FUNCTION dbo.GetSquare
(
    @Num INT
)
RETURNS INT
AS
BEGIN
    RETURN @Num * @Num
END
GO

SELECT dbo.GetSquare(5) AS Result;
