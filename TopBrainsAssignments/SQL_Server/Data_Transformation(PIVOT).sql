select *
from (
    select EmpId, Month, TotalPresent
    from Attendance
) as src
pivot (
    sum(TotalPresent)
    for Month in ([Jan], [Feb], [Mar], [Apr])
) as pvt;
