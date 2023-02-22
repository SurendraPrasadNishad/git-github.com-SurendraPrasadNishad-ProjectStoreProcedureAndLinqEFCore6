CREATE Procedure spGetDepartmentById @DepartmentId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT * FROM Departments
	Where DepartmentId=@DepartmentId;
   
END