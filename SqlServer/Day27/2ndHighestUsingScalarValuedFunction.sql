CREATE FUNCTION dbo.GetSecondHighestM2()
RETURNS INT
AS
BEGIN
    DECLARE @secondHighest INT;
    SELECT @secondHighest = MAX(M2)
    FROM CollegeMaster
    WHERE M2 < (SELECT MAX(M2) FROM CollegeMaster);
    RETURN @secondHighest;
END;

SELECT dbo.GetSecondHighestM2() AS SecondHighestM2;
