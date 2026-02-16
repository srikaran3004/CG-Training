/**
CREATE PROC sp_getStdByGenderDept
    @Gender CHAR(1),
    @Dept VARCHAR(50)
AS
BEGIN
    SELECT *
    FROM CollegeMaster
    WHERE Gender = @Gender
      AND Dept = @Dept;
END;

EXEC sp_getStdByGenderDept 'M', 'Computer Science';
**/

create or alter proc sp_getGenderCount
@Gender char(1),
@Cnt int output
as
begin
begin try
select @Cnt=count(*) from CollegeMaster where Gender=@Gender;
end try
begin catch
set @Cnt=0;
print 'catch block executed'
end catch
end;

declare @count int;

exec sp_getGenderCount 'M', @count output;

select @count as GenderCount;

