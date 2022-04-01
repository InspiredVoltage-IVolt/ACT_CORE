CREATE TABLE [dbo].[SYSTEM_COMPLEX_SETTING_VALUES]
(
[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_SYSTEM_COMPLEX_SETTING_VALUES_ID] DEFAULT (newid()),
[Complex_Settings_ID] [uniqueidentifier] NOT NULL,
[Value] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[DateAdded] [datetime] NOT NULL CONSTRAINT [DF_SYSTEM_COMPLEX_SETTING_VALUES_DateAdded] DEFAULT (getdate()),
[DateModified] [datetime] NOT NULL CONSTRAINT [DF_SYSTEM_COMPLEX_SETTING_VALUES_DateModified] DEFAULT (getdate())
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SYSTEM_COMPLEX_SETTING_VALUES] ADD CONSTRAINT [PK_SYSTEM_COMPLEX_SETTING_VALUES] PRIMARY KEY CLUSTERED ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SYSTEM_COMPLEX_SETTING_VALUES] ADD CONSTRAINT [FK_SYSTEM_COMPLEX_SETTING_VALUES_SYSTEM_COMPLEX_SETTINGS] FOREIGN KEY ([Complex_Settings_ID]) REFERENCES [dbo].[SYSTEM_COMPLEX_SETTINGS] ([ID])
GO
EXEC sp_addextendedproperty N'VirtualFolder', N'SYSTEM_TABLES', 'SCHEMA', N'dbo', 'TABLE', N'SYSTEM_COMPLEX_SETTING_VALUES', NULL, NULL
GO