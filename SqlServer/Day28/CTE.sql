-- CTE( One line or Line-based Temp Table --
WITH AvgM2ByDept AS(
	select Dept, AVG(M2) AS AvgM2
	from CollegeMaster
	GROUP BY Dept
)
SELECT *
FROM AvgM2ByDept;
--Execute whole query at once.

-- Find 3rd Max M1 marks
select distinct M1 from CollegeMaster order by M1 desc offset 2 rows fetch next 1 row only;

--Highest by Dept
with HighestByDept as(
	select Dept,sum(M1) as totalM1 from CollegeMaster group by Dept)
select * from HighestByDept;

