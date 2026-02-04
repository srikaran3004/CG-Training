select e.Dept, e.Name, e.Salary
from Employees e
where e.Salary = (
    select max(e2.Salary)
    from Employees e2
    where e2.Dept = e.Dept
);
