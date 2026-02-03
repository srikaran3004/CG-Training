INSERT INTO Employee_master (Name, Salary, Pf, Bonus, Age) VALUES
('Srikaran', 25000, 1200, 2000, 21),
('Siva',      22000, 1100, 1500, 22),
('Pavan',     24000, 1150, 1800, 20),
('Shubhanshu',26000, 1300, 2200, 22),
('Aditya',    23000, 1000, 1600, 21);

INSERT INTO Canteen (EmployeeId, ItemName, Price, Date_and_Time) VALUES
(1, 'Sandwich', 50, '2026-01-23'),
(1, 'Tea', 15, '2026-01-23'),
(2, 'Coffee', 20, '2026-01-23'),
(2, 'Burger', 80, '2026-01-24'),
(3, 'Juice', 40, '2026-01-23'),
(3, 'Samosa', 10, '2026-01-25'),
(4, 'Pizza', 120, '2026-01-23'),
(4, 'Cold Drink', 35, '2026-01-24'),
(5, 'Noodles', 70, '2026-01-23'),
(5, 'Tea', 15, '2026-01-25');

-- 1. How much do I need to pay? --
select e.Name, sum(c.price) as total_amt_to_pay from Canteen c
join Employee_master e on c.EmployeeId=e.Id
-- WHERE e.Name = 'Srikaran' 
group by e.Name;

-- 2. On Jan 23rd, how much did I purchase & what items?--
SELECT 
    e.Name,
    c.ItemName,
    c.Price,
    c.Date_and_Time
FROM Canteen c
JOIN Employee_master e ON c.EmployeeId = e.Id
WHERE e.Name = 'Srikaran' AND c.Date_and_Time = '2026-01-23';

-- 3. Who purchased the highest amount overall?--
SELECT TOP 1
    e.Name,
    SUM(c.Price) AS Total_Spent
FROM Canteen c
JOIN Employee_master e ON c.EmployeeId = e.Id
GROUP BY e.Name
ORDER BY Total_Spent DESC;
