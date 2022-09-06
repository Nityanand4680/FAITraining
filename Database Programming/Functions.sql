SELECT MAX(EmpSalary) AS MaxSal FROM EMPTABLE
SELECT GETDATE()
--Functions in SQL Server are those that can be used inside a SQL Statement as an Expression. There can be 2 kinds of functions: Scalar value Functions(SVFs) and Table Value Functions(TVFs)

Create Function GetDetails(@empName varchar(50)) RETURNS varchar(250)
BEGIN
RETURN (SELECT (EmpName + ' from ' + EmpAddress) FROM EmpTable Where EmpName = @empName)
END

Create Function GetSalariesOfCity(@city varchar(50)) RETURNS INT
BEGIN
RETURN (SELECT SUM(EmpSalary) FRom Emptable where EmpAddress = @city)
END

Select dbo.GetSalariesOfCity('Bangalore') as BangaloreSalaries

SELECT dbo.GetDetails('Phaniraj')--Execute a Function as an expression of a SELECT Statement. All Functions must be prefixed with the schema name, default name is dbo. So UR Function should be called as dbo.FuncName

----------------Creating TVF-----------------
Create Function GetAllEmployees() --Use this for Queries that return multiple values
RETURNS TABLE -- Defines the return type of this function
AS
RETURN (SELECT * FROM EmpTable) --RETURNS the actual value for this function

SELECT EmpName from dbo.GetAllEmployees() 

--Function to get a valid date given the chars of Year, Month and Date

Create Function CreateDate(@yr varchar(5), @month varchar(5), @date varchar(5))
RETURNS Date
BEGIN
RETURN (Select Cast(@yr + '/' +  @month  + '/' +  @date as Date))
END

Select DATEPART(DAY, dbo.CreateDate('2019','12','23'))
Select DATEDIFF(YEAR, dbo.CreateDate('1976','12','01'),GETDATE()) AS Age--Age of the person.

