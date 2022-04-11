CREATE TABLE [dbo].[Applications]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Applications_ID] DEFAULT (newid()),
[IS_SYSTEM_APPLICATION] [bit] NOT NULL CONSTRAINT [DF_Applications_SYSTEM_APPLICATION] DEFAULT ((0)),
[Owner_Member_ID] [uniqueidentifier] NULL,
[Owner_Company_ID] [uniqueidentifier] NULL,
[Owner_Client_ID] [uniqueidentifier] NULL,
[Name] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Description] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Primary_Logo_BinaryImage] [varbinary] (max) NULL,
[Primary_Logo_FileName] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Primary_API_Key] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Primary_API_Secret] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Login_Page] [nvarchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Home_Page] [nvarchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Change_Password_Change_Page] [nvarchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Confirm_Email_Page] [nvarchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[New_Registration_Page] [nvarchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[General_Support_EmailAddress] [nvarchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ForgotPassword_EmailAddress] [nvarchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[NewUser_Support_EmailAddress] [nvarchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Confirm_Account_EmailAddress] [nvarchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[APP_Can_Create_Members] [bit] NOT NULL CONSTRAINT [DF_Applications_APP_Can_Create_Members] DEFAULT ((0)),
[APP_Can_Update_Passwords] [bit] NOT NULL CONSTRAINT [DF_Applications_APP_Can_Update_Passwords] DEFAULT ((0)),
[Member_Join_Requires_Invite] [bit] NOT NULL CONSTRAINT [DF_Applications_Member_Join_Requires_Approval] DEFAULT ((0)),
[App_Uses_External_Authentication] [bit] NOT NULL CONSTRAINT [DF_Applications_HAS_External_Authentication] DEFAULT ((0)),
[Default_Member_Permission] [int] NOT NULL CONSTRAINT [DF_Applications_Default_Member_Permission] DEFAULT ((0)),
[AdminComment] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_Applications_AdminComment] DEFAULT ('Application Created'),
[Deleted] [bit] NOT NULL CONSTRAINT [DF_Applications_Approved1] DEFAULT ((0)),
[Approved] [bit] NOT NULL CONSTRAINT [DF_Applications_Approved] DEFAULT ((0)),
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Applications_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Applications_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Applications] ADD CONSTRAINT [PK_ID_Applications] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Applications] ADD CONSTRAINT [FK_Applications_Members] FOREIGN KEY ([Owner_Member_ID]) REFERENCES [dbo].[Members] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'APPLICATION_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Applications', NULL, NULL
GO
