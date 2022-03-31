CREATE TABLE [dbo].[Employee_Tasks]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Employee_Tasks_ID] DEFAULT (newid()),
[Employee_ID] [uniqueidentifier] NOT NULL,
[Reporter_Employee_ID] [uniqueidentifier] NULL,
[Task_Source_ID] [int] NULL,
[Title] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Description] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Priority] [int] NOT NULL CONSTRAINT [DF_Employee_Tasks_Priority] DEFAULT ((1)),
[Action_Log] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DateCompleted] [datetime] NULL,
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Employee_Tasks_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Employee_Tasks_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employee_Tasks] ADD CONSTRAINT [PK_Employee_Tasks] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employee_Tasks] ADD CONSTRAINT [FK_Employee_Tasks_Employee_ID_TO_Employees_ID] FOREIGN KEY ([Employee_ID]) REFERENCES [dbo].[Employees] ([ID])
GO
ALTER TABLE [dbo].[Employee_Tasks] ADD CONSTRAINT [FK_Employee_Tasks_Reporter_Employee_ID_TO_Employees_ID] FOREIGN KEY ([Reporter_Employee_ID]) REFERENCES [dbo].[Employees] ([ID])
GO
ALTER TABLE [dbo].[Employee_Tasks] ADD CONSTRAINT [FK_Employee_Tasks_Task_Source_ID_TO_SYSTEM_Task_Sources_ID] FOREIGN KEY ([Task_Source_ID]) REFERENCES [dbo].[SYSTEM_Task_Sources] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'EMPLOYEE_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Employee_Tasks', NULL, NULL
GO
