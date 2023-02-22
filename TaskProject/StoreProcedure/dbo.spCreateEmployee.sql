Create Procedure spCreateEmployee	 (
@EmployeeName nvarchar,
@EmployeeAddress nvarchar,
@DepartmentId int
)

AS

BEGIN

SET NOCOUNT ON

insert into Employees(EmployeeName,EmployeeAddress,DepartmentId)
values (@EmployeeName,@EmployeeAddress,@DepartmentId)

END