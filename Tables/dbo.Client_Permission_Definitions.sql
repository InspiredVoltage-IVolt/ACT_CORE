CREATE TABLE [dbo].[Client_Permission_Definitions]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Client_ID] [uniqueidentifier] NULL,
[Application_ID] [uniqueidentifier] NULL,
[BitPosition] [int] NOT NULL,
[Permission_Name] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Client_Permission_Definitions_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Client_Permission_Definitions_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Client_Permission_Definitions] ADD CONSTRAINT [PK_Client_Permission_Definitions] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Client_Permission_Definitions] ADD CONSTRAINT [FK_Client_Permission_Definitions_Applications] FOREIGN KEY ([Application_ID]) REFERENCES [dbo].[Applications] ([ID])
GO
ALTER TABLE [dbo].[Client_Permission_Definitions] ADD CONSTRAINT [FK_Client_Permission_Definitions_Clients] FOREIGN KEY ([Client_ID]) REFERENCES [dbo].[Clients] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'CLIENT_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Client_Permission_Definitions', NULL, NULL
GO
