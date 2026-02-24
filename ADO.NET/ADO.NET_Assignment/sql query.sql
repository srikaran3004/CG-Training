create table Employees(
EmpId nvarchar(50) primary key not null,
Name nvarchar(50) not null,
Department nvarchar(10) not null,
Phone bigint not null,
Email nvarchar(30) not null
);

create table Orders(
OrderId int primary key not null,
EmpId nvarchar(50) not null,
OrderAmount money not null,
OrderDate date not null,
foreign key (EmpId) references Employees(EmpId)
);

insert into Employees values
('E101','Srikaran','IT',9876543210,'sri123@gmail.com'),
('E102','Rahul Sharma','HR',9876501234,'rahul@gmail.com'),
('E103','Sneha Reddy','FIN',9876512345,'sneha@gmail.com'),
('E104','Amit Verma','IT',9876523456,'amit@gmail.com'),
('E105','Priya Singh','MKT',9876534567,'priya@gmail.com');

insert into Orders values
(1,'E101',15000,'2026-01-10'),
(2,'E101',22000,'2026-01-15'),
(3,'E102',18000,'2026-01-18'),
(4,'E103',25000,'2026-02-01'),
(5,'E104',12000,'2026-02-05'),
(6,'E105',30000,'2026-02-07'),
(7,'E101',17000,'2026-02-10');

create or alter proc sp_GetEmployeesByDepartment
@Department nvarchar(10)
as
begin
select * from Employees where Department=@Department;
end;

create or alter proc sp_GetDepartmentEmployeeCount
@Department nvarchar(10),
@TotalEmployees int output
as
begin
select @TotalEmployees=count(*) 
from Employees 
where Department=@Department;
end;

create or alter proc sp_GetEmployeeOrders
as
begin
select 
e.Name,
e.Department,
o.OrderId,
o.OrderAmount,
o.OrderDate
from Employees e
inner join Orders o
on e.EmpId=o.EmpId;
end;

select Phone
from Employees
group by Phone
having count(*)>1;

select *
from Employees
where Phone in
(
select Phone
from Employees
group by Phone
having count(*)>1
)
or Email in
(
select Email
from Employees
group by Email
having count(*)>1
);

create or alter proc sp_GetDuplicateEmployees
as
begin
select *
from Employees
where Phone in
(
select Phone
from Employees
group by Phone
having count(*)>1
)
or Email in
(
select Email
from Employees
group by Email
having count(*)>1
);
end;

declare @count int;

exec sp_GetDepartmentEmployeeCount 'IT', @count output;

select @count as TotalEmployees;

