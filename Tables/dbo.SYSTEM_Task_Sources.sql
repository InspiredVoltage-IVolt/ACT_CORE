CREATE TABLE [dbo].[SYSTEM_Task_Sources]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Priority] [int] NOT NULL CONSTRAINT [DF_SYSTEM_Task_Sources_Priority] DEFAULT ((1)),
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_SYSTEM_Task_Sources_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_SYSTEM_Task_Sources_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SYSTEM_Task_Sources] ADD CONSTRAINT [PK_SYSTEM_Task_Sources] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'SYSTEM_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'SYSTEM_Task_Sources', NULL, NULL
GO
