CREATE TABLE [dbo].[Cross_Client_Permissions]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Client_ID] [uniqueidentifier] NULL,
[Client_B_ID] [uniqueidentifier] NULL,
[Decline_Cross_Members] [bit] NOT NULL CONSTRAINT [DF_Cross_Client_Permissions_Decline_Cross_Members] DEFAULT ((0)),
[Monitor_Cross_Members] [bit] NOT NULL CONSTRAINT [DF_Cross_Client_Permissions_Monitor_Cross_Members] DEFAULT ((0)),
[Decline_Members_ManyClients] [bit] NOT NULL,
[Monitor_Members_ManyClients] [bit] NOT NULL,
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Cross_Client_Permissions_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Cross_Client_Permissions_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cross_Client_Permissions] ADD CONSTRAINT [PK_Cross_Client_Permissions] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cross_Client_Permissions] ADD CONSTRAINT [FK_Cross_Client_Permissions_Client_B_ID_TO_Clients_ID] FOREIGN KEY ([Client_B_ID]) REFERENCES [dbo].[Clients] ([ID])
GO
ALTER TABLE [dbo].[Cross_Client_Permissions] ADD CONSTRAINT [FK_Cross_Client_Permissions_Client_ID_TO_Clients_ID] FOREIGN KEY ([Client_ID]) REFERENCES [dbo].[Clients] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'CLIENT_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Cross_Client_Permissions', NULL, NULL
GO
