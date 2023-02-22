CREATE Procedure spGetAllEmployees	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT Employees.EmployeeId,Employees.EmployeeName,Employees.EmployeeAddress,Departments.DepartmentName,Departments.DepartmentId
   FROM Employees
   INNER JOIN Departments
   ON Employees.DepartmentId = Departments.DepartmentId
END