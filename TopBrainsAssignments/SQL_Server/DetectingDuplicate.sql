select Email, count(*) as EmailCount
from Users
group by Email
having count(*) > 1;
