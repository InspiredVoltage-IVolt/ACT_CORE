CREATE TABLE [dbo].[Applications]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Applications_ID] DEFAULT (newid()),
[Member_ID] [uniqueidentifier] NULL,
[Company_ID] [uniqueidentifier] NULL,
[Client_ID] [uniqueidentifier] NULL,
[APIKey] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[APISecret] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Name] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Description] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[PrimaryLogo] [varbinary] (max) NULL,
[LoginPage] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[HomePage] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ChangePasswordPage] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ConfirmEmailPage] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[SupportEmailAddress] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ForgotPasswordEmail] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[NewUserRegistrationEmail] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ConfirmEmailEmail] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CanCreateUsers] [bit] NOT NULL,
[CanUpdatePassword] [bit] NOT NULL,
[Approved] [bit] NOT NULL,
[MemberJoinApproval] [bit] NOT NULL,
[DefaultMemberPermission] [int] NOT NULL,
[ExternalAuthentication] [bit] NOT NULL,
[SYSTEM_APPLICATION] [bit] NOT NULL CONSTRAINT [DF_Applications_SYSTEM_APPLICATION] DEFAULT ((0)),
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Applications_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Applications_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Applications] ADD CONSTRAINT [PK_ID_Applications] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Applications] ADD CONSTRAINT [FK_Applications_Members] FOREIGN KEY ([Member_ID]) REFERENCES [dbo].[Members] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'APPLICATION_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Applications', NULL, NULL
GO
