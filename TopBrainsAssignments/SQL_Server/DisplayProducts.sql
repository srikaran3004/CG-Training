select p.ProductId, p.ProductName
from Products p
left join Sales s on p.ProductId = s.ProductId
where s.ProductId is null;
