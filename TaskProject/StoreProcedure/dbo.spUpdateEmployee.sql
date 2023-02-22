Create Procedure spUpdateEmployee(

@EmployeeId  int,
@EmployeeName nvarchar(MAX),
@EmployeeAddress nvarchar(MAX),
@DepartmentId int
)

AS

BEGIN

SET NOCOUNT ON

update  Employees SET EmployeeName=@EmployeeName,EmployeeAddress=@EmployeeAddress,DepartmentId=@DepartmentId WHERE EmployeeId=@EmployeeId

END