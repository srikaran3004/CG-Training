--Department table--
create table Department( DepartmentId int primary key,Department varchar(50) not null);
--Employee table--
create table Employee(EmpId int primary key, EmpName varchar(50) not null, Email varchar(30) unique, DepartmentId int not null
constraint FK_Employee_Department foreign key (DepartmentId) references Department(DepartmentId)
);
-- Sales table--
create table Sales(SaleId int identity primary key, EmpId int not null, SaleMonth int not null, SaleYear int not null, SaleAmount decimal(10,2) not null
constraint FK_Sales_Employee foreign key(EmpId) references Employee(EmpId)
);

--inserting data--
insert into Department (DepartmentId, Department)
values (1, 'IT'),(2, 'Devops'), (3, 'Consulting');

insert into Employee (EmpId, EmpName, Email, DepartmentId)
values 
(11, 'Marimuthu', 'marimuthu@company.com', 1),
(12, 'Srikaran', 'srikaran@company.com', 1),
(13, 'Pavan', 'pavan@company.com', 2),
(14, 'Subhanshu', 'subhanshu@company.com', 3),
(15, 'Aditya', 'aditya@company.com', 2);

insert into Employee (EmpId, EmpName, Email, DepartmentId)
values (16, 'Karthik', 'karthik@company.com', 1);


insert into Sales (EmpId, SaleMonth, SaleYear, SaleAmount)
values(11, 1, year(getdate()), 60000), (11, 2, year(getdate()), 18000),
(12, 1, year(getdate()), 9000),
(13, 3, year(getdate()), 25000), (13, 4, year(getdate()), 52000),
(14, 2, year(getdate()), 8000),
(15, 5, year(getdate()), 30000);

insert into Sales (EmpId, SaleMonth, SaleYear, SaleAmount)
values
(11, 10, 2025, 40000),
(12, 11, 2025, 12000),
(13, 12, 2025, 30000),
(15, 9, 2025, 7000);



--Q2. Alter table add BonusPoints--
alter table Employee add BonusPoints int not null constraint df_employee_bonuspoints default 0;

select * from Employee;

--Q3. Check Constraint Bonus always 0-100--
alter table Employee add constraint chk_employee_bonus check(BonusPoints between 0 and 100);
--fails as Bonus is >100--
update Employee set BonusPoints = 150 where EmpId=11;
--passes as Bonus is <100--
update Employee set BonusPoints = 90 where EmpId=11;

--Q4.Inner Join--
select e.EmpName,d.Department,s.SaleMonth,s.SaleYear,s.SaleAmount
from Employee e
inner join Sales s on e.EmpId = s.EmpId
inner join Department d on e.DepartmentId = d.DepartmentId;

--Q5. Total sales current year--
select e.EmpId,e.EmpName,sum(s.SaleAmount) as TotalSales
from Employee e
inner join Sales s on e.EmpId = s.EmpId where s.SaleYear = year(getdate())
group by e.EmpId, e.EmpName;

--to check null sales by any--
select e.EmpId,e.EmpName,d.Department
from Employee e
left join Sales s on e.EmpId = s.EmpId
inner join Department d on e.DepartmentId = d.DepartmentId where s.EmpId is null;

--Q6.UserName Suggestions--
select e.EmpName,substring(e.EmpName, 1, 3) + left(d.Department, 2) + cast(e.EmpId as varchar(10)) as user_name
from Employee e
inner join Department d on e.DepartmentId = d.DepartmentId;

--Q7.Subquery to find SalesAmount by employee over TotalAvg Sales--
select EmpId, EmpName from Employee
where EmpId in ( select EmpId from Sales group by EmpId having sum(SaleAmount) > (select avg(TotalSales)
from (select sum(SaleAmount) as TotalSales from Sales group by EmpId) t)
);

--to check employee wise checking sales total--
select e.EmpName, sum(s.SaleAmount) as TotalSales
from Employee e
inner join Sales s on e.EmpId = s.EmpId where e.EmpName = 'Marimuthu' group by e.EmpName;

--Q8. Union sales>50,000 as High and sales<50,000 as Low--
select e.EmpName, sum(s.SaleAmount) as SaleAmount, 'High' as Category
from Employee e
inner join Sales s on e.EmpId = s.EmpId
group by e.EmpName
having sum(s.SaleAmount) > 50000
union
select e.EmpName, sum(s.SaleAmount) as SaleAmount, 'Low'
from Employee e
inner join Sales s on e.EmpId = s.EmpId
group by e.EmpName
having sum(s.SaleAmount) < 10000;


--Q9. Trigger when SaleAmount>=50000 +10 and SaleAmount>=20000 +5 --
create trigger trg_update_bonuspoints
on Sales
after insert
as
begin
update e
set BonusPoints = BonusPoints +
case
    when i.SaleAmount >= 50000 then 10
    when i.SaleAmount >= 20000 then 5
    else 0
end
from Employee e
inner join inserted i on e.EmpId = i.EmpId;
end;
--inserting data--
insert into Sales (EmpId, SaleMonth, SaleYear, SaleAmount) values (14, 6, year(getdate()), 55000);
--verifying data--
select EmpId, EmpName, BonusPoints from Employee where EmpId = 14;

--Q10. Integrated Validation Query --
select e.EmpName,d.Department,isnull(sum(s.SaleAmount), 0) as TotalSales,e.BonusPoints,
case
    when e.BonusPoints >= 50 then 'A'
    when e.BonusPoints >= 20 then 'B'
    else 'C'
end as Grade
from Employee e
join Department d on e.DepartmentId = d.DepartmentId
left join Sales s on e.EmpId = s.EmpId
group by e.EmpName, d.Department, e.BonusPoints;






