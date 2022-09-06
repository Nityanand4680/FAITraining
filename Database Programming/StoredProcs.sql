----------------------------Stored Procedure in SQL server----------------------------------
--Stored Procedures are prepared statements that are created in SQL server to make them execute with out a need to parse them whenever we use it. Creating a Proc is similar to create any other SQL object.
--Stored proc cannot be used as an Expression within a SQL statement. 

alter Procedure Fai_InsertEmployee
@name varchar(50),
@address varchar(200),
@salary money, 
@dob date,
@deptId int,
@empId int OUTPUT -- This parameter is the output parameter, means after executing the Proc, U can retrive the value. 
AS
INSERT INTO EmpTable Values(@name, @address, @salary, @dob, @deptId)
Set @empId = @@IDENTITY --@IDENTITY is a predefined variable of SQL server that provides the Identity value of the recently inserted row. Note that all variables of SQL server willbe prefixed with @@ and variables of the users/developers will be with @. 


DECLARE @id int --Syntax to declare variable in SQL server. 
EXEC Fai_InsertEmployee 'Jim Cobert', 'London', 46000, '06-15-1976', 2, @id OUTPUT
PRINT @id


Create Procedure Fai_UpdateEmployee
@id int, @name varchar(50), @address varchar(200), @salary money, @dob date, @deptId int
AS
UPDATE EmpTable Set EmpName = @name, EmpAddress = @address, EmpSalary = @salary, DateOfBirth = @dob, DeptId = @deptId
WHERE EmpId = @id

EXEC Fai_UpdateEmployee 116, 'Rajiv Mehta','Lucknow', 45000, '05-24-1986', 4
---------Fai_FindEmployeeByName, Fai_FindEmployeeByAddress

Create Procedure Fai_FindEmployeeByName
@name varchar(50)
AS
SELECT * FROM EmpTable WHERE EmpName LIKE '%' + @name + '%'

EXEC Fai_FindEmployeeByName 'Jim'

Create Procedure Fai_FindEmployeeByAddress
@address varchar(50)
AS
SELECT * FROM EmpTable WHERE EmpAddress =@address

EXEC Fai_FindEmployeeByAddress 'Lucknow'