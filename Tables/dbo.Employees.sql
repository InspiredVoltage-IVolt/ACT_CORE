CREATE TABLE [dbo].[Employees]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Employees_ID] DEFAULT (newid()),
[Email] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Password] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[FirstName] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LastName] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Title] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[WorkPhone] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[WorkPhoneExt] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[MobilePhone] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[AvatarURL] [nvarchar] (300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[EncryptionKey] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Employment_Status] [int] NOT NULL,
[AdminAccount] [bit] NOT NULL CONSTRAINT [DF_Employees_AdminAccount] DEFAULT ((0)),
[Current_PayRate] [money] NOT NULL CONSTRAINT [DF_Employees_Current_PayRate] DEFAULT ((0)),
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Employees_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Employees_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employees] ADD CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'EMPLOYEE_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Employees', NULL, NULL
GO
