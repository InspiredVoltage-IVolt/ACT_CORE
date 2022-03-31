CREATE TABLE [dbo].[Member_Invitations]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[EmailAddress] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[InvitationID] [uniqueidentifier] NOT NULL,
[Application_ID] [uniqueidentifier] NOT NULL,
[CustomMessage] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Member_ID] [uniqueidentifier] NULL,
[Client_ID] [uniqueidentifier] NULL,
[AsAdmin] [bit] NOT NULL,
[InitialPermissions] [bigint] NOT NULL,
[DateAdded] [datetime] NOT NULL,
[DateModified] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Member_Invitations] ADD CONSTRAINT [PK_ID_Member_Invitations] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Member_Invitations] ADD CONSTRAINT [FK_Member_Invitations_Applications] FOREIGN KEY ([Application_ID]) REFERENCES [dbo].[Applications] ([ID])
GO
ALTER TABLE [dbo].[Member_Invitations] ADD CONSTRAINT [FK_Member_Invitations_Clients] FOREIGN KEY ([Client_ID]) REFERENCES [dbo].[Clients] ([ID])
GO
ALTER TABLE [dbo].[Member_Invitations] ADD CONSTRAINT [FK_Member_Invitations_Members] FOREIGN KEY ([Member_ID]) REFERENCES [dbo].[Members] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'MEMBER_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Member_Invitations', NULL, NULL
GO
