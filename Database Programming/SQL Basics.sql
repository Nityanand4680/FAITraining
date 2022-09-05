---Create the database on UR Name----------------
Create database SampleFaiDatabase--Used to create the database. Database name  should be unique for the server. 

--Drop database SampleFaiDatabase --Used to delete the database

-----------------------Modifying an Existing database------------------
ALTER DATABASE SampleFaiDatabase
MODIFY NAME = FaiTraining

sp_databases-- is the stored proc of SQL server used to get all the databases of the SQL server instance. 

sp_renamedb RenamedFaiTraining , FaiTraining--Stored proc for renaming an existing database.
--------------Use an existing database---------------------------
use FaiTraining --Use is called to associate UR SQL statements on a perticular db...
--------------------Creating tables in SQL server------------------

Create table EmpTable
(
	EmpId int PRIMARY KEY IDENTITY(1, 1),
	EmpName varchar(50) NOT NULL, 
	EmpAddress varchar(200)NOT NULL, 
	EmpSalary money NOT NULL
)--Creates a new Table if it does not exist, else throws an Exception. 

sp_tables ---Stored Proc to find all the tables of UR database. 
sp_columns EmpTable -- To get the schema of the table defined in the command

Drop table EmpTable
--Create a table called DeptTable that has 2 columns: DeptId and DeptName. The DeptId is primary key. 

Create table DeptTable
(
 DeptId int primary key identity(1,1),
 DeptName varchar(50) NOT NULL
)
-----------------Adding new COLUMN to an existing table-----------------------
ALTER TABLE EmpTable 
ADD DeptId int not null 
references DeptTable(DeptId)--Relates to the DeptID of the DeptTable. The value in this column must be any of the values from the DeptID Column of the DeptTable. If not found, then the data will not be inserted.

Alter table EmpTable
Add DateOfBirth Date


------------------Droping a Column from the existing table-----------
Alter table EmpTable
Drop column DeptId
Alter Table DeptTable
Drop column DeptID

Alter table EmpTable
Drop constraint FK__EmpTable__DeptId__3B75D760 --To remove the FK Constraint for the table. Constraint means Rules. 

DROP TABLE DEPTTABLE
DROP TABLE EmpTable
--Rules: U cannot drop a column that is referenced in another table. In that case, U should drop the relation and then drop the column. 
------------------------------------------------------------------------------
sp_columns EmpTable -- Lists the columns and Schema details of the table
sp_rename EmployeeList, EmpTable  -- For changing the name of the table in the database

------------Final Schema of both the tables:
Create table DeptTable
(
 DeptId int primary key identity(1,1),
 DeptName varchar(50) NOT NULL
)

Create table EmpTable
(
	EmpId int PRIMARY KEY IDENTITY(1, 1),
	EmpName varchar(50) NOT NULL, 
	EmpAddress varchar(200)NOT NULL, 
	EmpSalary money NOT NULL,
	DeptId int NOT NULL References DeptTable(DeptID),
	DateOfBirth Date
)
--------------------Insert record to the table-------------------------------
Insert into DeptTable values('Training')
Insert into DeptTable values('HR')
Insert into DeptTable values('Production')
Insert into DeptTable values('IT')
Insert into DeptTable values('Operations')
--Identity column data need not be added. If U try to add, it will throw an Error. 

---Read the data:
Select * from DeptTable
Select Count(*) From DeptTable
Select Count(*) As NoOfDepts From DeptTable --Count is a Function that returns the no of rows. * is wild char for all. 
Select Distinct DeptName From DeptTable --Used to get distinct values (No Duplicates).
Select Count(Distinct DeptName) as DeptNames From DeptTable --Used to get the No of Unique Depts. 
Select DeptName from DeptTable WHERE DEPTID = 3 -- Where clause

sp_columns EMpTable
--------------------Inserting the EmpData into the EmpTable------------------------
Insert into EmpTable values('Phaniraj','Bangalore', 67000,1 , '01-12-1976')
Insert into EmpTable values('Radha K','Ananthapur', 78000, 2, '12-10-1976')
Insert into EmpTable values('Vinod Kumar','Shimoga', 178000, 3, '12-08-1974')
Insert into EmpTable values('Phani Shroff','Hosapete', 66000, 4, '12-10-1973')
Insert into EmpTable values('Venkatesh','Mysore', 71000, 5, '04-24-1977')
Insert into EmpTable values('Sumanth','Bangalore', 74000, 2, '05-18-1980')

Insert into EmpTable(EmpName, EmpAddress, EmpSalary, DeptId) Values('Kumar','Hyderabad', 55000, 3)

Select Count(*) from Emptable
Select distinct EmpAddress from EmpTable
Select * from Emptable

Select * from EMpTable where EmpAddress = 'Bangalore'
Select Avg(EmpSalary) As AvgSalary from EMpTable where EmpAddress = 'Bangalore'
Select SUM(EmpSalary) As TotalSalariesOfBLR from EMpTable where EmpAddress = 'Bangalore'
Select MAX(EmpSalary) As MaxOfBLR from EMpTable where EmpAddress = 'Bangalore'
Select Min(EmpSalary) As MinOfBLR from EMpTable where EmpAddress = 'Bangalore'

Select Avg(EmpSalary) As AvgSalary, SUM(EmpSalary) As TotalSalariesOfBLR,  MAX(EmpSalary) As MaxOfBLR, Min(EmpSalary) As MinOfBLR from EMpTable where EmpAddress = 'Bangalore'
