CREATE OR ALTER PROC dbo.usp_getAllHostelStds
AS
BEGIN
    SELECT Name
    FROM dbo.Hostel_info;
END;

Exec dbo.usp_getAllHostelStds



CREATE PROC dbo.usp_getAllStdByRoomNo
@roomNo int
AS
BEGIN
    SELECT Name
    FROM dbo.Hostel_info
    WHERE RoomNo = @roomNo;
END;

Exec dbo.usp_getAllStdByRoomNo
@roomNo=10;


