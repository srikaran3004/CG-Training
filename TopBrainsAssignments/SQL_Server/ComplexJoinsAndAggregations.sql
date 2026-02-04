create table Department (
    DeptId int primary key,
    DeptName varchar(50)
);

create table Employees (
    EmpId int primary key,
    Name varchar(50),
    Salary int,
    DeptId int,
    foreign key (DeptId) references Department(DeptId)
);

insert into Department values
(1, 'IT'),
(2, 'HR'),
(3, 'Finance');

insert into Employees values
(101, 'Srikaran', 90000, 1),
(102, 'Pavan', 85000, 1),
(103, 'Aditya', 60000, 1),
(104, 'Subhanshu', 50000, 2),
(105, 'Arjun', 55000, 2),
(106, 'Masoom', 120000, 3),
(107, 'Navneet', 80000, 3);

select d.DeptName,
       e.Name as EmployeeName,
       e.Salary as HighestSalary
from Employees e
join Department d on e.DeptId = d.DeptId
where e.Salary = (
    select max(e2.Salary)
    from Employees e2
    where e2.DeptId = e.DeptId
)
and e.DeptId in (
    select DeptId
    from Employees
    group by DeptId
    having avg(Salary) > 70000
);
