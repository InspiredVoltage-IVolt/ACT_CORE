CREATE TABLE [dbo].[Client_Member_Permissions]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Client_ID] [uniqueidentifier] NOT NULL,
[Member_ID] [uniqueidentifier] NOT NULL,
[Client_Permission_Group_ID] [int] NULL,
[Client_Permission_Definition_ID] [int] NULL,
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Client_Member_Permissions_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Client_Member_Permissions_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Client_Member_Permissions] ADD CONSTRAINT [PK_Client_Member_Permissions] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Client_Member_Permissions] ADD CONSTRAINT [FK_Client_Member_Permissions_Client_Permission_Definitions] FOREIGN KEY ([Client_Permission_Definition_ID]) REFERENCES [dbo].[Client_Permission_Definitions] ([ID])
GO
ALTER TABLE [dbo].[Client_Member_Permissions] ADD CONSTRAINT [FK_Client_Member_Permissions_Client_Permission_Groups] FOREIGN KEY ([Client_Permission_Group_ID]) REFERENCES [dbo].[Client_Permission_Groups] ([ID])
GO
ALTER TABLE [dbo].[Client_Member_Permissions] ADD CONSTRAINT [FK_Client_Member_Permissions_Clients] FOREIGN KEY ([Client_ID]) REFERENCES [dbo].[Clients] ([ID])
GO
ALTER TABLE [dbo].[Client_Member_Permissions] ADD CONSTRAINT [FK_Client_Member_Permissions_Members] FOREIGN KEY ([Member_ID]) REFERENCES [dbo].[Members] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'CLIENT_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Client_Member_Permissions', NULL, NULL
GO
