create or alter trigger prevent_table_creation
on database
for DROP_TABLE
as
begin
 Print 'you can not drop the table in database';
 rollback
end;

drop table [dbo].[Hostel_info]

------------------------------------------------------
alter trigger prevent_update1
on [dbo].[CollegeMaster]
for update
as
begin
raiserror ('You can not update in this table',16,1);
rollback 
end;

update [dbo].[CollegeMaster] set state = 'Chennai'