--Gets the Avg Salary of every dept in the EmpTable using Group By Clause.
Select EmpTable.DeptId, Avg(EmpTable.EmpSalary) from Emptable group by EmpTable.DeptId

Select EmpTable.EmpAddress, Avg(EmpSalary) as AvgSalary From EmpTable group by EmpTable.EmpAddress

--------------------Using WHERE CLAUSE---------------------------
SELECT * FROM EMPTABLE WHERE EmpName like '%mar%' --Similar to contains....
SELECT * FROM EMPTABLE WHERE EmpName like 'A%' -- Similar to Starts With
SELECT EmpName, EmpAddress, EmpSalary From EmpTable where EmpAddress = 'Bangalore' AND EmpSalary < 100000 -- Checks for both the conditions. 

Select Empname, EmpAddress from Emptable where EmpAddress = 'Bangalore' OR EmpAddress = 'Mysore'

Select EmpName, EmpAddress, EmpSalary From EmpTable where NOT EmpAddress = 'Bangalore' And (EmpSalary < 50000 OR EmpSalary > 100000) --Using NOT with AND and OR
--------------------------Using ORDER BY----------------------------------------------------
SELECT Empname, EmpAddress from EmpTable Order by EmpName, EmpAddress DESC --Sorting by first Name and then Address


----------------------------------JOINS --------------------------------------------------------
--Combining data from 2 or more tables is called as JOIN. Common Join is inner join. 
SELECT EmpTable.*, DeptName from EmpTable JOIN DeptTable
ON EmpTable.DeptId = DeptTable.DeptId
--INNER JOIN is the most common joins we do while combining 2 or more tables. It fetches the data that is common in both the tables based on the ON Condition. It is the default join for SQL server.  

-----------------LEFT JOIN: Gets all the elements of the left table and gets common data from the right table. 
--Get all the elements of the left table along with matching elements of the right table. To make this work, U can remove the NOT NULL Constraint in the EmpTable and add new records without any DeptID. 
Select EmpTable.*, DeptTable.DeptName From EmpTable LEFT JOIN DeptTable
ON EmpTable.DeptId = DeptTable.DeptId

Insert into EmpTable(EmpName, EmpAddress, EmpSalary, DateOfBirth) Values('David warner', 'Hyderabad', 50000, '08-24-1983')

Insert into DeptTable values('Transport')
Insert into DeptTable values('HouseKeeping')

----------------------------Right Join-------------
Select EmpTable.*, DeptName from Emptable right join DeptTable
on EmpTable.DeptId = DeptTable.DeptId where DeptTable.DeptId >= 1
-------------------------------SELF join-----------------------------
Select E.EmpName As EmployeeName, B.EmpName as EmployeeName2, E.EmpAddress 
From EmpTable E, EmpTable B
WHERE E.EmpId <> B.EmpId --Not Equals in SQL....
AND E.EmpAddress = B.EmpAddress
Order By B.EmpAddress

---------------------SELECT INTO Statement for copying data from one table into another. 
Select * INTO EmpRecords From EmpTable WHere EmpAddress = 'Bangalore'

--U could also insert the records using Insert into statement in conjunction with select statement.
Insert Into EmpRecords(EmpName, EmpAddress, EmpSalary)  SELECT EmpName, EmpAddress, EmpSalary From EmpTable WHERE EmpAddress = 'Shimoga'
Select * from EmpRecords

Select EmpName, EmpAddress, ISNULL(dateOfBirth, '') From EmpRecords --Checks if the value is null, then replace it with other value. 

Select Empname, EmpAddress, COALESCE(DeptId, 0) As DeptId FROM EmpRecords
--Get Names, Addresses and DeptName for every employee, if the deptname does not exist, it should be shown as Unallocated


Select EmpName, EmpAddress, COALESCE(DeptName, 'Unallocated') As DeptName From EmpRecords Left join DeptTable on EmpRecords.DeptId = DeptTable.DeptId




