use StoredProcedureAssignment;

CREATE TABLE Customers
(
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    PhoneNumber VARCHAR(15),
    City VARCHAR(50),
    CreatedDate DATE
);

CREATE TABLE Accounts
(
    AccountID INT PRIMARY KEY,
    CustomerID INT,
    AccountNumber VARCHAR(20),
    AccountType VARCHAR(20), -- Savings / Current
    OpeningBalance DECIMAL(12,2),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE Transactions
(
    TransactionID INT PRIMARY KEY,
    AccountID INT,
    TransactionDate DATE,
    TransactionType VARCHAR(10), -- Deposit / Withdraw
    Amount DECIMAL(12,2),
    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
);

CREATE TABLE Bonus
(
    BonusID INT PRIMARY KEY,
    AccountID INT,
    BonusMonth INT,
    BonusYear INT,
    BonusAmount DECIMAL(10,2),
    CreatedDate DATE,
    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
);

insert into Customers values
(1,'Srikaran','9849956895','Hyderabad','2023-02-10'),
(2,'Pavan','9012223334','Godavari','2023-05-18'),
(3,'Subhanshu','9023334445','Varanasi','2023-07-22'),
(4,'Aditya','9034445556','Patna','2023-09-30');

insert into Accounts values
(201,1,'SB2001','Savings',25000),
(202,2,'SB2002','Savings',18000),
(203,3,'SB2003','Savings',40000),
(204,4,'SB2004','Savings',12000);

insert into Transactions values
(1,201,'2024-01-05','Deposit',30000),
(2,201,'2024-01-15','Deposit',25000),
(3,201,'2024-01-28','Withdraw',10000),

(4,202,'2024-01-10','Deposit',20000),
(5,202,'2024-01-22','Deposit',15000),
(6,202,'2024-02-05','Deposit',40000),

(7,203,'2024-01-12','Deposit',10000),
(8,203,'2024-01-25','Withdraw',5000),

(9,204,'2024-02-01','Deposit',60000),
(10,204,'2024-02-18','Withdraw',10000);

insert into Transactions values
(11, 202, '2024-03-05', 'Deposit', 30000),
(12, 202, '2024-03-20', 'Deposit', 40000);

insert into Transactions values
(13, 203, '2024-04-02', 'Deposit', 35000),
(14, 203, '2024-04-18', 'Deposit', 30000);



--Q1. Get transaction details by start,end, acc id--
create procedure usp_transactionDetails
@StartDate date, @EndDate date, @AccountID int
as
begin
select TransactionType, sum(Amount) as totalAmount from Transactions
where AccountID = @AccountID and TransactionDate between @StartDate and @EndDate
group by TransactionType;
end;

exec usp_transactionDetails '2024-01-01','2024-01-31',201;

--Q2. Monthly bonus update--
insert into Bonus (AccountID, BonusMonth, BonusYear, BonusAmount, CreatedDate)
select AccountID, month(TransactionDate), year(TransactionDate), 1000,getdate()
from Transactions t
where TransactionType = 'Deposit'group by AccountID, month(TransactionDate), year(TransactionDate)
having sum(Amount) > 50000
and not exists (select 1 from Bonus b where b.AccountID = t.AccountID and b.BonusMonth = month(t.TransactionDate)
and b.BonusYear = year(t.TransactionDate)
);


--Q3. Check Current Balance--
select c.CustomerName, a.AccountNumber, a.OpeningBalance
+ sum(case when t.TransactionType = 'Deposit' then t.Amount else 0 end)
- sum(case when t.TransactionType = 'Withdraw' then t.Amount else 0 end)
+ sum(case when b.BonusAmount is not null then b.BonusAmount else 0 end) as CurrentBalance
from Accounts a
join Customers c on a.CustomerID = c.CustomerID
left join Transactions t on a.AccountID = t.AccountID
left join Bonus b on a.AccountID = b.AccountID
group by c.CustomerName, a.AccountNumber, a.OpeningBalance;


