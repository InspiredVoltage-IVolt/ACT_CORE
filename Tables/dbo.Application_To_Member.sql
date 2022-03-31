CREATE TABLE [dbo].[Application_To_Member]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Member_ID] [uniqueidentifier] NOT NULL,
[Application_ID] [uniqueidentifier] NOT NULL,
[ConfirmationCode] [uniqueidentifier] NULL,
[Permissions] [bigint] NOT NULL,
[Banned] [bit] NOT NULL CONSTRAINT [DF__App_To_Member__Banned] DEFAULT ((0)),
[IsAdmin] [bit] NOT NULL,
[Approved] [bit] NOT NULL CONSTRAINT [DF__App_To_Member__Approved] DEFAULT ((1)),
[WebService_Token] [uniqueidentifier] NULL,
[WebService_TokenTimeStamp] [datetime] NULL,
[Additional_Information] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF__App_To_Member__DateA] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF__App_To_Member__DateM] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Application_To_Member] ADD CONSTRAINT [PK_ID_Application_To_Member] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Application_To_Member] ADD CONSTRAINT [FK_Application_To_Member_Applications] FOREIGN KEY ([Application_ID]) REFERENCES [dbo].[Applications] ([ID])
GO
ALTER TABLE [dbo].[Application_To_Member] ADD CONSTRAINT [FK_Application_To_Member_Members] FOREIGN KEY ([Member_ID]) REFERENCES [dbo].[Members] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'APPLICATION_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Application_To_Member', NULL, NULL
GO
