CREATE TABLE [dbo].[Application_Environments]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Application_Environments_ID] DEFAULT ('newid()'),
[Application_ID] [uniqueidentifier] NULL,
[Member_ID] [uniqueidentifier] NULL,
[Name] [nvarchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Symbols] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DateAdded] [datetime] NOT NULL,
[DateModified] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Application_Environments] ADD CONSTRAINT [PK_ID_Application_Environments] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Application_Environments] ADD CONSTRAINT [FK_Application_Environments_Applications] FOREIGN KEY ([Application_ID]) REFERENCES [dbo].[Applications] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'APPLICATION_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Application_Environments', NULL, NULL
GO
