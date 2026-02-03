create proc usp_getStudentName
as
begin
select * from CollegeMaster1
end;

Exec usp_getStudentName;