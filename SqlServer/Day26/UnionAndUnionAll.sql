select * from Up_Sports
union
select * from Punjab_Sports;

------------------------------------

select * from Up_Sports
union all
select * from Punjab_Sports;

-----------------------------------

select * from 
(select * from Up_Sports union select * from Punjab_Sports) as cricketPlayers where SportsName='Cricket';