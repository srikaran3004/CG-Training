CREATE TABLE SportsData
(
    Id INT IDENTITY PRIMARY KEY,
    Name VARCHAR(50),
    Email VARCHAR(100) NULL,
    FatherPhoneNo VARCHAR(15) NULL,
    MotherPhoneNo VARCHAR(15) NULL,
    Landline VARCHAR(15) NULL,
    FriendPhoneNo VARCHAR(15) NULL
);

INSERT INTO SportsData
(Name, Email, FatherPhoneNo, MotherPhoneNo, Landline, FriendPhoneNo)
VALUES
('Srikaran', 'srikaran@gmail.com', NULL, NULL, NULL, NULL);

INSERT INTO SportsData
(Name, Email, FatherPhoneNo, MotherPhoneNo, Landline, FriendPhoneNo)
VALUES
('Pavan', NULL, NULL, '9876543210', NULL, NULL);

INSERT INTO SportsData
(Name, Email, FatherPhoneNo, MotherPhoneNo, Landline, FriendPhoneNo)
VALUES
('Shubanshu', NULL, NULL, NULL, NULL, '9123456789');

INSERT INTO SportsData
(Name, Email, FatherPhoneNo, MotherPhoneNo, Landline, FriendPhoneNo)
VALUES
('Aditya', NULL, NULL, NULL, NULL, NULL);

SELECT * from SportsData;

SELECT Name, ISNULL(Email, 'Email Not Available') AS EmailStatus
FROM SportsData;

SELECT Name,
       COALESCE(FatherPhoneNo, MotherPhoneNo, Landline, FriendPhoneNo) AS PrimaryContact
FROM SportsData;

SELECT Name,
       COALESCE(Email, FatherPhoneNo, MotherPhoneNo, Landline, FriendPhoneNo, 'No Contact Info') AS BestAvailableInfo
FROM SportsData;


