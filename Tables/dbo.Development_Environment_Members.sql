CREATE TABLE [dbo].[Development_Environment_Members]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Development_Environment_Members_ID] DEFAULT (newid()),
[Development_Environment_ID] [uniqueidentifier] NOT NULL,
[Member_ID] [uniqueidentifier] NULL,
[Permissions] [int] NULL,
[Deleted] [bit] NOT NULL CONSTRAINT [DF_Development_Environment_Members_Deleted] DEFAULT ((0)),
[Applied] [bit] NOT NULL CONSTRAINT [DF_Development_Environment_Members_Applied] DEFAULT ((0)),
[Approved] [bit] NOT NULL CONSTRAINT [DF_Development_Environment_Members_Approved] DEFAULT ((0)),
[Inviteded_From_Member_ID] [uniqueidentifier] NULL,
[Confirmation_Number] [uniqueidentifier] NULL,
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Development_Environment_Members_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Development_Environment_Members_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Development_Environment_Members] ADD CONSTRAINT [PK_Development_Environment_Members] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'DEVELOPMENT/ENVIRONMENTS', 'SCHEMA', N'dbo', 'TABLE', N'Development_Environment_Members', NULL, NULL
GO
