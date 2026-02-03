BEGIN TRY
    BEGIN TRANSACTION tc1;

    DECLARE @temp INT;

    INSERT INTO CollegeMaster1 (Name, CourseId)
    VALUES ('Eshwar', 4);

    SELECT @temp = MAX(Id) 
    FROM CollegeMaster1;

    INSERT INTO Boys_Hostel (StdId, Name, RoomNo)
    VALUES (@temp, 'Eshwar', 4);

    IF @@ROWCOUNT = 0
        ROLLBACK TRANSACTION tc1;
    ELSE
        COMMIT TRANSACTION tc1;

    PRINT 'Transaction completed';

END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION tc1;
    PRINT 'Catch block executed';
    PRINT ERROR_MESSAGE();
END CATCH;

--Adding constraint for unique Name(removing dupliucates)
ALTER TABLE CollegeMaster1
ADD CONSTRAINT UQ_CollegeMaster1_Name UNIQUE (Name);


