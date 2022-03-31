CREATE TABLE [dbo].[Application_Plugins]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Application_Environment_Plugins_ID] DEFAULT (newid()),
[Application_ID] [uniqueidentifier] NULL,
[Application_Environment_ID] [uniqueidentifier] NULL,
[System_Interface_ID] [uniqueidentifier] NOT NULL,
[Dependancy_ID] [uniqueidentifier] NULL,
[Member_ID] [uniqueidentifier] NULL,
[Client_ID] [uniqueidentifier] NULL,
[Company_ID] [uniqueidentifier] NULL,
[IsCoreEncryption] [bit] NOT NULL CONSTRAINT [DF_Application_Plugins_IsCoreEncryption] DEFAULT ((0)),
[DataHasBeenEncrypted] [bit] NOT NULL CONSTRAINT [DF_Application_Plugins_DataEncrypted] DEFAULT ((0)),
[Full_Class_Name] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Is_Default] [bit] NULL CONSTRAINT [DF_Application_Environment_Plugins_Is_Default] DEFAULT ((0)),
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_Application_Environment_Plugins_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_Application_Environment_Plugins_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Application_Plugins] ADD CONSTRAINT [PK_Application_Environment_Plugins] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Application_Plugins] ADD CONSTRAINT [FK_Application_Plugins_Applications] FOREIGN KEY ([Application_ID]) REFERENCES [dbo].[Applications] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'APPLICATION_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'Application_Plugins', NULL, NULL
GO
