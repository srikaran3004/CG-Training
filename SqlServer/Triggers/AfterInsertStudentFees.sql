create table Students (
    StudentID int identity primary key,
    StudentName varchar(100)
);

create table Fees (
    StudentID int,
    FeeStatus varchar(50),
    CreatedDate datetime default getdate()
);

create trigger trgAfterInsertStudent
on Students
after insert
as
begin
    insert into Fees(StudentID, FeeStatus)
    select StudentID, 'Pending' from inserted;
end;

insert into Students (StudentName)
values ('Mari');

select * from Students;
select * from Fees;