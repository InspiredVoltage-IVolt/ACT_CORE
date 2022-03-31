CREATE TABLE [dbo].[Members]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Members_ID] DEFAULT (newid()),
[Online_Status_ID] [int] NOT NULL,
[Account_Status_ID] [int] NOT NULL,
[UserName] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Password] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Email] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[CompanyName] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[FirstName] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LastName] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[MiddleName] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DisplayName] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[WorkPhone] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[WorkPhoneExt] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[MobilePhone] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[AvatarURL] [nvarchar] (300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[EncryptionKey] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[AccessToken] [uniqueidentifier] NOT NULL,
[ConfirmationCode] [uniqueidentifier] NULL CONSTRAINT [DF_Members_ConfirmationCode] DEFAULT (newid()),
[IsAlias] [bit] NOT NULL,
[AdminAccount] [bit] NOT NULL,
[Deleted] [bit] NOT NULL CONSTRAINT [DF_Members_Deleted] DEFAULT ((0)),
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Members_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Members_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Members] ADD CONSTRAINT [PK_ID_Members] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Members] ADD CONSTRAINT [FK_Members_SYSTEM_MEMBER_ACCOUNT_STATUS] FOREIGN KEY ([Account_Status_ID]) REFERENCES [dbo].[SYSTEM_MEMBER_ACCOUNT_STATUS] ([ID])
GO
ALTER TABLE [dbo].[Members] ADD CONSTRAINT [FK_Members_SYSTEM_MEMBER_ONLINE_STATUS] FOREIGN KEY ([Online_Status_ID]) REFERENCES [dbo].[SYSTEM_MEMBER_ONLINE_STATUS] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'MEMBER_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Members', NULL, NULL
GO
