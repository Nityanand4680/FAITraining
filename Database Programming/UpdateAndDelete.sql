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





