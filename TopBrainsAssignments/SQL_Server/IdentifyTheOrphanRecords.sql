create table Orders (
    OrderId int primary key,
    OrderDate date
);

create table OrderItems (
    ItemId int primary key,
    OrderId int,
    ProductName varchar(50),
    Quantity int
);

insert into Orders values
(1, '2024-01-10'),
(2, '2024-01-12'),
(3, '2024-01-15');

insert into OrderItems values
(101, 1, 'Laptop', 1),
(102, 1, 'Mouse', 2),
(103, 2, 'Keyboard', 1),
(104, 4, 'Monitor', 1),
(105, 5, 'Printer', 1);

select oi.*
from OrderItems oi
left join Orders o on oi.OrderId = o.OrderId
where o.OrderId is null;
