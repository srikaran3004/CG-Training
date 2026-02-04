select s1.ProductId,
       s1.SaleMonth,
       sum(s2.Amount) as RunningTotal
from Sales s1
join Sales s2
  on s1.ProductId = s2.ProductId
 and s2.SaleMonth <= s1.SaleMonth
group by s1.ProductId, s1.SaleMonth
order by s1.ProductId, s1.SaleMonth;
