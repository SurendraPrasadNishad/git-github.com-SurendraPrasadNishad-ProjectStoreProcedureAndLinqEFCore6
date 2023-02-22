using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using TaskProject.Models;

#nullable disable

namespace TaskProject.Migrations
{
    public partial class spCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeAddress",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentName",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId");

            //StoreProcedure
var sp1 = @"CREATE PROCEDURE spCreateEmployee(
       @EmployeeName nvarchar,
       @EmployeeAddress nvarchar,
       @DepartmentId int
              )

       AS
       BEGIN

          SET NOCOUNT ON

      insert into Employees(EmployeeName, EmployeeAddress, DepartmentId)
      values(@EmployeeName, @EmployeeAddress, @DepartmentId)

       END";
            migrationBuilder.Sql(sp1);

            var sp2 = @"CREATE PROCEDURE spDeleteEmployee(
@EmployeeId  int
)

AS

BEGIN

SET NOCOUNT ON

DELETE FROM Employees WHERE EmployeeId = @EmployeeId

END";
            migrationBuilder.Sql(sp2);

            var sp3 = @"CREATE PROCEDURE spGetAllDepartments
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from

    --interfering with SELECT statements.

    SET NOCOUNT ON;
            SELECT* FROM Departments;

            END";
            migrationBuilder.Sql(sp3);
            var sp4 = @"CREATE PROCEDURE spGetAllEmployees
            AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from

    --interfering with SELECT statements.

    SET NOCOUNT ON;
            SELECT Employees.EmployeeId,Employees.EmployeeName,Employees.EmployeeAddress,Departments.DepartmentName,Departments.DepartmentId
           FROM Employees
           INNER JOIN Departments
   ON Employees.DepartmentId = Departments.DepartmentId
 END";
            migrationBuilder.Sql(sp4);
            var sp5 = @"CREATE PROCEDURE spGetDepartmentById @DepartmentId int
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from

    --interfering with SELECT statements.

    SET NOCOUNT ON;
            SELECT* FROM Departments
            Where DepartmentId = @DepartmentId;

          END";
            migrationBuilder.Sql(sp5);
            var sp6 = @"CREATE PROCEDURE spGetEmployeeById
(
@EmployeeId int
)
AS
BEGIN

    --SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.

    SET NOCOUNT ON;
            SELECT Employees.EmployeeId,Employees.EmployeeName,Employees.EmployeeAddress,Departments.DepartmentName,Departments.DepartmentId
           FROM Employees , Departments
   Where(Employees.DepartmentId = Departments.DepartmentId) AND(Employees.EmployeeId = @EmployeeId);
            END";
            migrationBuilder.Sql(sp6);
            var sp7 = @"CREATE PROCEDURE spUpdateEmployee(

            @EmployeeId  int,
            @EmployeeName nvarchar(MAX),
            @EmployeeAddress nvarchar(MAX),
            @DepartmentId int
            )

AS

BEGIN

SET NOCOUNT ON

update  Employees SET EmployeeName = @EmployeeName,EmployeeAddress = @EmployeeAddress,DepartmentId = @DepartmentId WHERE EmployeeId = @EmployeeId
 END";
            migrationBuilder.Sql(sp7);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeAddress",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentName",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
