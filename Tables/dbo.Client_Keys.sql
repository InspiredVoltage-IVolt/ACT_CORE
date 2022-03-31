CREATE TABLE [dbo].[Client_Keys]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Client_Keys_ID] DEFAULT (newid()),
[Client_ID] [uniqueidentifier] NOT NULL,
[Application_ID] [uniqueidentifier] NOT NULL,
[EncryptionKey] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[DateTimeImplemented] [datetime] NOT NULL,
[ExpirationDate] [datetime] NULL,
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Client_Keys_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Client_Keys_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Client_Keys] ADD CONSTRAINT [PK_Client_Keys] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Client_Keys] ADD CONSTRAINT [FK_Client_Keys_Application_ID_TO_Applications_ID] FOREIGN KEY ([Application_ID]) REFERENCES [dbo].[Applications] ([ID])
GO
ALTER TABLE [dbo].[Client_Keys] ADD CONSTRAINT [FK_Client_Keys_Client_ID_TO_Clients_ID] FOREIGN KEY ([Client_ID]) REFERENCES [dbo].[Clients] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'CLIENT_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Client_Keys', NULL, NULL
GO
