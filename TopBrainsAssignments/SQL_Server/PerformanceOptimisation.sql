create table Orders (
    OrderId int identity(1,1) primary key,
    CustomerId int,
    OrderDate date,
    Amount decimal(10,2)
);

select * 
from Orders 
where CustomerId = 123 
  and OrderDate > '2026-02-01';

create nonclustered index IX_Orders_CustomerId_OrderDate
on Orders(CustomerId, OrderDate);
