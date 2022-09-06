------------Triggers------------------
--Triggers are sp kind of Stored procs that are executed on satisfying a certain condition like insert, delete or update. They are invoked automatically like Events of UI. When a perticular action is done, it will raise that trigger accordingly. Usually triggers are used to generate backups of UR data when deletions, updations happen. 
--Triggers are called as Sp Stored Procs as U dont/cant call them. They are invoked by SQL server when a certain operation is done on the SQL object. 
--Some of the points: U cannot call a Trigger to invoke. It does not take any parameters. A Transaction cannot be commited or rolled back in a Trigger. 
--Triggers are usefull when we need to execute a set of statements automatically on a certain scenario. Most common scenario is to backup the data when a deletion or Updation happens. U might consider to modify another related table when an insertion happens to the master table. 
-------------TABLE that contains details of the Customer-------------
Create table Customer
(
  CustID int primary key,
  CustName varchar(50) NOT NULL,
  CustAddress varchar(200) NOT NULL,
  BillDate date DEFAULT GETDATE(),
  BillAmount money
)

-----------Table that contains the Audit info when data is updated to the Customer----
Create table CustomerAudit
(
	id int primary key identity(1, 1),
	details varchar(200) NOT NULL
)

Create trigger OnInsertCustomer
ON Customer
For INSERT
AS
BEGIN
  Declare @id int 
  Select @id = CustID from inserted
  Insert into CustomerAudit Values('Customer with Id ' + CAST(@id As varchar) + ' is inserted to database ')
END
--inserted is a temp Table created by SQL server when it raises the Trigger. It will contain the row details of the inserted record. 
Insert into Customer(CustID, CustName, CustAddress, BillAmount) values(101, 'Phaniraj','Bangalore',5600)

Create Trigger OnDeleteCustomer
ON CUSTOMER
AFTER DELETE
AS
BEGIN
Declare @id int
Select @id = CustID from deleted
Insert into CustomerAudit values('Customer with Id ' + Cast(@id as varchar) + ' is deleted from the database')
END

Create Trigger OnUpdateCustomer
ON CUSTOMER
AFTER UPDATE
AS
BEGIN
Declare @id int
Declare @newName varchar(50)
Declare @oldName varchar(50)
Select @id = CustID from inserted
Select @oldName = CustName From deleted
Select @newName = CustName from inserted
Insert into CustomerAudit values('Customer with Id ' + Cast(@id as varchar) + ' is updated with ' + @newName +' replacing the ' + @oldName )
END

Create Function GetInsertionsCount() RETURNS int
BEGIN
	return (select Count(*) from CustomerAudit where details like '%insert%')
END

Delete From Customer where CustID = 101
SEleCT * FROM Customer
Select * from CustomerAudit

Update Customer set CustName = 'Gopal' where CustID = 101

Select dbo.GetInsertionsCount() as TotalInsertions

