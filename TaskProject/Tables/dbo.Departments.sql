CREATE TABLE [dbo].[Departments] (
    [DepartmentId]   INT            IDENTITY (1, 1) NOT NULL,
    [DepartmentName] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED ([DepartmentId] ASC)
);

