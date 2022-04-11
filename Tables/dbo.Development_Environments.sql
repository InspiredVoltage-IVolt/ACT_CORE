CREATE TABLE [dbo].[Development_Environments]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Development_Environments_ID] DEFAULT (newid()),
[Application_ID] [uniqueidentifier] NULL,
[Member_ID] [uniqueidentifier] NULL,
[Copy_Settings_From_Development_Environment_ID] [uniqueidentifier] NULL,
[ProjectName] [nvarchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Name] [nvarchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Symbols] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[PathInfo] [dbo].[JSON] NULL,
[Encryption_Plugin_ID] [uniqueidentifier] NULL,
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Development_Environments_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Development_Environments_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Development_Environments] ADD CONSTRAINT [PK_ID_Development_Environments] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Development_Environments] ADD CONSTRAINT [FK_Development_Environments_Application_ID_TO_Applications_ID] FOREIGN KEY ([Application_ID]) REFERENCES [dbo].[Applications] ([ID])
GO
ALTER TABLE [dbo].[Development_Environments] ADD CONSTRAINT [FK_Development_Environments_Members_Member_ID_TO_Member_ID] FOREIGN KEY ([Member_ID]) REFERENCES [dbo].[Members] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'DEVELOPMENT/ENVIRONMENTS', 'SCHEMA', N'dbo', 'TABLE', N'Development_Environments', NULL, NULL
GO
