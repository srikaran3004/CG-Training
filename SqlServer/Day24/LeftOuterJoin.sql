INSERT INTO College (StdName, Dept, Year) VALUES
('Srikaran', 'Computer Science', 2),
('Pavan', 'Mechanical', 3),
('Shubanshu', 'Electronics', 1),
('Aditya', 'Civil', 4),
('Neha', 'Computer Science', 2),
('Rahul', 'Mechanical', 1),
('Sneha', 'Electronics', 3),
('Arjun', 'Civil', 2);

-- LEFT OUTER JOIN --
SELECT 
    c.StdId,
    c.StdName,
    h.RoomNo
FROM College c
LEFT OUTER JOIN Hostel_info h
    ON c.StdId = h.Id;

