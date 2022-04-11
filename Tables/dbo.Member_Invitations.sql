CREATE TABLE [dbo].[Member_Invitations]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Invitation_ID] [uniqueidentifier] NOT NULL,
[Application_ID] [uniqueidentifier] NOT NULL,
[Member_ID] [uniqueidentifier] NULL,
[Client_ID] [uniqueidentifier] NULL,
[To_EmailAddress] [nvarchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[CustomMessage] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Invite_As_Admin] [bit] NOT NULL CONSTRAINT [DF_Member_Invitations_AsAdmin] DEFAULT ((0)),
[Initial_Permissions] [bigint] NOT NULL CONSTRAINT [DF_Member_Invitations_Initial_Permissions] DEFAULT ((0)),
[Has_Read] [bit] NOT NULL CONSTRAINT [DF_Member_Invitations_Has_Read] DEFAULT ((0)),
[Has_Denied] [bit] NOT NULL CONSTRAINT [DF_Member_Invitations_Has_Denied] DEFAULT ((0)),
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Member_Invitations_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Member_Invitations_DateModified] DEFAULT (getdate())
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
