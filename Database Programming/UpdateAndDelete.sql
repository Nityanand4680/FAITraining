------------------------Update statement-------------------

Update EmpRecords Set DeptId = 4 Where DeptId IS NULL --For T-SQL use IS NULL 

SELECT * FROM EmpRecords
--If U dont provide the where clause, all the records will be updated. 

--UPDATE TABLENAME SET COLNAME = VALUE WHERE COLNAME = Condition 
------------------Delete Statement----------------------
Delete From EmpRecords where DeptID = 4
--DELETE FROM TABLENAME CONDITION




---------------------Truncate Statement--------------------
TRUNCATE TABLE EmpRecords --Used to remove the data of the table without deleting the table object. For removal of the table object use DROP TABLE Command. 
SELECT TOP(50) EmpName FROM EMPTABLE
SELECT EMpName From EmpTable where EmpSalary between 100000 and 150000.
--------------Nested query in SQL---------------------
SELECT EmpTable.* from EmpTable WHERE EmpSalary = (SELECT MAX(EmpSalary) FROM EmpTable)

--Get the records whose salary is more than the avg salary of the company...

SELECT EMPNAME, COUNT(EmpName) AS EMPCOUNT FROM EMPTABLE 
GROUP BY EMPNAME Having COUNT(EmpName) > 1 



