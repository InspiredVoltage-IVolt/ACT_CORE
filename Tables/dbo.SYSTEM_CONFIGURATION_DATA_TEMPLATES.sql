CREATE TABLE [dbo].[SYSTEM_CONFIGURATION_DATA_TEMPLATES]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_SYSTEM_CONFIGURATION_DATA_TEMPLATES_ID] DEFAULT ('newid()'),
[Application_ID] [uniqueidentifier] NULL,
[Member_ID] [uniqueidentifier] NULL,
[Environment_ID] [uniqueidentifier] NULL,
[Name] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Description] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Tags] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IsPublic] [bit] NOT NULL,
[IsDefault] [bit] NOT NULL,
[DateAdded] [datetime] NOT NULL,
[DateModified] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SYSTEM_CONFIGURATION_DATA_TEMPLATES] ADD CONSTRAINT [PK_ID_SYSTEM_CONFIGURATION_DATA_TEMPLATES] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SYSTEM_CONFIGURATION_DATA_TEMPLATES] ADD CONSTRAINT [FK_SYSTEM_CONFIGURATION_DATA_TEMPLATES_Application_Environments] FOREIGN KEY ([Environment_ID]) REFERENCES [dbo].[Application_Environments] ([ID])
GO
ALTER TABLE [dbo].[SYSTEM_CONFIGURATION_DATA_TEMPLATES] ADD CONSTRAINT [FK_SYSTEM_CONFIGURATION_DATA_TEMPLATES_Applications] FOREIGN KEY ([Application_ID]) REFERENCES [dbo].[Applications] ([ID])
GO
ALTER TABLE [dbo].[SYSTEM_CONFIGURATION_DATA_TEMPLATES] ADD CONSTRAINT [FK_SYSTEM_CONFIGURATION_DATA_TEMPLATES_Members] FOREIGN KEY ([Member_ID]) REFERENCES [dbo].[Members] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'SYSTEM_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'SYSTEM_CONFIGURATION_DATA_TEMPLATES', NULL, NULL
GO
