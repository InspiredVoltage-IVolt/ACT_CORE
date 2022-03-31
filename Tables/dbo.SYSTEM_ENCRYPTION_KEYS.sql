CREATE TABLE [dbo].[SYSTEM_ENCRYPTION_KEYS]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Application_Environment_Keys_ID] DEFAULT (newid()),
[Identifier] [nvarchar] (400) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Sub_Identifier] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[KeyValue] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Application_Environment_Keys_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Application_Environment_Keys_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SYSTEM_ENCRYPTION_KEYS] ADD CONSTRAINT [PK_Application_Environment_Keys] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'SYSTEM_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'SYSTEM_ENCRYPTION_KEYS', NULL, NULL
GO
