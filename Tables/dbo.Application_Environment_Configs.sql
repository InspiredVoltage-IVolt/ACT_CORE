CREATE TABLE [dbo].[Application_Environment_Configs]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Application_Environment_ID] [uniqueidentifier] NULL,
[ConfigFileType_ID] [int] NOT NULL,
[FileName] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[ConfigData] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[ProjectRelativePath] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Version] [int] NOT NULL,
[DateAdded] [datetime] NOT NULL,
[DateModified] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Application_Environment_Configs] ADD CONSTRAINT [PK_ID_Application_Environment_Configs] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Application_Environment_Configs] ADD CONSTRAINT [FK_Application_Environment_Configs_Application_Environments] FOREIGN KEY ([Application_Environment_ID]) REFERENCES [dbo].[Application_Environments] ([ID])
GO
ALTER TABLE [dbo].[Application_Environment_Configs] ADD CONSTRAINT [FK_Application_Environment_Configs_DATA_Configuration_File_Types] FOREIGN KEY ([ConfigFileType_ID]) REFERENCES [dbo].[DATA_Configuration_File_Types] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'APPLICATION_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Application_Environment_Configs', NULL, NULL
GO
