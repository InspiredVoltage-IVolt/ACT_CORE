CREATE TABLE [dbo].[Employee_To_Member]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Employee_ID] [uniqueidentifier] NOT NULL,
[Member_ID] [uniqueidentifier] NOT NULL,
[Owner] [bit] NOT NULL CONSTRAINT [DF_Employee_To_Member_Owner] DEFAULT ((0)),
[Delegate] [bit] NOT NULL CONSTRAINT [DF_Employee_To_Member_Delegate] DEFAULT ((0)),
[Delegate_Permissions] [bigint] NOT NULL CONSTRAINT [DF_Employee_To_Member_Delegate_Permissions] DEFAULT ((0)),
[Delegate_Active] [bit] NOT NULL CONSTRAINT [DF_Employee_To_Member_Delegate_Active] DEFAULT ((0)),
[Deleted] [bit] NOT NULL CONSTRAINT [DF_Employee_To_Member_Deleted] DEFAULT ((0)),
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Employee_To_Member_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Employee_To_Member_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employee_To_Member] ADD CONSTRAINT [PK_Employee_To_Member] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employee_To_Member] ADD CONSTRAINT [FK_Employee_Member_ID_To_Members_ID] FOREIGN KEY ([Member_ID]) REFERENCES [dbo].[Members] ([ID])
GO
ALTER TABLE [dbo].[Employee_To_Member] ADD CONSTRAINT [FK_Employee_To_Member_Employee_ID_TO_Employees_ID] FOREIGN KEY ([Employee_ID]) REFERENCES [dbo].[Employees] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'EMPLOYEE_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Employee_To_Member', NULL, NULL
GO
