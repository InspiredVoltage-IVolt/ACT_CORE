CREATE TABLE [dbo].[SYSTEM_PLUGINS]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_SYSTEM_PLUGINS_ID] DEFAULT (newid()),
[Member_ID] [uniqueidentifier] NOT NULL,
[Company_ID] [uniqueidentifier] NULL,
[Client_ID] [uniqueidentifier] NULL,
[FullClassName] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[FileName] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Type] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[StoreOnce] [bit] NOT NULL CONSTRAINT [DF_SYSTEM_PLUGINS_StoreOnce] DEFAULT ((1)),
[CheckSum] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[LicenseKey] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[ExecutionOrder] [int] NOT NULL CONSTRAINT [DF_SYSTEM_PLUGINS_Order] DEFAULT ((1)),
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_SYSTEM_PLUGINS_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_SYSTEM_PLUGINS_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SYSTEM_PLUGINS] ADD CONSTRAINT [PK_SYSTEM_PLUGINS] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'SYSTEM_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'SYSTEM_PLUGINS', NULL, NULL
GO
