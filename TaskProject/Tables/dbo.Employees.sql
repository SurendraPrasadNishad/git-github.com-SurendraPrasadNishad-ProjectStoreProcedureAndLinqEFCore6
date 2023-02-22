CREATE TABLE [dbo].[Employees] (
    [EmployeeId]      INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeName]    NVARCHAR (MAX) NOT NULL,
    [EmployeeAddress] NVARCHAR (MAX) NOT NULL,
    [DepartmentId]    INT            NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([EmployeeId] ASC),
    CONSTRAINT [FK_Employees_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Departments] ([DepartmentId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Employees_DepartmentId]
    ON [dbo].[Employees]([DepartmentId] ASC);

