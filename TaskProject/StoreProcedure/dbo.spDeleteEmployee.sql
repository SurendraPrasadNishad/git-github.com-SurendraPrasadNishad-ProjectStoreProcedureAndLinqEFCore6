Create Procedure spDeleteEmployee(
@EmployeeId  int
)

AS

BEGIN

SET NOCOUNT ON

DELETE FROM   Employees WHERE EmployeeId=@EmployeeId

END