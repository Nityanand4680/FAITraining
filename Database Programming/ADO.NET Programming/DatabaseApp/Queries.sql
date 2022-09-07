CREATE PROCEDURE FaiTraining_UpdateTest
	@tId int, 
	@tName	varchar(50),
	@tAmount money, 
	@tDate date = '03/24/2022'
AS
	UPDATE TestTable Set TestName = @tName, TestAmount = @tAmount, TestDate = @tDate WHERE TestId = @tId
  
  CREATE PROCEDURE [dbo].FaiTraining_InsertTest
	@tName	varchar(50),
	@tAmount money, 
	@tDate date = '03/24/2022',
	@tId int OUTPUT
AS
	INSERT INTO TestTable(TestName, TestAmount, TestDate) VALUES(@tName, @tAmount, @tDate)
	SET @tId = @@IDENTITY
