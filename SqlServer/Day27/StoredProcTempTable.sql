create or alter proc usp_bonusCalculation
as 
begin
 create table #bonuscalculator (name nvarchar(50),total int,Bonus int);
 insert into #bonuscalculator(name,total) select StdName,Total from CollegeMaster;
 update #bonuscalculator set bonus=500 where total>250
 select *from #bonuscalculator
 end

 exec usp_bonusCalculation

----------------------------------------------------------------------
create or alter proc passedstudentsafter5months
as 
begin
 create table #passedstudents (name nvarchar(50),marks int,Grade nvarchar(10));
 insert into #passedstudents(name,marks) select StdName,M1 from CollegeMaster;
 update #passedstudents set marks=marks+5;
 update #passedstudents set grade='Pass' where marks>95;
 update #passedstudents set grade='Fail' where marks<=95;
 select count(*) from #passedstudents where grade='pass';
 end

exec passedstudentsafter5months;
select count(*) from CollegeMaster where M1>95;