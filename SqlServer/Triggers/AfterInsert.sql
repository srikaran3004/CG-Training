create table Employees(
EmpID int identity(1,1) primary key,
EmpName varchar(100),
EmpSal Decimal(10,2)
);
go

create table Employee_Audit(
EmpID int,
EmpName varchar(100),
EmpSal decimal(10,2),
Audit_Action varchar(100),
Audit_Timestamp Datetime
);

create trigger trgAfterInsertEmployee
on Employees
after insert 
as
begin
set nocount on;
insert into Employee_Audit(EmpID, EmpName, EmpSal, Audit_Action, Audit_Timestamp)
select
i.EmpID, i.EmpName, i.EmpSal, 'Inserted Record', GETDATE() 
from inserted as i;
end;
go

insert into Employees (EmpName, EmpSal)
values ('Srikaran', 45000);

select * from Employees;
select * from Employee_Audit;
