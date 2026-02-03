--1NF maintain one-to-one relationship

--2NF remove duplicates having same ID

--3NF No transitive dependency, 
-- StudentID	DeptID	DeptName
--DeptName depends on DeptID, not StudentID ? transitive dependency.

/*

| Normal Form | Removes                         |
| ----------- | ------------------------------- |
| 1NF         | Repeating groups / multi-values |
| 2NF         | Partial dependency              |
| 3NF         | Transitive dependency           |
| BCNF        | Key-based dependency anomalies  |
| 4NF         | Multi-valued dependency         |
| 5NF         | Join dependency redundancy      |

*/
