CREATE Procedure spGetEmployeeById
(
@EmployeeId int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT Employees.EmployeeId,Employees.EmployeeName,Employees.EmployeeAddress,Departments.DepartmentName,Departments.DepartmentId
   FROM Employees , Departments
   Where (Employees.DepartmentId = Departments.DepartmentId) AND  (Employees.EmployeeId=@EmployeeId);
END