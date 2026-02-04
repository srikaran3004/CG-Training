create table Students (
    StudentId int primary key,
    StudentName varchar(50)
);

create table Marks (
    MarkId int primary key,
    StudentId int,
    Subject varchar(50),
    Score int,
    foreign key (StudentId) references Students(StudentId)
);

insert into Students values
(1, 'Srikaran'),
(2, 'Pavan'),
(3, 'Subhanshu'),
(4, 'Aditya');

insert into Marks values
(101, 1, 'Math', 85),
(102, 1, 'Science', 90),
(103, 3, 'Math', 78);

delete s
from Students s
left join Marks m on s.StudentId = m.StudentId
where m.StudentId is null;

select * from Students;
