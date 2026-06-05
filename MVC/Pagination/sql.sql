USE MVC_EF_CodeFirst;
GO

-- 1. Create the Orders table
CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName VARCHAR(100),
    Product VARCHAR(100),
    Quantity INT,
    Price DECIMAL(10,2),
    OrderDate DATE
);
GO

-- 2. Insert 50 sample records
INSERT INTO Orders (CustomerName, Product, Quantity, Price, OrderDate) VALUES
('John Smith', 'Laptop', 1, 75000.00, '2025-01-05'),
('Emma Johnson', 'Mouse', 3, 500.00, '2025-01-06'),
('Liam Williams', 'Keyboard', 2, 1500.00, '2025-01-07'),
('Olivia Brown', 'Monitor', 1, 22000.00, '2025-01-08'),
('Noah Jones', 'Headphones', 2, 3000.00, '2025-01-09'),
('Ava Garcia', 'USB Cable', 5, 200.00, '2025-01-10'),
('William Miller', 'Webcam', 1, 4500.00, '2025-01-11'),
('Sophia Davis', 'Tablet', 1, 30000.00, '2025-01-12'),
('James Rodriguez', 'Printer', 1, 15000.00, '2025-01-13'),
('Isabella Martinez', 'Chair', 2, 8000.00, '2025-01-14'),
('Benjamin Hernandez', 'Desk', 1, 12000.00, '2025-01-15'),
('Mia Lopez', 'Phone', 1, 45000.00, '2025-01-16'),
('Lucas Gonzalez', 'Charger', 3, 800.00, '2025-01-17'),
('Charlotte Wilson', 'SSD', 2, 5000.00, '2025-01-18'),
('Henry Anderson', 'RAM', 4, 3500.00, '2025-01-19'),
('Amelia Thomas', 'Router', 1, 2500.00, '2025-01-20'),
('Alexander Taylor', 'Speaker', 2, 6000.00, '2025-01-21'),
('Harper Moore', 'Pen Drive', 5, 400.00, '2025-01-22'),
('Daniel Jackson', 'Hard Disk', 1, 4000.00, '2025-01-23'),
('Evelyn Martin', 'Mouse Pad', 3, 300.00, '2025-01-24'),
('Matthew Lee', 'Laptop Stand', 1, 2000.00, '2025-01-25'),
('Abigail Perez', 'Graphics Card', 1, 55000.00, '2025-01-26'),
('Joseph Thompson', 'Power Bank', 2, 1500.00, '2025-01-27'),
('Emily White', 'Smartwatch', 1, 12000.00, '2025-01-28'),
('Samuel Harris', 'Earbuds', 3, 2000.00, '2025-01-29'),
('Elizabeth Sanchez', 'Camera', 1, 35000.00, '2025-01-30'),
('David Clark', 'Tripod', 1, 3000.00, '2025-01-31'),
('Sofia Ramirez', 'Microphone', 1, 7000.00, '2025-02-01'),
('Carter Lewis', 'LED Light', 2, 1000.00, '2025-02-02'),
('Avery Robinson', 'Projector', 1, 40000.00, '2025-02-03'),
('Wyatt Walker', 'Scanner', 1, 10000.00, '2025-02-04'),
('Ella Young', 'Stylus Pen', 2, 1500.00, '2025-02-05'),
('Jayden Allen', 'Monitor Arm', 1, 3500.00, '2025-02-06'),
('Scarlett King', 'Ethernet Cable', 4, 250.00, '2025-02-07'),
('Luke Wright', 'UPS', 1, 5000.00, '2025-02-08'),
('Grace Scott', 'HDMI Cable', 3, 350.00, '2025-02-09'),
('Julian Torres', 'Cooling Pad', 1, 1800.00, '2025-02-10'),
('Chloe Nguyen', 'Docking Station', 1, 8000.00, '2025-02-11'),
('Levi Hill', 'Surge Protector', 2, 600.00, '2025-02-12'),
('Victoria Flores', 'Cable Organizer', 3, 400.00, '2025-02-13'),
('Isaac Green', 'Laptop Bag', 1, 2500.00, '2025-02-14'),
('Hannah Adams', 'Screen Guard', 5, 300.00, '2025-02-15'),
('Gabriel Nelson', 'Adapter', 2, 700.00, '2025-02-16'),
('Lily Baker', 'Bluetooth Dongle', 3, 500.00, '2025-02-17'),
('Anthony Hall', 'Motherboard', 1, 18000.00, '2025-02-18'),
('Zoey Rivera', 'CPU', 1, 25000.00, '2025-02-19'),
('Dylan Campbell', 'Cabinet', 1, 6000.00, '2025-02-20'),
('Nora Mitchell', 'Fan', 2, 800.00, '2025-02-21'),
('Jack Carter', 'Thermal Paste', 3, 350.00, '2025-02-22'),
('Aria Roberts', 'Keyboard Cover', 2, 250.00, '2025-02-23');
GO

-- 3. Create the stored procedure
CREATE OR ALTER PROCEDURE showthispageorders
    @st INT,
    @en INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Orders WHERE OrderID >= @st AND OrderID <= @en;
END
GO

EXEC showthispageorders 1, 10;