create view v1 as select * from [dbo].[CollegeMaster] where Gender='M';
select * from v1;
select State from v1
alter view v1 as select State,Age from CollegeMaster
drop view v1